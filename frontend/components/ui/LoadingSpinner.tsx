import { Waves } from 'lucide-react';
import styles from './LoadingSpinner.module.css';

const LoadingSpinner = () => (
  <div className={styles.root}>
    <Waves className={styles.waveIcon} />
    <div className={styles.spinner} />
    <p className={styles.label}>Finding your perfect wave…</p>
  </div>
);

export default LoadingSpinner;
