'use client';

import { useState, useEffect, useCallback } from 'react';
import { useRouter } from 'next/navigation';
import {
  fetchProfile, fetchUserPreferences, fetchRecommendations, saveUserPreferences, updateProfile,
} from '@/lib/api';
import { useAuth } from '@/lib/AuthContext';
import type { Profile, Region, SkillLevel, UserPreferences } from '@/lib/types';

export interface ProfileViewModel {
  profile: Profile | null;
  preferences: UserPreferences | null;
  skillLevel: SkillLevel | null;
  loading: boolean;
  findingWave: boolean;
  error: string | null;
  handleFindWave: () => void;
  handleSaveSkillLevel: (level: SkillLevel) => void;
}

export const useProfileViewModel = (): ProfileViewModel => {
  const { user } = useAuth();
  const router = useRouter();

  const [profile, setProfile]         = useState<Profile | null>(null);
  const [preferences, setPreferences] = useState<UserPreferences | null>(null);
  const [skillLevel, setSkillLevel]   = useState<SkillLevel | null>(null);
  const [loading, setLoading]         = useState(true);
  const [findingWave, setFindingWave] = useState(false);
  const [error, setError]             = useState<string | null>(null);

  useEffect(() => {
    if (!user) { router.push('/'); return; }

    Promise.all([
      fetchProfile(),
      fetchUserPreferences().catch(() => null),
    ])
      .then(([p, prefs]) => {
        // Fallback: if handlePostAuth couldn't save prefs (e.g. Supabase session
        // wasn't ready yet), recover them directly from the quiz sessionStorage key.
        let resolvedPrefs = prefs;
        if (!resolvedPrefs) {
          try {
            const raw = sessionStorage.getItem('surfmatch_results');
            if (raw) {
              const { preferences } = JSON.parse(raw) as { preferences: UserPreferences };
              if (preferences) {
                resolvedPrefs = preferences;
                saveUserPreferences(preferences).catch(() => {});
              }
            }
          } catch {}
        }

        const firstRegion = resolvedPrefs?.preferredRegions[0] as Region | undefined;
        // Store the raw enum value — the profile card uses a <select> whose
        // option values are enum strings (e.g. 'BayOfPlenty'). Using the
        // human-readable label ('Coromandel / Bay of Plenty') would not match
        // any option and the field would show the blank placeholder instead.
        const seededLocation = firstRegion ?? null;
        // Use || not ?? — the backend initialises new-user rows with "" (empty
        // string), and ?? only falls back for null/undefined, so "" would slip
        // through and leave the location select showing "Your region".
        const resolvedLocation = p.location || seededLocation || null;
        setProfile({ ...p, location: resolvedLocation });
        setPreferences(resolvedPrefs);
        setSkillLevel(resolvedPrefs?.skillLevel ?? null);
        // Persist the seeded location so it survives page reloads.
        if (!p.location && resolvedLocation) {
          updateProfile({
            displayName:     p.displayName     || '',
            location:        resolvedLocation,
            bio:             p.bio             || '',
            instagramHandle: p.instagramHandle || '',
            tikTokHandle:    p.tikTokHandle    || '',
          }).catch(() => {});
        }
      })
      .catch(() => router.push('/'))
      .finally(() => setLoading(false));
  }, [user]);

  const handleSaveSkillLevel = useCallback((level: SkillLevel) => {
    setSkillLevel(level);
    if (!preferences) return;
    const updated = { ...preferences, skillLevel: level };
    setPreferences(updated);
    saveUserPreferences(updated).catch(() => {});
  }, [preferences]);

  const handleFindWave = useCallback(async () => {
    setFindingWave(true);
    setError(null);
    try {
      const prefs = await fetchUserPreferences().catch(() => null);
      if (!prefs) { router.push('/quiz'); return; }
      const data = await fetchRecommendations(prefs);
      sessionStorage.setItem('surfmatch_results', JSON.stringify(data));
      router.push('/results');
    } catch {
      setError('Could not reach the server. Is the backend running?');
    } finally {
      setFindingWave(false);
    }
  }, [router]);

  return { profile, preferences, skillLevel, loading, findingWave, error, handleFindWave, handleSaveSkillLevel };
};

// "WaistHigh" → "Waist High", "BeachBreak" → "Beach Break", etc.
export const formatEnum = (value: string) =>
  value.replace(/([A-Z])/g, ' $1').trim();
