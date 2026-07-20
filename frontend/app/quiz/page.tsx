'use client';

import { useState } from 'react';
import ProgressIndicator from '@/components/ui/ProgressIndicator';
import Button from '@/components/ui/Button';
import LoadingSpinner from '@/components/ui/LoadingSpinner';
import QuestionScreen from '@/components/quiz/QuestionScreen';
import SkillCheckModal from '@/components/quiz/SkillCheckModal';
import { useAuth } from '@/lib/AuthContext';
import { QUESTIONS } from '@/lib/questions';
import { useQuizViewModel } from './quiz.viewmodel';
import styles from './page.module.css';

const QuizPage = () => {
  const { user } = useAuth();
  const vm = useQuizViewModel();
  const [showSkillQuiz, setShowSkillQuiz] = useState(false);

  if (vm.loading) {
    return (
      <main className={styles.loading}>
        <LoadingSpinner />
      </main>
    );
  }

  return (
    <main className={styles.root}>
      <div className={styles.topBar}>
        <ProgressIndicator current={vm.step + 1} total={QUESTIONS.length} />
      </div>

      <div className={styles.body}>
        <QuestionScreen question={vm.question} value={vm.value} onChange={vm.handleChange} />

        {vm.step === 0 && (
          <button className={styles.skillQuizLink} onClick={() => setShowSkillQuiz(true)}>
            Not sure of your level? Take a quick quiz →
          </button>
        )}

        {vm.error && <p className={styles.error}>{vm.error}</p>}
      </div>

      <div className={styles.nav}>
        <Button variant="ghost" onClick={vm.handleBack} className="flex-1">
          Back
        </Button>
        <Button
          variant="primary"
          onClick={vm.handleNext}
          disabled={vm.isNextDisabled}
          className="flex-[2]"
        >
          {vm.nextLabel}
        </Button>
      </div>

      {showSkillQuiz && (
        <SkillCheckModal
          onClose={() => setShowSkillQuiz(false)}
          onComplete={(level) => {
            vm.handleChange(level);
            setShowSkillQuiz(false);
          }}
          actionLabel={user ? 'Save to my profile' : 'Use this level'}
        />
      )}
    </main>
  );
};

export default QuizPage;
