import { computeMatchPercent } from '@/lib/api';
import {
  CROWD_BADGES,
  FACILITY_LABELS,
  REGION_GRADIENTS,
  SKILL_BADGES,
  SPOT_IMAGES,
  WAVE_SIZE_LABELS,
  WAVE_TYPE_LABELS,
  spotRegionLabel,
  type Badge,
} from '@/lib/constants';
import type { SpotBase, SpotRecommendation, UserPreferences } from '@/lib/types';

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
  regionLabel: spotRegionLabel(spot.name, spot.region),
  description: spot.description,
  waveTypeLabel: WAVE_TYPE_LABELS[spot.waveType],
  waveSizeLabel: WAVE_SIZE_LABELS[spot.currentWaveSize],
  crowdBadge: CROWD_BADGES[spot.typicalCrowd],
  skillBadge: SKILL_BADGES[spot.minSkillLevel],
});

export interface SpotModalViewModel extends Omit<SpotCardViewModel, 'matchPct'> {
  matchPct: number | null;
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
  spot: SpotBase,
  preferences?: UserPreferences,
): SpotModalViewModel => {
  const rec = spot as Partial<SpotRecommendation>;
  return {
    matchPct: preferences && rec.score !== undefined ? computeMatchPercent(rec.score, preferences) : null,
    backgroundStyle: { background: REGION_GRADIENTS[spot.region] },
    imageUrl: SPOT_IMAGES[spot.name],
    name: spot.name,
    regionLabel: spotRegionLabel(spot.name, spot.region),
    description: spot.description,
    waveTypeLabel: WAVE_TYPE_LABELS[spot.waveType],
    waveSizeLabel: WAVE_SIZE_LABELS[spot.currentWaveSize],
    crowdBadge: CROWD_BADGES[spot.typicalCrowd],
    skillBadge: SKILL_BADGES[spot.minSkillLevel],
    facilitiesLabels: spot.facilities.map((f) => FACILITY_LABELS[f]),
    mapsUrl: `https://www.google.com/maps/search/?api=1&query=${encodeURIComponent(spot.name + ' New Zealand')}`,
    skillLevel: spot.minSkillLevel,
    crowdLevel: spot.typicalCrowd,
    waveType: WAVE_TYPE_LABELS[spot.waveType],
    currentHeight: WAVE_SIZE_LABELS[spot.currentWaveSize],
    hasNotes: (rec.notes?.length ?? 0) > 0,
    notes: rec.notes ?? [],
  };
};
