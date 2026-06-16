'use client';

import AnswerButton from '@/components/ui/AnswerButton';
import type { Question } from '@/lib/questions';
import styles from './QuestionScreen.module.css';

interface QuestionScreenProps {
  question: Question;
  value: string | string[];
  onChange: (value: string | string[]) => void;
}

const QuestionScreen = ({ question, value, onChange }: QuestionScreenProps) => {
  const handleSelect = (optionValue: string) => {
    if (question.multiSelect) {
      const current = value as string[];
      const next = current.includes(optionValue)
        ? current.filter((v) => v !== optionValue)
        : [...current, optionValue];
      onChange(next);
    } else {
      // toggling a selected single-select clears it (optional questions only)
      onChange(value === optionValue ? '' : optionValue);
    }
  };

  const isSelected = (optionValue: string) =>
    question.multiSelect
      ? (value as string[]).includes(optionValue)
      : value === optionValue;

  return (
    <div className={styles.root}>
      <div className={styles.header}>
        <h2 className={styles.title}>{question.title}</h2>
        <p className={styles.subtitle}>{question.subtitle}</p>
      </div>
      <div className={styles.options}>
        {question.options.map((option) => (
          <AnswerButton
            key={option.value}
            label={option.label}
            selected={isSelected(option.value)}
            onClick={() => handleSelect(option.value)}
          />
        ))}
      </div>
    </div>
  );
};

export default QuestionScreen;
