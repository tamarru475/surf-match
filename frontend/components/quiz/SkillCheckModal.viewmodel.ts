'use client';

import { useState } from 'react';
import { evaluateAnswer, SKILL_QUESTIONS } from '@/lib/skill-quiz';
import type { SkillLevel } from '@/lib/types';

type Phase = 'quiz' | 'result';

export interface SkillCheckModalViewModel {
  phase: Phase;
  question: typeof SKILL_QUESTIONS[number] | null;
  questionIndex: number;
  total: number;
  determinedLevel: SkillLevel | null;
  handleYes: () => void;
  handleNo: () => void;
  handleSave: () => void;
  handleRetake: () => void;
}

export function useSkillCheckModalViewModel(
  onComplete: (level: SkillLevel) => void,
): SkillCheckModalViewModel {
  const [phase, setPhase] = useState<Phase>('quiz');
  const [index, setIndex] = useState(0);
  const [determinedLevel, setDeterminedLevel] = useState<SkillLevel | null>(null);

  const handleAnswer = (yes: boolean) => {
    const result = evaluateAnswer(index, yes);
    if (result !== null) {
      setDeterminedLevel(result);
      setPhase('result');
    } else {
      setIndex(i => i + 1);
    }
  };

  return {
    phase,
    question:        phase === 'quiz' ? SKILL_QUESTIONS[index] : null,
    questionIndex:   index,
    total:           SKILL_QUESTIONS.length,
    determinedLevel,
    handleYes:       () => handleAnswer(true),
    handleNo:        () => handleAnswer(false),
    handleSave:      () => determinedLevel && onComplete(determinedLevel),
    handleRetake:    () => { setPhase('quiz'); setIndex(0); setDeterminedLevel(null); },
  };
}
