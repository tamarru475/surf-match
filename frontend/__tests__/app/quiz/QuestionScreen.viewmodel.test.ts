import { getNextSelection, isOptionSelected } from '@/components/quiz/QuestionScreen.viewmodel';
import type { Question } from '@/lib/questions';

const singleSelect: Question = {
  field: 'skillLevel', title: '', subtitle: '', required: true, multiSelect: false, options: [],
};

const multiSelect: Question = {
  field: 'boardTypes', title: '', subtitle: '', required: false, multiSelect: true, options: [],
};

const multiSelectWithNone: Question = {
  field: 'preferredFacilities', title: '', subtitle: '', required: false, multiSelect: true,
  noneValue: 'None', options: [],
};

describe('isOptionSelected', () => {
  it('checks equality for single-select questions', () => {
    expect(isOptionSelected(singleSelect, 'Beginner', 'Beginner')).toBe(true);
    expect(isOptionSelected(singleSelect, 'Beginner', 'Expert')).toBe(false);
  });

  it('checks array membership for multi-select questions', () => {
    expect(isOptionSelected(multiSelect, ['Fish', 'Longboard'], 'Fish')).toBe(true);
    expect(isOptionSelected(multiSelect, ['Fish'], 'Longboard')).toBe(false);
  });
});

describe('getNextSelection — single-select', () => {
  it('selects an unselected option', () => {
    expect(getNextSelection(singleSelect, '', 'Beginner')).toBe('Beginner');
  });

  it('toggling the already-selected option clears it', () => {
    expect(getNextSelection(singleSelect, 'Beginner', 'Beginner')).toBe('');
  });
});

describe('getNextSelection — multi-select without noneValue', () => {
  it('adds an unselected option', () => {
    expect(getNextSelection(multiSelect, [], 'Fish')).toEqual(['Fish']);
  });

  it('removes an already-selected option', () => {
    expect(getNextSelection(multiSelect, ['Fish'], 'Fish')).toEqual([]);
  });

  it('keeps existing selections when adding another', () => {
    expect(getNextSelection(multiSelect, ['Fish'], 'Longboard')).toEqual(['Fish', 'Longboard']);
  });
});

describe('getNextSelection — multi-select with noneValue', () => {
  it('selecting "None" replaces any existing selection', () => {
    expect(getNextSelection(multiSelectWithNone, ['Bathrooms'], 'None')).toEqual(['None']);
  });

  it('selecting "None" again deselects it', () => {
    expect(getNextSelection(multiSelectWithNone, ['None'], 'None')).toEqual([]);
  });

  it('selecting a real option removes "None" from the result', () => {
    expect(getNextSelection(multiSelectWithNone, ['None'], 'Bathrooms')).toEqual(['Bathrooms']);
  });

  it('selecting a second real option keeps both, with no "None"', () => {
    expect(getNextSelection(multiSelectWithNone, ['Bathrooms'], 'Showers')).toEqual(['Bathrooms', 'Showers']);
  });
});
