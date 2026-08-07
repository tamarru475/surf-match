'use client';

import { useState, useRef, useEffect } from 'react';
import styles from './MultiSelect.module.css';

interface Props<T extends string> {
  options: T[];
  selected: T[];
  onToggle: (v: T) => void;
  formatLabel: (v: T) => string;
  placeholder?: string;
}

export default function MultiSelect<T extends string>({
  options, selected, onToggle, formatLabel, placeholder = 'Any',
}: Props<T>) {
  const [open, setOpen] = useState(false);
  const ref = useRef<HTMLDivElement>(null);

  useEffect(() => {
    const handler = (e: MouseEvent) => {
      if (ref.current && !ref.current.contains(e.target as Node)) setOpen(false);
    };
    document.addEventListener('mousedown', handler);
    return () => document.removeEventListener('mousedown', handler);
  }, []);

  const label = selected.length === 0 ? placeholder : selected.map(formatLabel).join(', ');

  return (
    <div className={styles.root} ref={ref}>
      <button className={styles.trigger} onClick={() => setOpen(o => !o)} type="button">
        <span className={styles.label}>{label}</span>
        <span className={styles.arrow}>{open ? '▴' : '▾'}</span>
      </button>
      {open && (
        <div className={styles.dropdown}>
          {options.map(v => (
            <label key={v} className={styles.option}>
              <input
                type="checkbox"
                className={styles.checkbox}
                checked={selected.includes(v)}
                onChange={() => onToggle(v)}
              />
              {formatLabel(v)}
            </label>
          ))}
        </div>
      )}
    </div>
  );
}
