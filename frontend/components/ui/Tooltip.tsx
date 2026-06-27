'use client';

import { useState } from 'react';
import { Info, TriangleAlert } from 'lucide-react';
import type { TooltipTerm } from '@/lib/questions';
import styles from './Tooltip.module.css';

interface TooltipProps {
  text?: string;
  terms?: TooltipTerm[];
  warning?: string;
}

const Tooltip = ({ text, terms, warning }: TooltipProps) => {
  const [open, setOpen] = useState(false);

  return (
    <span className={styles.root}>
      <button
        type="button"
        className={styles.trigger}
        aria-expanded={open}
        aria-label="More info"
        onClick={() => setOpen((o) => !o)}
        onBlur={() => setOpen(false)}
      >
        <Info size={16} />
      </button>
      {open && (
        <span role="tooltip" className={styles.bubble}>
          {terms && (
            <span className={styles.termList}>
              {terms.map((term) => (
                <span key={term.label} className={styles.term}>
                  <span className={styles.termLabel}>{term.label}</span>
                  <span className={styles.termDescription}>{term.description}</span>
                </span>
              ))}
            </span>
          )}
          {warning && (
            <span className={styles.warningBox}>
              <TriangleAlert size={16} className={styles.warningIcon} />
              <span className={styles.warningText}>{warning}</span>
            </span>
          )}
          {text && <span className={styles.text}>{text}</span>}
        </span>
      )}
    </span>
  );
};

export default Tooltip;
