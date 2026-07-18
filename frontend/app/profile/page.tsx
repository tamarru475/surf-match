'use client';

import Link from 'next/link';
import LoadingSpinner from '@/components/ui/LoadingSpinner';
import { SendIcon } from '@/components/ui/Icons';
import { useAuth } from '@/lib/AuthContext';
import { useProfileViewModel } from './profile.viewmodel';
import ProfileCard from './profile-card/ProfileCard';
import FavoritesCard from './favorites/FavoritesCard';
import PreferencesCard from './preferences/PreferencesCard';
import styles from './page.module.css';

const ProfilePage = () => {
  const { signOut } = useAuth();
  const vm = useProfileViewModel();

  if (vm.loading) {
    return <div className={styles.loading}><LoadingSpinner /></div>;
  }

  return (
    <div className={styles.root}>
      {/* Nav */}
      <nav className={styles.nav}>
        <Link href="/" className={styles.navLogo}>SurfMatch</Link>
        <div className={styles.navRight}>
          <span className={styles.navPill}>Profile</span>
          <button className={styles.logoutBtn} onClick={signOut}>Log out</button>
        </div>
      </nav>

      <div className={styles.page}>

        {/* ── Card 1: Profile ── */}
        <ProfileCard profile={vm.profile} />

        {/* ── Card 2: Favourite Spots ── */}
        <FavoritesCard />

        {/* ── Card 3: Surf Preferences ── */}
        <PreferencesCard preferences={vm.preferences} />

      </div>

      {/* ── Bottom actions ── */}
      <div className={styles.actions}>
        <button className={styles.findWaveBtn} onClick={vm.handleFindWave} disabled={vm.findingWave}>
          <SendIcon />
          {vm.findingWave ? 'Finding…' : 'Find my wave today'}
        </button>
        <Link href="/quiz" className={styles.updatePrefsBtn}>
          ↺ Update surf preferences
        </Link>
        {vm.error && vm.findingWave && (
          <p className={`${styles.error} text-center`}>{vm.error}</p>
        )}
      </div>
    </div>
  );
};

export default ProfilePage;
