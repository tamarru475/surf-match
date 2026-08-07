'use client';

import { Award, X } from 'lucide-react';
import { SKILL_LEVEL_THEMES } from '@/lib/skill-quiz';
import type { SkillLevel } from '@/lib/types';
import { useSkillCheckModalViewModel } from './SkillCheckModal.viewmodel';
import styles from './SkillCheckModal.module.css';

interface SkillCheckModalProps {
  onClose: () => void;
  onComplete: (level: SkillLevel) => void;
  actionLabel?: string;
}

const SkillCheckModal = ({ onClose, onComplete, actionLabel = 'Save to my profile' }: SkillCheckModalProps) => {
  const vm = useSkillCheckModalViewModel(onComplete);
  const theme = vm.determinedLevel ? SKILL_LEVEL_THEMES[vm.determinedLevel] : null;

  return (
    <div className={styles.backdrop}>
      <div className={styles.overlay} onClick={onClose} />

      <div className={styles.panel}>
        {vm.phase === 'quiz' ? (
          <>
            <div className={styles.quizHeader}>
              <span className={styles.quizLabel}>
                Skill check · {vm.questionIndex + 1} / {vm.total}
              </span>
              <button className={styles.closeBtn} onClick={onClose} aria-label="Close">
                <X size={16} />
              </button>
            </div>

            <p className={styles.question}>{vm.question!.text}</p>

            <div className={styles.yesNo}>
              <button className={`${styles.answerBtn} ${styles.noBtn}`} onClick={vm.handleNo}>
                No
              </button>
              <button className={`${styles.answerBtn} ${styles.yesBtn}`} onClick={vm.handleYes}>
                Yes
              </button>
            </div>
          </>
        ) : theme && (
          <>
            <div className={styles.resultTop} style={{ background: theme.topBg }}>
              <button className={styles.closeBtn} onClick={onClose} aria-label="Close">
                <X size={16} />
              </button>

              <div className={styles.iconSquare} style={{ background: theme.iconBg }}>
                <Award size={28} color="white" />
              </div>

              <p className={styles.yourLevel} style={{ color: theme.accent }}>Your level</p>
              <p className={styles.levelName}>{theme.label}</p>
              <p className={styles.levelDesc}>{theme.description}</p>
            </div>

            <div className={styles.resultBottom}>
              <button
                className={styles.saveBtn}
                style={{ background: theme.accent }}
                onClick={vm.handleSave}
              >
                {actionLabel}
              </button>
              <button className={styles.retakeBtn} onClick={vm.handleRetake}>
                Retake quiz
              </button>
            </div>
          </>
        )}
      </div>
    </div>
  );
};

export default SkillCheckModal;
