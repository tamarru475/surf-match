/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { useSkillCheckModalViewModel } from '@/components/quiz/SkillCheckModal.viewmodel';
import { SKILL_QUESTIONS } from '@/lib/skill-quiz';

const setup = (onComplete = jest.fn()) =>
  renderHook(() => useSkillCheckModalViewModel(onComplete));

describe('initial state', () => {
  it('starts in quiz phase on question 0', () => {
    const { result } = setup();
    expect(result.current.phase).toBe('quiz');
    expect(result.current.questionIndex).toBe(0);
    expect(result.current.question).toBe(SKILL_QUESTIONS[0]);
  });
});

describe('handleNo', () => {
  it('transitions to result phase and sets determinedLevel', () => {
    const { result } = setup();
    act(() => result.current.handleNo());
    expect(result.current.phase).toBe('result');
    expect(result.current.determinedLevel).toBe('NewToSurfing');
  });
});

describe('handleYes', () => {
  it('advances to the next question', () => {
    const { result } = setup();
    act(() => result.current.handleYes());
    expect(result.current.phase).toBe('quiz');
    expect(result.current.questionIndex).toBe(1);
  });

  it('resolves Expert after answering Yes to all questions', async () => {
    const onComplete = jest.fn();
    const { result } = setup(onComplete);
    for (let i = 0; i < SKILL_QUESTIONS.length; i++) {
      act(() => result.current.handleYes());
    }
    expect(result.current.phase).toBe('result');
    expect(result.current.determinedLevel).toBe('Expert');
  });
});

describe('handleSave', () => {
  it('calls onComplete with the determined level', () => {
    const onComplete = jest.fn();
    const { result } = setup(onComplete);
    act(() => result.current.handleNo()); // determines NewToSurfing
    act(() => result.current.handleSave());
    expect(onComplete).toHaveBeenCalledWith('NewToSurfing');
  });
});

describe('handleRetake', () => {
  it('resets to quiz phase at question 0', () => {
    const { result } = setup();
    act(() => result.current.handleYes()); // advance to q1
    act(() => result.current.handleNo());  // go to result
    act(() => result.current.handleRetake());
    expect(result.current.phase).toBe('quiz');
    expect(result.current.questionIndex).toBe(0);
    expect(result.current.determinedLevel).toBeNull();
  });
});
