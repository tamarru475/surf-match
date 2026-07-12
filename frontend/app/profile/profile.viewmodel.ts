'use client';

import { useState, useEffect, useCallback, useMemo, useRef } from 'react';
import { useRouter } from 'next/navigation';
import { fetchProfile, updateProfile, fetchUserPreferences, fetchRecommendations } from '@/lib/api';
import { useAuth } from '@/lib/AuthContext';
import { REGIONS } from '@/lib/types';
import type { Profile, UserPreferences } from '@/lib/types';

export interface PrefRow {
  label: string;
  getValue: (p: UserPreferences) => string;
}

export interface ProfileViewModel {
  profile: Profile | null;
  preferences: UserPreferences | null;
  avatarLetter: string;
  prefRows: PrefRow[];
  displayName: string;
  location: string;
  bio: string;
  instagramHandle: string;
  tikTokHandle: string;
  loading: boolean;
  saving: boolean;
  findingWave: boolean;
  saveSuccess: boolean;
  isDirty: boolean;
  error: string | null;
  setDisplayName: (v: string) => void;
  setLocation: (v: string) => void;
  setBio: (v: string) => void;
  setInstagramHandle: (v: string) => void;
  setTikTokHandle: (v: string) => void;
  handleSave: () => void;
  handleFindWave: () => void;
}

export const REGION_OPTIONS = REGIONS;

const PREF_ROWS: PrefRow[] = [
  { label: 'Skill Level',     getValue: (p) => formatEnum(p.skillLevel) },
  { label: 'Crowd Tolerance', getValue: (p) => formatEnum(p.crowdTolerance) },
  { label: 'Search Region',   getValue: (p) => p.preferredRegion ? formatEnum(p.preferredRegion) : 'Any' },
  { label: 'Board Types',     getValue: (p) => p.boardTypes.length ? p.boardTypes.map(formatEnum).join(', ') : 'Any' },
  { label: 'Wave Types',      getValue: (p) => p.preferredWaveTypes.length ? p.preferredWaveTypes.map(formatEnum).join(', ') : 'Any' },
  { label: 'Wave Sizes',      getValue: (p) => p.preferredWaveSizes.length ? p.preferredWaveSizes.map(formatEnum).join(', ') : 'Any' },
  { label: 'Facilities',      getValue: (p) => p.preferredFacilities.length ? p.preferredFacilities.map(formatEnum).join(', ') : 'None' },
];

export const useProfileViewModel = (): ProfileViewModel => {
  const { user } = useAuth();
  const router = useRouter();
  const saveSuccessTimer = useRef<ReturnType<typeof setTimeout> | null>(null);

  const [profile, setProfile]                 = useState<Profile | null>(null);
  const [preferences, setPreferences]         = useState<UserPreferences | null>(null);
  const [displayName, setDisplayName]         = useState('');
  const [location, setLocation]               = useState('');
  const [bio, setBio]                         = useState('');
  const [instagramHandle, setInstagramHandle] = useState('');
  const [tikTokHandle, setTikTokHandle]       = useState('');
  const [loading, setLoading]                 = useState(true);
  const [saving, setSaving]                   = useState(false);
  const [findingWave, setFindingWave]         = useState(false);
  const [saveSuccess, setSaveSuccess]         = useState(false);
  const [error, setError]                     = useState<string | null>(null);

  useEffect(() => {
    if (!user) { router.push('/'); return; }

    Promise.all([
      fetchProfile(),
      fetchUserPreferences().catch(() => null),
    ])
      .then(([p, prefs]) => {
        setProfile(p);
        setDisplayName(p.displayName ?? '');
        // Seed location from quiz region if not yet saved on profile.
        setLocation(p.location ?? prefs?.preferredRegion ?? '');
        setBio(p.bio ?? '');
        setInstagramHandle(p.instagramHandle ?? '');
        setTikTokHandle(p.tikTokHandle ?? '');
        setPreferences(prefs);
      })
      .catch(() => router.push('/'))
      .finally(() => setLoading(false));
  }, [user]);

  // True when any field differs from what was last saved.
  const isDirty = useMemo(() => {
    if (!profile) return false;
    return (
      displayName  !== (profile.displayName  ?? '') ||
      location     !== (profile.location     ?? '') ||
      bio          !== (profile.bio          ?? '') ||
      instagramHandle !== (profile.instagramHandle ?? '') ||
      tikTokHandle !== (profile.tikTokHandle ?? '')
    );
  }, [displayName, location, bio, instagramHandle, tikTokHandle, profile]);

  const handleSave = useCallback(async () => {
    setSaving(true);
    setError(null);
    setSaveSuccess(false);
    if (saveSuccessTimer.current) clearTimeout(saveSuccessTimer.current);

    try {
      const updated = await updateProfile({
        displayName:     displayName.trim() || null,
        location:        location.trim() || null,
        bio:             bio.trim() || null,
        instagramHandle: instagramHandle.trim() || null,
        tikTokHandle:    tikTokHandle.trim() || null,
      });
      setProfile(updated);
      setSaveSuccess(true);
      // Auto-clear "Saved!" after 2.5s — isDirty will be false so button stays hidden.
      saveSuccessTimer.current = setTimeout(() => setSaveSuccess(false), 2500);
    } catch {
      setError('Failed to save. Please try again.');
    } finally {
      setSaving(false);
    }
  }, [displayName, location, bio, instagramHandle, tikTokHandle]);

  const handleFindWave = useCallback(async () => {
    if (!preferences) { router.push('/quiz'); return; }
    setFindingWave(true);
    setError(null);
    try {
      const data = await fetchRecommendations(preferences);
      sessionStorage.setItem('surfmatch_results', JSON.stringify(data));
      router.push('/results');
    } catch {
      setError('Could not reach the server. Is the backend running?');
    } finally {
      setFindingWave(false);
    }
  }, [preferences, router]);

  const avatarLetter = (profile?.displayName ?? profile?.email ?? '?')[0].toUpperCase();

  return {
    profile, preferences,
    avatarLetter, prefRows: PREF_ROWS,
    displayName, location, bio, instagramHandle, tikTokHandle,
    loading, saving, findingWave, saveSuccess, isDirty, error,
    setDisplayName, setLocation, setBio, setInstagramHandle, setTikTokHandle,
    handleSave, handleFindWave,
  };
};

// "WaistHigh" → "Waist High", "BeachBreak" → "Beach Break", etc.
export const formatEnum = (value: string) =>
  value.replace(/([A-Z])/g, ' $1').trim();
