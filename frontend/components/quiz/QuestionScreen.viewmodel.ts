'use client';

import { useState } from 'react';
import type { Question } from '@/lib/questions';

export const isOptionSelected = (
  question: Question,
  value: string | string[],
  optionValue: string,
): boolean =>
  question.multiSelect
    ? (value as string[]).includes(optionValue)
    : value === optionValue;

export const getNextSelection = (
  question: Question,
  value: string | string[],
  optionValue: string,
): string | string[] => {
  if (!question.multiSelect) {
    // toggling a selected single-select clears it (optional questions only)
    return value === optionValue ? '' : optionValue;
  }

  const current = value as string[];

  // The "none" option (e.g. "No facilities needed") is mutually exclusive
  // with every other option in the list.
  if (question.noneValue && optionValue === question.noneValue) {
    return current.includes(optionValue) ? [] : [optionValue];
  }

  const withoutNone = question.noneValue
    ? current.filter((v) => v !== question.noneValue)
    : current;

  return withoutNone.includes(optionValue)
    ? withoutNone.filter((v) => v !== optionValue)
    : [...withoutNone, optionValue];
};

export const useQuestionScreenViewModel = (
  question: Question,
  value: string | string[],
  onChange: (value: string | string[]) => void,
) => {
  const [showInfoModal, setShowInfoModal] = useState(false);

  return {
    showInfoModal,
    openInfoModal: () => setShowInfoModal(true),
    closeInfoModal: () => setShowInfoModal(false),
    hasTooltip: Boolean(question.tooltip || question.tooltipTerms || question.tooltipWarning),
    hasInfoModal: Boolean(question.tooltipItems),
    isSelected: (optionValue: string) => isOptionSelected(question, value, optionValue),
    handleSelect: (optionValue: string) => onChange(getNextSelection(question, value, optionValue)),
  };
};
