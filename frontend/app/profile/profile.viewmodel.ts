'use client';

import { useState, useEffect, useCallback } from 'react';
import { useRouter } from 'next/navigation';
import {
  fetchProfile, fetchUserPreferences, fetchRecommendations, saveUserPreferences,
} from '@/lib/api';
import { useAuth } from '@/lib/AuthContext';
import type { Profile, SkillLevel, UserPreferences } from '@/lib/types';

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
        // Seed location from quiz region if not yet saved on profile.
        setProfile({ ...p, location: p.location ?? prefs?.preferredRegions[0] ?? null });
        setPreferences(prefs);
        setSkillLevel(prefs?.skillLevel ?? null);
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
