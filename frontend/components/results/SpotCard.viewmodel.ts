import { computeMatchPercent } from '@/lib/api';
import {
  CROWD_BADGES,
  FACILITY_LABELS,
  REGION_GRADIENTS,
  REGION_LABELS,
  SKILL_BADGES,
  SPOT_IMAGES,
  WAVE_SIZE_LABELS,
  WAVE_TYPE_LABELS,
  type Badge,
} from '@/lib/constants';
import type { Facility, SpotRecommendation, UserPreferences } from '@/lib/types';

export interface SpotCardViewModel {
  matchPct: number;
  backgroundStyle: { background: string };
  imageUrl?: string;
  name: string;
  regionLabel: string;
  description: string;
  waveTypeLabel: string;
  waveSizeLabel: string;
  crowdBadge: Badge;
  skillBadge: Badge;
}

export const toSpotCardViewModel = (
  spot: SpotRecommendation,
  preferences: UserPreferences,
): SpotCardViewModel => ({
  matchPct: computeMatchPercent(spot.score, preferences),
  backgroundStyle: { background: REGION_GRADIENTS[spot.region] },
  imageUrl: SPOT_IMAGES[spot.name],
  name: spot.name,
  regionLabel: REGION_LABELS[spot.region],
  description: spot.description,
  waveTypeLabel: WAVE_TYPE_LABELS[spot.waveType],
  waveSizeLabel: WAVE_SIZE_LABELS[spot.currentWaveSize],
  crowdBadge: CROWD_BADGES[spot.typicalCrowd],
  skillBadge: SKILL_BADGES[spot.minSkillLevel],
});

export interface SpotModalViewModel extends SpotCardViewModel {
  facilitiesLabels: string[];
  mapsUrl: string;
  skillLevel: string;
  crowdLevel: string;
  waveType: string;
  currentHeight: string;
  hasNotes: boolean;
  notes: string[];
}

export const toSpotModalViewModel = (
  spot: SpotRecommendation,
  preferences: UserPreferences,
): SpotModalViewModel => {
  const card = toSpotCardViewModel(spot, preferences);
  return {
    ...card,
    facilitiesLabels: spot.facilities.map((f: Facility) => FACILITY_LABELS[f]),
    mapsUrl: `https://www.google.com/maps/search/?api=1&query=${encodeURIComponent(spot.name + ' New Zealand')}`,
    skillLevel: spot.minSkillLevel,
    crowdLevel: spot.typicalCrowd,
    waveType: WAVE_TYPE_LABELS[spot.waveType],
    currentHeight: WAVE_SIZE_LABELS[spot.currentWaveSize],
    hasNotes: spot.notes.length > 0,
    notes: spot.notes,
  };
};
