'use client';

import { Info } from 'lucide-react';
import AnswerButton from '@/components/ui/AnswerButton';
import Tooltip from '@/components/ui/Tooltip';
import InfoModal from '@/components/ui/InfoModal';
import type { Question } from '@/lib/questions';
import { useQuestionScreenViewModel } from './QuestionScreen.viewmodel';
import styles from './QuestionScreen.module.css';

interface QuestionScreenProps {
  question: Question;
  value: string | string[];
  onChange: (value: string | string[]) => void;
}

const QuestionScreen = ({ question, value, onChange }: QuestionScreenProps) => {
  const vm = useQuestionScreenViewModel(question, value, onChange);

  return (
    <div className={styles.root}>
      <div className={styles.header}>
        <div className={styles.titleRow}>
          <h2 className={styles.title}>{question.title}</h2>
          {vm.hasTooltip && (
            <Tooltip
              text={question.tooltip}
              terms={question.tooltipTerms}
              warning={question.tooltipWarning}
            />
          )}
          {vm.hasInfoModal && (
            <button
              type="button"
              className={styles.infoTrigger}
              aria-label="More info"
              onClick={vm.openInfoModal}
            >
              <Info size={16} />
            </button>
          )}
        </div>
        <p className={styles.subtitle}>{question.subtitle}</p>
      </div>
      <div className={styles.options}>
        {question.options.map((option) => (
          <AnswerButton
            key={option.value}
            label={option.label}
            selected={vm.isSelected(option.value)}
            onClick={() => vm.handleSelect(option.value)}
          />
        ))}
      </div>

      {vm.showInfoModal && question.tooltipItems && (
        <InfoModal
          title={question.title}
          items={question.tooltipItems}
          onClose={vm.closeInfoModal}
        />
      )}
    </div>
  );
};

export default QuestionScreen;
