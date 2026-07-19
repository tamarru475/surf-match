/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { useQuizViewModel, prefsToAnswers, INITIAL_ANSWERS } from '@/app/quiz/quiz.viewmodel';
import { QUESTIONS } from '@/lib/questions';
import type { UserPreferences } from '@/lib/types';

const LAST_STEP = QUESTIONS.length - 1;

const mockPush = jest.fn();
jest.mock('next/navigation', () => ({
  useRouter: () => ({ push: mockPush }),
}));

const mockFetchRecommendations = jest.fn();
const mockFetchUserPreferences = jest.fn();
const mockSaveUserPreferences  = jest.fn();
jest.mock('../../../lib/api', () => ({
  ...jest.requireActual('../../../lib/api'),
  fetchRecommendations:  (...args: unknown[]) => mockFetchRecommendations(...args),
  fetchUserPreferences:  (...args: unknown[]) => mockFetchUserPreferences(...args),
  saveUserPreferences:   (...args: unknown[]) => mockSaveUserPreferences(...args),
}));

// Default: guest (not logged in). Override per-test to simulate logged-in user.
let mockUser: object | null = null;
jest.mock('../../../lib/AuthContext', () => ({
  useAuth: () => ({ user: mockUser }),
}));

const FAKE_RESPONSE = { recommendations: [], preferences: {}, warnings: [] };

const SAVED_PREFS: UserPreferences = {
  skillLevel: 'Advanced',
  crowdTolerance: 'Quiet',
  preferredRegion: 'Wellington',
  boardTypes: ['Shortboard'],
  preferredWaveTypes: ['ReefBreak'],
  preferredWaveSizes: ['HeadHigh'],
  preferredFacilities: [],
};

// Advance the hook from step 0 to the last step.
async function advanceToLastStep(result: { current: ReturnType<typeof useQuizViewModel> }) {
  for (let i = 0; i < LAST_STEP; i++) {
    await act(async () => { result.current.handleNext(); });
  }
}

beforeEach(() => {
  jest.clearAllMocks();
  sessionStorage.clear();
  mockUser = null;
});

describe('useQuizViewModel — navigation', () => {
  it('starts at step 0', () => {
    const { result } = renderHook(() => useQuizViewModel());
    expect(result.current.step).toBe(0);
  });

  it('handleNext advances to the next step when not on the last step', async () => {
    const { result } = renderHook(() => useQuizViewModel());
    await act(async () => { result.current.handleNext(); });
    expect(result.current.step).toBe(1);
  });

  it('handleBack on step 0 navigates to /', async () => {
    const { result } = renderHook(() => useQuizViewModel());
    await act(async () => { result.current.handleBack(); });
    expect(mockPush).toHaveBeenCalledWith('/');
  });

  it('handleBack on step > 0 decrements the step', async () => {
    const { result } = renderHook(() => useQuizViewModel());
    await act(async () => { result.current.handleNext(); });
    await act(async () => { result.current.handleBack(); });
    expect(result.current.step).toBe(0);
  });
});

describe('useQuizViewModel — handleChange', () => {
  it('updates the current question field answer', async () => {
    const { result } = renderHook(() => useQuizViewModel());
    await act(async () => { result.current.handleChange('Intermediate'); });
    expect(result.current.value).toBe('Intermediate');
  });
});

describe('useQuizViewModel — submit (last step)', () => {
  it('calls fetchRecommendations, saves to sessionStorage, and navigates to /results on success', async () => {
    mockFetchRecommendations.mockResolvedValue(FAKE_RESPONSE);

    const { result } = renderHook(() => useQuizViewModel());
    await advanceToLastStep(result);
    await act(async () => { await result.current.handleNext(); });

    expect(mockFetchRecommendations).toHaveBeenCalledTimes(1);
    expect(sessionStorage.getItem('surfmatch_results')).toBe(JSON.stringify(FAKE_RESPONSE));
    expect(mockPush).toHaveBeenCalledWith('/results');
  });

  it('sets error state and clears loading on API failure', async () => {
    mockFetchRecommendations.mockRejectedValue(new Error('network down'));

    const { result } = renderHook(() => useQuizViewModel());
    await advanceToLastStep(result);
    await act(async () => { await result.current.handleNext(); });

    expect(result.current.error).toBe('Could not reach the server. Is the backend running?');
    expect(result.current.loading).toBe(false);
  });

  it('does not navigate to /results on failure', async () => {
    mockFetchRecommendations.mockRejectedValue(new Error('fail'));

    const { result } = renderHook(() => useQuizViewModel());
    await advanceToLastStep(result);
    await act(async () => { await result.current.handleNext(); });

    expect(mockPush).not.toHaveBeenCalledWith('/results');
  });

  it('does not call saveUserPreferences for guests', async () => {
    mockFetchRecommendations.mockResolvedValue(FAKE_RESPONSE);

    const { result } = renderHook(() => useQuizViewModel());
    await advanceToLastStep(result);
    await act(async () => { await result.current.handleNext(); });

    expect(mockSaveUserPreferences).not.toHaveBeenCalled();
  });

  it('calls saveUserPreferences on submit for logged-in users', async () => {
    mockUser = { id: 'user-1' };
    mockFetchUserPreferences.mockRejectedValue(new Error('404')); // no saved prefs
    mockFetchRecommendations.mockResolvedValue(FAKE_RESPONSE);
    mockSaveUserPreferences.mockResolvedValue(undefined);

    const { result } = renderHook(() => useQuizViewModel());
    await advanceToLastStep(result);
    await act(async () => { await result.current.handleNext(); });

    expect(mockSaveUserPreferences).toHaveBeenCalledTimes(1);
    expect(mockPush).toHaveBeenCalledWith('/results');
  });

  it('still navigates to /results if saveUserPreferences fails', async () => {
    mockUser = { id: 'user-1' };
    mockFetchUserPreferences.mockRejectedValue(new Error('404'));
    mockFetchRecommendations.mockResolvedValue(FAKE_RESPONSE);
    mockSaveUserPreferences.mockRejectedValue(new Error('save failed'));

    const { result } = renderHook(() => useQuizViewModel());
    await advanceToLastStep(result);
    await act(async () => { await result.current.handleNext(); });

    expect(mockPush).toHaveBeenCalledWith('/results');
    expect(result.current.error).toBeNull();
  });
});

describe('useQuizViewModel — pre-fill', () => {
  it('starts with blank answers for guests', () => {
    const { result } = renderHook(() => useQuizViewModel());
    expect(result.current.value).toBe(INITIAL_ANSWERS.skillLevel);
  });

  it('pre-fills answers from saved preferences for logged-in users', async () => {
    mockUser = { id: 'user-1' };
    mockFetchUserPreferences.mockResolvedValue(SAVED_PREFS);

    const { result } = renderHook(() => useQuizViewModel());
    await act(async () => { /* wait for useEffect to resolve */ });

    expect(result.current.value).toBe('Advanced');
  });

  it('starts blank when fetchUserPreferences returns 404', async () => {
    mockUser = { id: 'user-1' };
    mockFetchUserPreferences.mockRejectedValue(new Error('404'));

    const { result } = renderHook(() => useQuizViewModel());
    await act(async () => {});

    expect(result.current.value).toBe('');
  });
});

describe('useQuizViewModel — derived state', () => {
  it('isNextDisabled is true when a required question has no answer', () => {
    const { result } = renderHook(() => useQuizViewModel());
    expect(result.current.isNextDisabled).toBe(true);
  });

  it('isNextDisabled is false once the required question is answered', async () => {
    const { result } = renderHook(() => useQuizViewModel());
    await act(async () => { result.current.handleChange('Beginner'); });
    expect(result.current.isNextDisabled).toBe(false);
  });

  it('isLastStep is true on the final question', async () => {
    const { result } = renderHook(() => useQuizViewModel());
    await advanceToLastStep(result);
    expect(result.current.isLastStep).toBe(true);
  });
});

describe('prefsToAnswers', () => {
  it('round-trips a full preferences object', () => {
    const answers = prefsToAnswers(SAVED_PREFS);
    expect(answers.skillLevel).toBe('Advanced');
    expect(answers.crowdTolerance).toBe('Quiet');
    expect(answers.preferredRegion).toBe('Wellington');
    expect(answers.boardTypes).toEqual(['Shortboard']);
  });

  it('maps undefined preferredRegion to empty string', () => {
    const answers = prefsToAnswers({ ...SAVED_PREFS, preferredRegion: undefined });
    expect(answers.preferredRegion).toBe('');
  });
});
