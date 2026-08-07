/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { useProfileViewModel, formatEnum } from '@/app/profile/profile.viewmodel';
import type { Profile, UserPreferences } from '@/lib/types';

const mockPush = jest.fn();
jest.mock('next/navigation', () => ({
  useRouter: () => ({ push: mockPush }),
}));

const mockFetchProfile          = jest.fn();
const mockFetchUserPreferences  = jest.fn();
const mockFetchRecommendations  = jest.fn();
const mockUpdateProfile         = jest.fn();
jest.mock('../../../lib/api', () => ({
  ...jest.requireActual('../../../lib/api'),
  fetchProfile:           (...args: unknown[]) => mockFetchProfile(...args),
  fetchUserPreferences:   (...args: unknown[]) => mockFetchUserPreferences(...args),
  fetchRecommendations:   (...args: unknown[]) => mockFetchRecommendations(...args),
  updateProfile:          (...args: unknown[]) => mockUpdateProfile(...args),
}));

let mockUser: object | null = { id: 'user-1' };
jest.mock('../../../lib/AuthContext', () => ({
  useAuth: () => ({ user: mockUser }),
}));

const FAKE_PROFILE: Profile = {
  id: 'user-1',
  email: 'tamar@example.com',
  displayName: 'Tamar',
  avatarUrl: null,
  location: 'Auckland',
  bio: 'Loves big waves',
  instagramHandle: 'tamar_surfs',
  tikTokHandle: null,
};

const FAKE_PREFS: UserPreferences = {
  skillLevel: 'Intermediate',
  crowdTolerance: 'Quiet',
  preferredRegions: [],
  boardTypes: ['Shortboard'],
  preferredWaveTypes: ['BeachBreak'],
  preferredWaveSizes: ['WaistHigh'],
  preferredFacilities: [],
};

beforeEach(() => {
  jest.clearAllMocks();
  mockUser = { id: 'user-1' };
  sessionStorage.clear();
  mockUpdateProfile.mockResolvedValue(FAKE_PROFILE);
});

describe('useProfileViewModel — load', () => {
  it('fetches profile and preferences on mount', async () => {
    mockFetchProfile.mockResolvedValue(FAKE_PROFILE);
    mockFetchUserPreferences.mockResolvedValue(FAKE_PREFS);

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});

    expect(result.current.profile).toMatchObject({ displayName: 'Tamar', location: 'Auckland' });
    expect(result.current.preferences).toEqual(FAKE_PREFS);
    expect(result.current.loading).toBe(false);
  });

  it('seeds location from first quiz region (raw enum value) when profile.location is null', async () => {
    mockFetchProfile.mockResolvedValue({ ...FAKE_PROFILE, location: null });
    mockFetchUserPreferences.mockResolvedValue({ ...FAKE_PREFS, preferredRegions: ['BayOfPlenty'] });

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});

    // Raw enum value matches the <select> option values in ProfileCard.
    expect(result.current.profile?.location).toBe('BayOfPlenty');
  });

  it('seeds location when profile.location is empty string (new-user backend default)', async () => {
    // The backend initialises UserEntity.Location to "" — not null — so ?? would
    // not fall through to the seeded value. We use || to handle this case.
    mockFetchProfile.mockResolvedValue({ ...FAKE_PROFILE, location: '' });
    mockFetchUserPreferences.mockResolvedValue({ ...FAKE_PREFS, preferredRegions: ['BayOfPlenty'] });

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});

    expect(result.current.profile?.location).toBe('BayOfPlenty');
  });

  it('persists seeded location when profile.location is empty string', async () => {
    mockFetchProfile.mockResolvedValue({ ...FAKE_PROFILE, location: '' });
    mockFetchUserPreferences.mockResolvedValue({ ...FAKE_PREFS, preferredRegions: ['Auckland'] });

    renderHook(() => useProfileViewModel());
    await act(async () => {});

    expect(mockUpdateProfile).toHaveBeenCalledWith(expect.objectContaining({ location: 'Auckland' }));
  });

  it('persists seeded location via updateProfile', async () => {
    mockFetchProfile.mockResolvedValue({ ...FAKE_PROFILE, location: null });
    mockFetchUserPreferences.mockResolvedValue({ ...FAKE_PREFS, preferredRegions: ['Auckland'] });

    renderHook(() => useProfileViewModel());
    await act(async () => {});

    expect(mockUpdateProfile).toHaveBeenCalledWith(expect.objectContaining({ location: 'Auckland' }));
  });

  it('does not call updateProfile when profile already has a location', async () => {
    mockFetchProfile.mockResolvedValue({ ...FAKE_PROFILE, location: 'Northland' });
    mockFetchUserPreferences.mockResolvedValue({ ...FAKE_PREFS, preferredRegions: ['Auckland'] });

    renderHook(() => useProfileViewModel());
    await act(async () => {});

    expect(mockUpdateProfile).not.toHaveBeenCalled();
  });

  it('does not call updateProfile when preferredRegions is empty', async () => {
    mockFetchProfile.mockResolvedValue({ ...FAKE_PROFILE, location: null });
    mockFetchUserPreferences.mockResolvedValue({ ...FAKE_PREFS, preferredRegions: [] });

    renderHook(() => useProfileViewModel());
    await act(async () => {});

    expect(mockUpdateProfile).not.toHaveBeenCalled();
  });

  it('sets preferences to null when fetchUserPreferences returns 404', async () => {
    mockFetchProfile.mockResolvedValue(FAKE_PROFILE);
    mockFetchUserPreferences.mockRejectedValue(new Error('404'));

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});

    expect(result.current.preferences).toBeNull();
    expect(result.current.loading).toBe(false);
  });

  it('redirects to / when not logged in', async () => {
    mockUser = null;
    renderHook(() => useProfileViewModel());
    await act(async () => {});
    expect(mockPush).toHaveBeenCalledWith('/');
  });

  it('redirects to / when fetchProfile fails', async () => {
    mockFetchProfile.mockRejectedValue(new Error('401'));
    mockFetchUserPreferences.mockRejectedValue(new Error('404'));

    renderHook(() => useProfileViewModel());
    await act(async () => {});
    expect(mockPush).toHaveBeenCalledWith('/');
  });
});

describe('useProfileViewModel — handleFindWave', () => {
  it('fetches recommendations and navigates to /results', async () => {
    mockFetchProfile.mockResolvedValue(FAKE_PROFILE);
    mockFetchUserPreferences.mockResolvedValue(FAKE_PREFS);
    mockFetchRecommendations.mockResolvedValue({ recommendations: [], preferences: FAKE_PREFS, warnings: [] });

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});
    await act(async () => { await result.current.handleFindWave(); });

    expect(mockFetchRecommendations).toHaveBeenCalledWith(FAKE_PREFS);
    expect(mockPush).toHaveBeenCalledWith('/results');
  });

  it('redirects to /quiz when no preferences saved', async () => {
    mockFetchProfile.mockResolvedValue(FAKE_PROFILE);
    mockFetchUserPreferences.mockRejectedValue(new Error('404'));

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});
    await act(async () => { await result.current.handleFindWave(); });

    expect(mockPush).toHaveBeenCalledWith('/quiz');
  });
});

describe('formatEnum', () => {
  it.each([
    ['WaistHigh', 'Waist High'],
    ['BeachBreak', 'Beach Break'],
    ['NewToSurfing', 'New To Surfing'],
    ['BayOfPlenty', 'Bay Of Plenty'],
    ['Intermediate', 'Intermediate'],
  ])('%s → %s', (input, expected) => {
    expect(formatEnum(input)).toBe(expected);
  });
});
