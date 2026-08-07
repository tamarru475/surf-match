import { evaluateAnswer, SKILL_QUESTIONS } from '@/lib/skill-quiz';

describe('evaluateAnswer', () => {
  it('returns NewToSurfing when first question answered No', () => {
    expect(evaluateAnswer(0, false)).toBe('NewToSurfing');
  });

  it('returns NewToSurfing when question 1 (down the line) answered No', () => {
    expect(evaluateAnswer(1, false)).toBe('NewToSurfing');
  });

  it('returns Beginner when any question 2–6 answered No', () => {
    for (let i = 2; i <= 6; i++) {
      expect(evaluateAnswer(i, false)).toBe('Beginner');
    }
  });

  it('returns Intermediate when any question 7–12 answered No', () => {
    for (let i = 7; i <= 12; i++) {
      expect(evaluateAnswer(i, false)).toBe('Intermediate');
    }
  });

  it('returns Advanced when any question 13–15 answered No', () => {
    for (let i = 13; i <= 15; i++) {
      expect(evaluateAnswer(i, false)).toBe('Advanced');
    }
  });

  it('returns Expert when the last question is answered Yes', () => {
    expect(evaluateAnswer(SKILL_QUESTIONS.length - 1, true)).toBe('Expert');
  });

  it('returns null when a non-final question is answered Yes', () => {
    expect(evaluateAnswer(0, true)).toBeNull();
    expect(evaluateAnswer(7, true)).toBeNull();
    expect(evaluateAnswer(13, true)).toBeNull();
  });
});
