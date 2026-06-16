import Image from 'next/image';
import Link from 'next/link';
import styles from './page.module.css';

const LandingPage = () => (
  <div className={styles.root}>
    <Image
      src="/images/home-page.jpg"
      alt=""
      fill
      priority
      className={styles.bgImage}
    />
    <div className={styles.overlay} />

    <div className={styles.content}>
      <div className={styles.titleRow}>
        <img src="/logo.svg" alt="" className={styles.logoIcon} />
        <h1 className={styles.title}>SurfMatch</h1>
      </div>

      <p className={styles.tagline}>
        Find your perfect wave. Answer a few quick questions and we&apos;ll match you with the best
        surf spots for today.
      </p>

      <div className={styles.ctaGroup}>
        <Link href="/quiz" className={styles.ctaButton}>
          Find my spot
        </Link>
        <p className={styles.ctaCaption}>Takes about 60 seconds</p>
      </div>
    </div>
  </div>
);

export default LandingPage;
