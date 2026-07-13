/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { usePreferencesViewModel } from '@/app/profile/preferences/preferences.viewmodel';
import type { UserPreferences } from '@/lib/types';

const mockSaveUserPreferences = jest.fn();
jest.mock('../lib/api', () => ({
  ...jest.requireActual('../lib/api'),
  saveUserPreferences: (...args: unknown[]) => mockSaveUserPreferences(...args),
}));

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
});

describe('usePreferencesViewModel — seed state', () => {
  it('seeds preference state from initial prefs', () => {
    const { result } = renderHook(() => usePreferencesViewModel(FAKE_PREFS));

    expect(result.current.skillLevel).toBe('Intermediate');
    expect(result.current.crowdTolerance).toBe('Quiet');
    expect(result.current.boardTypes).toEqual(['Shortboard']);
  });

  it('isPreferencesDirty is false after seeding', () => {
    const { result } = renderHook(() => usePreferencesViewModel(FAKE_PREFS));
    expect(result.current.isPreferencesDirty).toBe(false);
  });
});

describe('usePreferencesViewModel — toggle', () => {
  it('isPreferencesDirty is true after toggling a board type', () => {
    const { result } = renderHook(() => usePreferencesViewModel(FAKE_PREFS));
    act(() => { result.current.toggleBoardType('Longboard'); });

    expect(result.current.boardTypes).toContain('Longboard');
    expect(result.current.isPreferencesDirty).toBe(true);
  });

  it('toggling an active board type removes it', () => {
    const { result } = renderHook(() => usePreferencesViewModel(FAKE_PREFS));
    act(() => { result.current.toggleBoardType('Shortboard'); });

    expect(result.current.boardTypes).not.toContain('Shortboard');
    expect(result.current.isPreferencesDirty).toBe(true);
  });
});

describe('usePreferencesViewModel — save', () => {
  it('handleSavePreferences calls saveUserPreferences and resets dirty state', async () => {
    mockSaveUserPreferences.mockResolvedValue(undefined);

    const { result } = renderHook(() => usePreferencesViewModel(FAKE_PREFS));
    act(() => { result.current.toggleBoardType('Longboard'); });
    await act(async () => { await result.current.handleSavePreferences(); });

    expect(mockSaveUserPreferences).toHaveBeenCalledWith(expect.objectContaining({
      skillLevel: 'Intermediate',
      boardTypes: expect.arrayContaining(['Shortboard', 'Longboard']),
    }));
    expect(result.current.isPreferencesDirty).toBe(false);
    expect(result.current.prefsSaveSuccess).toBe(true);
  });
});
