'use client';

import { useState, useEffect, useCallback, useMemo, useRef } from 'react';
import { saveUserPreferences } from '@/lib/api';
import { REGIONS } from '@/lib/types';
import type {
  UserPreferences,
  SkillLevel, CrowdLevel, Region, BoardType, WaveType, WaveSize, Facility,
} from '@/lib/types';

export interface PreferencesViewModel {
  skillLevel: SkillLevel;
  crowdTolerance: CrowdLevel;
  prefRegions: Region[];
  boardTypes: BoardType[];
  waveTypes: WaveType[];
  waveSizes: WaveSize[];
  facilities: Facility[];
  isPreferencesDirty: boolean;
  savingPreferences: boolean;
  prefsSaveSuccess: boolean;
  error: string | null;
  setSkillLevel: (v: SkillLevel) => void;
  setCrowdTolerance: (v: CrowdLevel) => void;
  togglePrefRegion: (v: Region) => void;
  toggleBoardType: (v: BoardType) => void;
  toggleWaveType: (v: WaveType) => void;
  toggleWaveSize: (v: WaveSize) => void;
  toggleFacility: (v: Facility) => void;
  handleSavePreferences: () => void;
}

export const REGION_OPTIONS = REGIONS;

const sameArr = <T extends string>(a: T[], b: T[]) =>
  a.length === b.length && [...a].sort().join() === [...b].sort().join();

export const usePreferencesViewModel = (
  initialPreferences: UserPreferences | null,
): PreferencesViewModel => {
  const saveSuccessTimer = useRef<ReturnType<typeof setTimeout> | null>(null);

  const [saved, setSaved]               = useState<UserPreferences | null>(initialPreferences);
  const [skillLevel, setSkillLevel]     = useState<SkillLevel>(initialPreferences?.skillLevel ?? 'Beginner');
  const [crowdTolerance, setCrowdTolerance] = useState<CrowdLevel>(initialPreferences?.crowdTolerance ?? 'Moderate');
  const [prefRegions, setPrefRegions]   = useState<Region[]>(initialPreferences?.preferredRegions ?? []);
  const [boardTypes, setBoardTypes]     = useState<BoardType[]>(initialPreferences?.boardTypes ?? []);
  const [waveTypes, setWaveTypes]       = useState<WaveType[]>(initialPreferences?.preferredWaveTypes ?? []);
  const [waveSizes, setWaveSizes]       = useState<WaveSize[]>(initialPreferences?.preferredWaveSizes ?? []);
  const [facilities, setFacilities]     = useState<Facility[]>(initialPreferences?.preferredFacilities ?? []);
  const [savingPreferences, setSavingPreferences] = useState(false);
  const [prefsSaveSuccess, setPrefsSaveSuccess]   = useState(false);
  const [error, setError]               = useState<string | null>(null);

  // Sync when parent finishes loading initial preferences.
  useEffect(() => {
    if (!initialPreferences) return;
    setSaved(initialPreferences);
    setSkillLevel(initialPreferences.skillLevel);
    setCrowdTolerance(initialPreferences.crowdTolerance);
    setPrefRegions(initialPreferences.preferredRegions);
    setBoardTypes(initialPreferences.boardTypes);
    setWaveTypes(initialPreferences.preferredWaveTypes);
    setWaveSizes(initialPreferences.preferredWaveSizes);
    setFacilities(initialPreferences.preferredFacilities);
  }, [initialPreferences]);

  const isPreferencesDirty = useMemo(() => {
    if (!saved) return false;
    return (
      skillLevel     !== saved.skillLevel ||
      crowdTolerance !== saved.crowdTolerance ||
      !sameArr(prefRegions, saved.preferredRegions) ||
      !sameArr(boardTypes, saved.boardTypes) ||
      !sameArr(waveTypes,  saved.preferredWaveTypes) ||
      !sameArr(waveSizes,  saved.preferredWaveSizes) ||
      !sameArr(facilities, saved.preferredFacilities)
    );
  }, [skillLevel, crowdTolerance, prefRegions, boardTypes, waveTypes, waveSizes, facilities, saved]);

  const togglePrefRegion = useCallback((v: Region) =>
    setPrefRegions(prev => prev.includes(v) ? prev.filter(x => x !== v) : [...prev, v]), []);

  const toggleBoardType = useCallback((v: BoardType) =>
    setBoardTypes(prev => prev.includes(v) ? prev.filter(x => x !== v) : [...prev, v]), []);

  const toggleWaveType = useCallback((v: WaveType) =>
    setWaveTypes(prev => prev.includes(v) ? prev.filter(x => x !== v) : [...prev, v]), []);

  const toggleWaveSize = useCallback((v: WaveSize) =>
    setWaveSizes(prev => prev.includes(v) ? prev.filter(x => x !== v) : [...prev, v]), []);

  const toggleFacility = useCallback((v: Facility) =>
    setFacilities(prev => prev.includes(v) ? prev.filter(x => x !== v) : [...prev, v]), []);

  const handleSavePreferences = useCallback(async () => {
    setSavingPreferences(true);
    setError(null);
    setPrefsSaveSuccess(false);
    if (saveSuccessTimer.current) clearTimeout(saveSuccessTimer.current);
    try {
      const prefs: UserPreferences = {
        skillLevel,
        crowdTolerance,
        preferredRegions: prefRegions,
        boardTypes,
        preferredWaveTypes: waveTypes,
        preferredWaveSizes: waveSizes,
        preferredFacilities: facilities,
      };
      await saveUserPreferences(prefs);
      setSaved(prefs);
      setPrefsSaveSuccess(true);
      saveSuccessTimer.current = setTimeout(() => setPrefsSaveSuccess(false), 2500);
    } catch {
      setError('Failed to save preferences. Please try again.');
    } finally {
      setSavingPreferences(false);
    }
  }, [skillLevel, crowdTolerance, prefRegions, boardTypes, waveTypes, waveSizes, facilities]);

  return {
    skillLevel, crowdTolerance, prefRegions, boardTypes, waveTypes, waveSizes, facilities,
    isPreferencesDirty, savingPreferences, prefsSaveSuccess, error,
    setSkillLevel, setCrowdTolerance, togglePrefRegion,
    toggleBoardType, toggleWaveType, toggleWaveSize, toggleFacility,
    handleSavePreferences,
  };
};
