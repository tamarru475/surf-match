'use client';

import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { fetchRecommendations } from '@/lib/api';
import { QUESTIONS } from '@/lib/questions';
import type { Question } from '@/lib/questions';
import type {
  BoardType,
  CrowdLevel,
  Facility,
  Region,
  SkillLevel,
  UserPreferences,
  WaveSize,
  WaveType,
} from '@/lib/types';

export const isQuestionAnswered = (question: Question, value: string | string[]): boolean => {
  if (!question.required) return true;
  return Array.isArray(value) ? value.length > 0 : Boolean(value);
};

export const getNextLabel = (question: Question, value: string | string[], isLastStep: boolean): string => {
  if (isLastStep) return 'Find my spot';
  const hasValue = Array.isArray(value) ? value.length > 0 : Boolean(value);
  return !question.required && !hasValue ? 'Skip' : 'Next';
};

export type Answers = {
  skillLevel: string;
  crowdTolerance: string;
  preferredRegion: string;
  boardTypes: string[];
  preferredWaveTypes: string[];
  preferredWaveSizes: string[];
  preferredFacilities: string[];
};

export const INITIAL_ANSWERS: Answers = {
  skillLevel: '',
  crowdTolerance: '',
  preferredRegion: '',
  boardTypes: [],
  preferredWaveTypes: [],
  preferredWaveSizes: [],
  preferredFacilities: [],
};

export const buildPreferences = (answers: Answers): UserPreferences => ({
  skillLevel:          answers.skillLevel as SkillLevel,
  crowdTolerance:      answers.crowdTolerance as CrowdLevel,
  preferredRegion:     answers.preferredRegion && answers.preferredRegion !== 'Anywhere'
                          ? (answers.preferredRegion as Region)
                          : undefined,
  boardTypes:          answers.boardTypes as BoardType[],
  preferredWaveTypes:  answers.preferredWaveTypes as WaveType[],
  preferredWaveSizes:  answers.preferredWaveSizes as WaveSize[],
  preferredFacilities: answers.preferredFacilities.filter((f) => f !== 'None') as Facility[],
});

export const useQuizViewModel = () => {
  const router = useRouter();
  const [step, setStep]       = useState(0);
  const [answers, setAnswers] = useState<Answers>(INITIAL_ANSWERS);
  const [loading, setLoading] = useState(false);
  const [error, setError]     = useState<string | null>(null);

  const question      = QUESTIONS[step];
  const isLastStep    = step === QUESTIONS.length - 1;
  const value         = answers[question.field as keyof Answers];
  const isNextDisabled = !isQuestionAnswered(question, value);
  const nextLabel      = getNextLabel(question, value, isLastStep);

  const handleChange = (next: string | string[]) =>
    setAnswers((prev) => ({ ...prev, [question.field]: next }));

  const handleBack = () => (step === 0 ? router.push('/') : setStep((s) => s - 1));

  const handleNext = async () => {
    if (!isLastStep) { setStep((s) => s + 1); return; }

    setLoading(true);
    setError(null);

    try {
      const data = await fetchRecommendations(buildPreferences(answers));
      sessionStorage.setItem('surfmatch_results', JSON.stringify(data));
      router.push('/results');
    } catch {
      setError('Could not reach the server. Is the backend running?');
      setLoading(false);
    }
  };

  return { question, step, value, loading, error, isLastStep, isNextDisabled, nextLabel, handleChange, handleBack, handleNext };
};
