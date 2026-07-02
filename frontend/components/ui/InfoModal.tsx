'use client';

import { useEffect, useState } from 'react';
import Image from 'next/image';
import { X } from 'lucide-react';
import { cx } from '@/lib/utils';
import type { TooltipItem } from '@/lib/questions';
import styles from './InfoModal.module.css';

interface InfoModalProps {
  title: string;
  items: TooltipItem[];
  onClose: () => void;
}

const InfoModal = ({ title, items, onClose }: InfoModalProps) => {
  const [isClosing, setIsClosing] = useState(false);

  const handleClose = () => setIsClosing(true);

  useEffect(() => {
    if (!isClosing) return;
    const timer = setTimeout(onClose, 240);
    return () => clearTimeout(timer);
  }, [isClosing, onClose]);

  useEffect(() => {
    const handler = (e: KeyboardEvent) => {
      if (e.key === 'Escape') handleClose();
    };
    window.addEventListener('keydown', handler);
    return () => window.removeEventListener('keydown', handler);
  }, []);

  return (
    <div className={cx(styles.backdrop, isClosing && styles.backdropClosing)}>
      <div className={styles.overlay} onClick={handleClose} />

      <div
        className={cx(styles.panel, isClosing && styles.panelClosing)}
        onClick={(e) => e.stopPropagation()}
      >
        <div className={styles.header}>
          <h2 className={styles.title}>{title}</h2>
          <button className={styles.closeBtn} onClick={handleClose} aria-label="Close">
            <X size={18} />
          </button>
        </div>

        <div className={styles.body}>
          {items.map((item) => (
            <div key={item.label} className={styles.item}>
              <div className={styles.itemImage}>
                <Image src={item.image} alt={item.label} fill sizes="500px" className="object-cover" />
              </div>
              <p className={styles.itemLabel}>{item.label}</p>
              <p className={styles.itemDescription}>{item.description}</p>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default InfoModal;
