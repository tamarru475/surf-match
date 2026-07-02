import { computeMatchPercent, fetchRecommendations } from '@/lib/api';
import type { UserPreferences } from '@/lib/types';

// ── fetchRecommendations ──────────────────────────────────────────────────────

const minPrefs: UserPreferences = {
  skillLevel: 'Beginner',
  crowdTolerance: 'Quiet',
  boardTypes: [],
  preferredWaveTypes: [],
  preferredWaveSizes: [],
  preferredFacilities: [],
};

const fakeResponse = { recommendations: [], preferences: minPrefs, warnings: [] };

describe('fetchRecommendations', () => {
  beforeEach(() => { global.fetch = jest.fn(); });
  afterEach(() => { jest.resetAllMocks(); });

  it('returns parsed JSON on a successful response', async () => {
    (global.fetch as jest.Mock).mockResolvedValue({
      ok: true,
      json: async () => fakeResponse,
    });

    const result = await fetchRecommendations(minPrefs);

    expect(result).toEqual(fakeResponse);
    expect(global.fetch).toHaveBeenCalledWith(
      expect.stringContaining('/recommendations'),
      expect.objectContaining({ method: 'POST' }),
    );
  });

  it('throws when the server returns a non-ok status', async () => {
    (global.fetch as jest.Mock).mockResolvedValue({
      ok: false,
      status: 500,
      json: async () => ({}),
    });

    await expect(fetchRecommendations(minPrefs)).rejects.toThrow('API error: 500');
  });
});

const base: UserPreferences = {
  skillLevel: 'Beginner',
  crowdTolerance: 'Quiet',
  boardTypes: [],
  preferredWaveTypes: [],
  preferredWaveSizes: [],
  preferredFacilities: [],
};

// Scoring formula:
//   max = (boardTypes.length > 0 ? 20 : 0) + 20 (crowd always) + preferredFacilities.length
//   pct = min(100, round(score / max * 100))
//
// score | boards        | facilities              | max | expected
type Row = [number, string[], string[], number];

const cases: Row[] = [
  // crowd only (max = 20)
  [20,  [],        [],                      100],
  [ 0,  [],        [],                        0],
  [10,  [],        [],                       50],
  // board + crowd (max = 40)
  [20,  ['Fish'],  [],                       50],
  [40,  ['Fish'],  [],                      100],
  // board + crowd + 1 facility (max = 41)
  [20,  ['Fish'],  ['Bathrooms'],            49],  // round(20/41*100) = 49
  [41,  ['Fish'],  ['Bathrooms'],           100],
  // crowd + 2 facilities (max = 22)
  [22,  [],        ['Bathrooms', 'Showers'],100],
  [11,  [],        ['Bathrooms', 'Showers'], 50],
  // board + crowd + 2 facilities (max = 42)
  [21,  ['Fish'],  ['Bathrooms', 'Showers'], 50],  // round(21/42*100) = 50
  // capped at 100 regardless of score
  [999, ['Fish'],  [],                      100],
  // multiple boards still counts as one board slot (max stays 40)
  [20,  ['Fish', 'Longboard'], [],           50],
];

it.each(cases)(
  'score=%i boards=%j facilities=%j → %i%%',
  (score, boardTypes, preferredFacilities, expected) => {
    const prefs: UserPreferences = {
      ...base,
      boardTypes: boardTypes as UserPreferences['boardTypes'],
      preferredFacilities: preferredFacilities as UserPreferences['preferredFacilities'],
    };
    expect(computeMatchPercent(score, prefs)).toBe(expected);
  },
);
