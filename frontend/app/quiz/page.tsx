'use client';

import ProgressIndicator from '@/components/ui/ProgressIndicator';
import Button from '@/components/ui/Button';
import LoadingSpinner from '@/components/ui/LoadingSpinner';
import QuestionScreen from '@/components/quiz/QuestionScreen';
import { QUESTIONS } from '@/lib/questions';
import { useQuizViewModel } from './quiz.viewmodel';
import styles from './page.module.css';

const QuizPage = () => {
  const vm = useQuizViewModel();

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
    </main>
  );
};

export default QuizPage;
