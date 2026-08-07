/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { useFavoritesViewModel } from '@/app/profile/favorites/favorites.viewmodel';
import type { FavoriteSpot } from '@/lib/types';

const mockFetchFavorites = jest.fn();
const mockRemoveFavorite = jest.fn();
jest.mock('../../../lib/api', () => ({
  ...jest.requireActual('../../../lib/api'),
  fetchFavorites: (...args: unknown[]) => mockFetchFavorites(...args),
  removeFavorite: (...args: unknown[]) => mockRemoveFavorite(...args),
}));

const SPOT_ID = 'spot-1';

const makeFavorite = (overrides: Partial<FavoriteSpot> = {}): FavoriteSpot => ({
  spotId: SPOT_ID,
  name: 'Piha',
  region: 'Auckland',
  waveType: 'BeachBreak',
  minSkillLevel: 'Intermediate',
  typicalCrowd: 'Busy',
  currentWaveSize: 'WaistHigh',
  facilities: [],
  description: 'Famous black-sand beach.',
  favoritedAt: new Date().toISOString(),
  ...overrides,
});

beforeEach(() => {
  jest.clearAllMocks();
  mockFetchFavorites.mockResolvedValue([]);
  mockRemoveFavorite.mockResolvedValue(undefined);
});

describe('loading', () => {
  it('starts in loading state', () => {
    mockFetchFavorites.mockReturnValue(new Promise(() => {}));
    const { result } = renderHook(() => useFavoritesViewModel());
    expect(result.current.loading).toBe(true);
  });

  it('loads favorites and clears loading', async () => {
    const fav = makeFavorite();
    mockFetchFavorites.mockResolvedValue([fav]);
    let result: ReturnType<typeof renderHook<ReturnType<typeof useFavoritesViewModel>, unknown>>['result'];
    await act(async () => {
      ({ result } = renderHook(() => useFavoritesViewModel()));
    });
    expect(result!.current.loading).toBe(false);
    expect(result!.current.favorites).toEqual([fav]);
  });

  it('sets error and clears loading on fetch failure', async () => {
    mockFetchFavorites.mockRejectedValue(new Error('Network error'));
    let result: ReturnType<typeof renderHook<ReturnType<typeof useFavoritesViewModel>, unknown>>['result'];
    await act(async () => {
      ({ result } = renderHook(() => useFavoritesViewModel()));
    });
    expect(result!.current.loading).toBe(false);
    expect(result!.current.error).toBe('Failed to load favourites');
  });
});

describe('handleRemove', () => {
  it('optimistically removes the spot from the list', async () => {
    mockFetchFavorites.mockResolvedValue([makeFavorite()]);
    let result: ReturnType<typeof renderHook<ReturnType<typeof useFavoritesViewModel>, unknown>>['result'];
    await act(async () => {
      ({ result } = renderHook(() => useFavoritesViewModel()));
    });
    act(() => { result!.current.handleRemove(SPOT_ID); });
    expect(result!.current.favorites).toHaveLength(0);
  });

  it('re-fetches and restores list when remove API call fails', async () => {
    const fav = makeFavorite();
    mockFetchFavorites.mockResolvedValue([fav]);
    mockRemoveFavorite.mockRejectedValue(new Error('Network error'));
    let result: ReturnType<typeof renderHook<ReturnType<typeof useFavoritesViewModel>, unknown>>['result'];
    await act(async () => {
      ({ result } = renderHook(() => useFavoritesViewModel()));
    });
    await act(async () => { result!.current.handleRemove(SPOT_ID); });
    expect(result!.current.favorites).toEqual([fav]);
  });
});
