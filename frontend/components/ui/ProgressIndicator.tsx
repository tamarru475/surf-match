import styles from './ProgressIndicator.module.css';

interface ProgressIndicatorProps {
  current: number;
  total: number;
}

const ProgressIndicator = ({ current, total }: ProgressIndicatorProps) => (
  <div className={styles.root}>
    <p className={styles.label}>
      Question {current} of {total}
    </p>
    <div className={styles.track}>
      <div
        className={styles.fill}
        style={{ width: `${Math.round((current / total) * 100)}%` }}
      />
    </div>
  </div>
);

export default ProgressIndicator;
