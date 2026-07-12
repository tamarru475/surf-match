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
const mockUpdateProfile         = jest.fn();
const mockFetchUserPreferences  = jest.fn();
const mockFetchRecommendations  = jest.fn();
jest.mock('../lib/api', () => ({
  ...jest.requireActual('../lib/api'),
  fetchProfile:           (...args: unknown[]) => mockFetchProfile(...args),
  updateProfile:          (...args: unknown[]) => mockUpdateProfile(...args),
  fetchUserPreferences:   (...args: unknown[]) => mockFetchUserPreferences(...args),
  fetchRecommendations:   (...args: unknown[]) => mockFetchRecommendations(...args),
}));

let mockUser: object | null = { id: 'user-1' };
jest.mock('../lib/AuthContext', () => ({
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
  boardTypes: ['Shortboard'],
  preferredWaveTypes: ['BeachBreak'],
  preferredWaveSizes: ['WaistHigh'],
  preferredFacilities: [],
};

beforeEach(() => {
  jest.clearAllMocks();
  mockUser = { id: 'user-1' };
  sessionStorage.clear();
});

describe('useProfileViewModel — load', () => {
  it('fetches profile and preferences on mount', async () => {
    mockFetchProfile.mockResolvedValue(FAKE_PROFILE);
    mockFetchUserPreferences.mockResolvedValue(FAKE_PREFS);

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});

    expect(result.current.displayName).toBe('Tamar');
    expect(result.current.location).toBe('Auckland');
    expect(result.current.bio).toBe('Loves big waves');
    expect(result.current.instagramHandle).toBe('tamar_surfs');
    expect(result.current.tikTokHandle).toBe('');
    expect(result.current.preferences).toEqual(FAKE_PREFS);
    expect(result.current.loading).toBe(false);
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

describe('useProfileViewModel — dirty state', () => {
  it('isDirty is false after load', async () => {
    mockFetchProfile.mockResolvedValue(FAKE_PROFILE);
    mockFetchUserPreferences.mockResolvedValue(FAKE_PREFS);

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});

    expect(result.current.isDirty).toBe(false);
  });

  it('isDirty is true when a field is changed', async () => {
    mockFetchProfile.mockResolvedValue(FAKE_PROFILE);
    mockFetchUserPreferences.mockResolvedValue(FAKE_PREFS);

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});
    await act(async () => { result.current.setDisplayName('Someone Else'); });

    expect(result.current.isDirty).toBe(true);
  });

  it('isDirty resets to false after save', async () => {
    mockFetchProfile.mockResolvedValue(FAKE_PROFILE);
    mockFetchUserPreferences.mockResolvedValue(FAKE_PREFS);
    mockUpdateProfile.mockResolvedValue({ ...FAKE_PROFILE, displayName: 'New Name' });

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});
    await act(async () => { result.current.setDisplayName('New Name'); });
    await act(async () => { await result.current.handleSave(); });

    expect(result.current.isDirty).toBe(false);
    expect(result.current.saveSuccess).toBe(true);
  });
});

describe('useProfileViewModel — save', () => {
  it('calls updateProfile with trimmed values and sets saveSuccess', async () => {
    mockFetchProfile.mockResolvedValue(FAKE_PROFILE);
    mockFetchUserPreferences.mockResolvedValue(FAKE_PREFS);
    mockUpdateProfile.mockResolvedValue({ ...FAKE_PROFILE, displayName: 'Tamar R' });

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});
    await act(async () => { result.current.setDisplayName('  Tamar R  '); });
    await act(async () => { await result.current.handleSave(); });

    expect(mockUpdateProfile).toHaveBeenCalledWith(expect.objectContaining({ displayName: 'Tamar R' }));
    expect(result.current.saveSuccess).toBe(true);
  });

  it('sets error when updateProfile fails', async () => {
    mockFetchProfile.mockResolvedValue(FAKE_PROFILE);
    mockFetchUserPreferences.mockResolvedValue(FAKE_PREFS);
    mockUpdateProfile.mockRejectedValue(new Error('500'));

    const { result } = renderHook(() => useProfileViewModel());
    await act(async () => {});
    await act(async () => { await result.current.handleSave(); });

    expect(result.current.error).toBe('Failed to save. Please try again.');
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
