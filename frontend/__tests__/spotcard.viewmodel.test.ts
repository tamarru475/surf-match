import { toSpotCardViewModel, toSpotModalViewModel } from '@/components/results/SpotCard.viewmodel';
import type { SpotRecommendation, UserPreferences } from '@/lib/types';

const spot: SpotRecommendation = {
  spotId: '00000000-0000-0000-0000-000000000001',
  name: 'Piha',
  region: 'Auckland',
  waveType: 'BeachBreak',
  minSkillLevel: 'Intermediate',
  typicalCrowd: 'Busy',
  currentWaveSize: 'HeadHigh',
  facilities: ['Bathrooms', 'Showers'],
  description: "Auckland's most famous surf beach.",
  score: 20,
  summary: 'Good match.',
  breakdown: {
    skillMatch: 0, boardMatch: 0, crowdMatch: 20,
    regionMatch: 0, waveTypeMatch: 0, waveSizeMatch: 0, facilityMatch: 0,
  },
};

const prefs: UserPreferences = {
  skillLevel: 'Intermediate',
  crowdTolerance: 'Busy',
  boardTypes: [],
  preferredWaveTypes: [],
  preferredWaveSizes: [],
  preferredFacilities: [],
};

describe('toSpotCardViewModel', () => {
  it('converts region enum to display label', () => {
    const vm = toSpotCardViewModel(spot, prefs);
    expect(vm.regionLabel).toBe('Auckland');
  });

  it('converts wave type to display label', () => {
    const vm = toSpotCardViewModel(spot, prefs);
    expect(vm.waveTypeLabel).toBe('Beach Break');
  });

  it('converts wave size to display label', () => {
    const vm = toSpotCardViewModel(spot, prefs);
    expect(vm.waveSizeLabel).toBe('Head High');
  });

  it('assigns correct crowd badge variant', () => {
    const vm = toSpotCardViewModel(spot, prefs);
    expect(vm.crowdBadge.label).toBe('Crowded');
    expect(vm.crowdBadge.variant).toBe('badgeRed');
  });

  it('assigns correct skill badge variant', () => {
    const vm = toSpotCardViewModel(spot, prefs);
    expect(vm.skillBadge.label).toBe('Intermediate');
    expect(vm.skillBadge.variant).toBe('badgeBlue');
  });

  it('returns image URL for known spots', () => {
    const vm = toSpotCardViewModel(spot, prefs);
    expect(vm.imageUrl).toBe('/images/piha.jpg');
  });

  it('returns undefined image URL for unknown spots', () => {
    const vm = toSpotCardViewModel({ ...spot, name: 'Unknown Spot' }, prefs);
    expect(vm.imageUrl).toBeUndefined();
  });

  it('computes match percent correctly', () => {
    // No board, no facilities → max = 20 (crowd). Score 20 → 100%
    const vm = toSpotCardViewModel(spot, prefs);
    expect(vm.matchPct).toBe(100);
  });
});

describe('toSpotModalViewModel', () => {
  it('includes all card fields', () => {
    const vm = toSpotModalViewModel(spot, prefs);
    expect(vm.name).toBe('Piha');
    expect(vm.waveTypeLabel).toBe('Beach Break');
  });

  it('maps facilities to display labels', () => {
    const vm = toSpotModalViewModel(spot, prefs);
    expect(vm.facilitiesLabels).toEqual(['Bathrooms', 'Showers']);
  });

  it('builds a Google Maps URL containing the spot name', () => {
    const vm = toSpotModalViewModel(spot, prefs);
    expect(vm.mapsUrl).toContain('Piha');
    expect(vm.mapsUrl).toContain('New%20Zealand');
  });

  it('sets hasNotes to false for generic summary', () => {
    const vm = toSpotModalViewModel(spot, prefs);
    expect(vm.hasNotes).toBe(false);
  });

  it('sets hasNotes to true for meaningful notes', () => {
    const vm = toSpotModalViewModel(
      { ...spot, summary: 'none of your boards are ideal for this spot.' },
      prefs,
    );
    expect(vm.hasNotes).toBe(true);
    expect(vm.notes).toBe('none of your boards are ideal for this spot.');
  });

  it('converts current wave size to display label', () => {
    const vm = toSpotModalViewModel(spot, prefs);
    expect(vm.currentHeight).toBe('Head High');
  });
});
