'use client';

import { useState, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import { fetchRecommendations, fetchUserPreferences, saveUserPreferences } from '@/lib/api';
import { useAuth } from '@/lib/AuthContext';
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
  preferredRegions: string[];
  boardTypes: string[];
  preferredWaveTypes: string[];
  preferredWaveSizes: string[];
  preferredFacilities: string[];
};

export const INITIAL_ANSWERS: Answers = {
  skillLevel: '',
  crowdTolerance: '',
  preferredRegions: [],
  boardTypes: [],
  preferredWaveTypes: [],
  preferredWaveSizes: [],
  preferredFacilities: [],
};

export const buildPreferences = (answers: Answers): UserPreferences => ({
  skillLevel:          answers.skillLevel as SkillLevel,
  crowdTolerance:      answers.crowdTolerance as CrowdLevel,
  preferredRegions:    answers.preferredRegions as Region[],
  boardTypes:          answers.boardTypes as BoardType[],
  preferredWaveTypes:  answers.preferredWaveTypes as WaveType[],
  preferredWaveSizes:  answers.preferredWaveSizes as WaveSize[],
  preferredFacilities: answers.preferredFacilities.filter((f) => f !== 'None') as Facility[],
});

export const prefsToAnswers = (prefs: UserPreferences): Answers => ({
  skillLevel:          prefs.skillLevel,
  crowdTolerance:      prefs.crowdTolerance,
  preferredRegions:    [...prefs.preferredRegions],
  boardTypes:          [...prefs.boardTypes],
  preferredWaveTypes:  [...prefs.preferredWaveTypes],
  preferredWaveSizes:  [...prefs.preferredWaveSizes],
  preferredFacilities: [...prefs.preferredFacilities],
});

export const useQuizViewModel = () => {
  const router = useRouter();
  const { user } = useAuth();
  const [step, setStep]               = useState(0);
  const [answers, setAnswers]         = useState<Answers>(INITIAL_ANSWERS);
  const [loading, setLoading]         = useState(false);
  const [prefillLoading, setPrefillLoading] = useState(false);
  const [error, setError]             = useState<string | null>(null);

  // Pre-fill quiz from saved preferences when the user is logged in.
  useEffect(() => {
    if (!user) return;
    setPrefillLoading(true);
    fetchUserPreferences()
      .then((prefs) => setAnswers(prefsToAnswers(prefs)))
      .catch(() => { /* 404 or network error — start blank */ })
      .finally(() => setPrefillLoading(false));
  }, [user]);

  const question       = QUESTIONS[step];
  const isLastStep     = step === QUESTIONS.length - 1;
  const value          = answers[question.field as keyof Answers];
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
      const prefs = buildPreferences(answers);
      const data = await fetchRecommendations(prefs);
      // Save preferences for logged-in users; don't block navigation on failure.
      if (user) await saveUserPreferences(prefs).catch(() => {});
      sessionStorage.setItem('surfmatch_results', JSON.stringify(data));
      router.push('/results');
    } catch {
      setError('Could not reach the server. Is the backend running?');
      setLoading(false);
    }
  };

  return { question, step, value, loading, prefillLoading, error, isLastStep, isNextDisabled, nextLabel, handleChange, handleBack, handleNext };
};
