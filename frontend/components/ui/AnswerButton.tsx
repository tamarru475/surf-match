'use client';

import { cx } from '@/lib/utils';
import styles from './AnswerButton.module.css';

interface AnswerButtonProps {
  label: string;
  selected: boolean;
  onClick: () => void;
}

const AnswerButton = ({ label, selected, onClick }: AnswerButtonProps) => (
  <button
    onClick={onClick}
    className={cx(styles.button, selected ? styles.selected : styles.unselected)}
  >
    {label}
  </button>
);

export default AnswerButton;
