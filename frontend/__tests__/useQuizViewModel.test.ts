/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { useQuizViewModel } from '@/app/quiz/quiz.viewmodel';
import { QUESTIONS } from '@/lib/questions';

const LAST_STEP = QUESTIONS.length - 1;

const mockPush = jest.fn();
jest.mock('next/navigation', () => ({
  useRouter: () => ({ push: mockPush }),
}));

const mockFetch = jest.fn();
jest.mock('../lib/api', () => ({
  ...jest.requireActual('../lib/api'),
  fetchRecommendations: (...args: unknown[]) => mockFetch(...args),
}));

const FAKE_RESPONSE = { recommendations: [], preferences: {}, warnings: [] };

// Advance the hook from step 0 to the last step.
async function advanceToLastStep(result: { current: ReturnType<typeof useQuizViewModel> }) {
  for (let i = 0; i < LAST_STEP; i++) {
    await act(async () => { result.current.handleNext(); });
  }
}

beforeEach(() => {
  jest.clearAllMocks();
  sessionStorage.clear();
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
    mockFetch.mockResolvedValue(FAKE_RESPONSE);

    const { result } = renderHook(() => useQuizViewModel());
    await advanceToLastStep(result);
    await act(async () => { await result.current.handleNext(); });

    expect(mockFetch).toHaveBeenCalledTimes(1);
    expect(sessionStorage.getItem('surfmatch_results')).toBe(JSON.stringify(FAKE_RESPONSE));
    expect(mockPush).toHaveBeenCalledWith('/results');
  });

  it('sets error state and clears loading on API failure', async () => {
    mockFetch.mockRejectedValue(new Error('network down'));

    const { result } = renderHook(() => useQuizViewModel());
    await advanceToLastStep(result);
    await act(async () => { await result.current.handleNext(); });

    expect(result.current.error).toBe('Could not reach the server. Is the backend running?');
    expect(result.current.loading).toBe(false);
  });

  it('does not navigate to /results on failure', async () => {
    mockFetch.mockRejectedValue(new Error('fail'));

    const { result } = renderHook(() => useQuizViewModel());
    await advanceToLastStep(result);
    await act(async () => { await result.current.handleNext(); });

    expect(mockPush).not.toHaveBeenCalledWith('/results');
  });
});

describe('useQuizViewModel — derived state', () => {
  it('isNextDisabled is true when a required question has no answer', () => {
    const { result } = renderHook(() => useQuizViewModel());
    // step 0 is required (skill level), initial value is ''
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
