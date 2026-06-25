import { buildPreferences, getNextLabel, INITIAL_ANSWERS, isQuestionAnswered } from '@/app/quiz/quiz.viewmodel';
import type { Question } from '@/lib/questions';

// ── INITIAL_ANSWERS ───────────────────────────────────────────────────────────

describe('INITIAL_ANSWERS', () => {
  it('has empty strings for required single-select fields', () => {
    expect(INITIAL_ANSWERS.skillLevel).toBe('');
    expect(INITIAL_ANSWERS.crowdTolerance).toBe('');
    expect(INITIAL_ANSWERS.preferredRegion).toBe('');
  });

  it('has empty arrays for multi-select fields', () => {
    expect(INITIAL_ANSWERS.boardTypes).toEqual([]);
    expect(INITIAL_ANSWERS.preferredWaveTypes).toEqual([]);
    expect(INITIAL_ANSWERS.preferredWaveSizes).toEqual([]);
    expect(INITIAL_ANSWERS.preferredFacilities).toEqual([]);
  });
});

// ── buildPreferences ──────────────────────────────────────────────────────────

describe('buildPreferences', () => {
  const answers = {
    ...INITIAL_ANSWERS,
    skillLevel: 'Intermediate',
    crowdTolerance: 'Moderate',
    preferredRegion: 'Auckland',
    boardTypes: ['Longboard', 'Fish'],
  };

  it('maps skill level and crowd tolerance', () => {
    const prefs = buildPreferences(answers);
    expect(prefs.skillLevel).toBe('Intermediate');
    expect(prefs.crowdTolerance).toBe('Moderate');
  });

  it('maps preferred region', () => {
    const prefs = buildPreferences(answers);
    expect(prefs.preferredRegion).toBe('Auckland');
  });

  it('maps board types array', () => {
    const prefs = buildPreferences(answers);
    expect(prefs.boardTypes).toEqual(['Longboard', 'Fish']);
  });
});

// ── isQuestionAnswered ────────────────────────────────────────────────────────

const makeQ = (required: boolean, multiSelect: boolean): Question => ({
  field: 'test', title: '', subtitle: '', required, multiSelect, options: [],
});

describe('isQuestionAnswered', () => {
  it('returns false for a required single-select with no value', () => {
    expect(isQuestionAnswered(makeQ(true, false), '')).toBe(false);
  });

  it('returns true for a required single-select with a value', () => {
    expect(isQuestionAnswered(makeQ(true, false), 'Intermediate')).toBe(true);
  });

  it('returns true for an optional single-select with no value (skippable)', () => {
    expect(isQuestionAnswered(makeQ(false, false), '')).toBe(true);
  });

  it('returns false for a required multi-select with an empty array', () => {
    expect(isQuestionAnswered(makeQ(true, true), [])).toBe(false);
  });

  it('returns true for a required multi-select with at least one value', () => {
    expect(isQuestionAnswered(makeQ(true, true), ['Fish'])).toBe(true);
  });

  it('returns true for an optional multi-select with an empty array (skippable)', () => {
    expect(isQuestionAnswered(makeQ(false, true), [])).toBe(true);
  });
});

// ── getNextLabel ──────────────────────────────────────────────────────────────

describe('getNextLabel', () => {
  it('returns "Find my spot" on the last step regardless of answer state', () => {
    expect(getNextLabel(makeQ(true, false), '', true)).toBe('Find my spot');
    expect(getNextLabel(makeQ(false, true), [], true)).toBe('Find my spot');
  });

  it('returns "Skip" for an unanswered optional question that is not the last step', () => {
    expect(getNextLabel(makeQ(false, false), '', false)).toBe('Skip');
    expect(getNextLabel(makeQ(false, true), [], false)).toBe('Skip');
  });

  it('returns "Next" for an answered question that is not the last step', () => {
    expect(getNextLabel(makeQ(false, false), 'Auckland', false)).toBe('Next');
    expect(getNextLabel(makeQ(true, false), 'Intermediate', false)).toBe('Next');
  });

  it('returns "Next" for a required, unanswered question (button is disabled, but label stays Next)', () => {
    expect(getNextLabel(makeQ(true, false), '', false)).toBe('Next');
  });
});
