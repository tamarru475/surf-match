'use client';

import { useState } from 'react';
import Link from 'next/link';
import LoadingSpinner from '@/components/ui/LoadingSpinner';
import { SendIcon } from '@/components/ui/Icons';
import SkillCheckModal from '@/components/quiz/SkillCheckModal';
import { useAuth } from '@/lib/AuthContext';
import { useProfileViewModel } from './profile.viewmodel';
import ProfileCard from './profile-card/ProfileCard';
import FavoritesCard from './favorites/FavoritesCard';
import LastSessionCard from './last-session/LastSessionCard';
import PreferencesCard from './preferences/PreferencesCard';
import styles from './page.module.css';

const ProfilePage = () => {
  const { signOut } = useAuth();
  const vm = useProfileViewModel();
  const [showSkillQuiz, setShowSkillQuiz] = useState(false);

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
        <ProfileCard
          profile={vm.profile}
          skillLevel={vm.skillLevel}
          onOpenSkillQuiz={() => setShowSkillQuiz(true)}
        />

        {/* ── Card 2: Active Session ── */}
        <LastSessionCard />

        {/* ── Card 3: Favourite Spots ── */}
        <FavoritesCard />

        {/* ── Card 4: Surf Preferences ── */}
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

      {showSkillQuiz && (
        <SkillCheckModal
          onClose={() => setShowSkillQuiz(false)}
          onComplete={(level) => {
            vm.handleSaveSkillLevel(level);
            setShowSkillQuiz(false);
          }}
          actionLabel="Save to my profile"
        />
      )}
    </div>
  );
};

export default ProfilePage;
