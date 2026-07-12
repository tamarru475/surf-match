'use client';

import Link from 'next/link';
import Button from '@/components/ui/Button';
import LoadingSpinner from '@/components/ui/LoadingSpinner';
import { CameraIcon, InstagramIcon, TikTokIcon, LinesIcon, SendIcon, PinIcon } from '@/components/ui/Icons';
import { useAuth } from '@/lib/AuthContext';
import { useProfileViewModel, REGION_OPTIONS, formatEnum } from './profile.viewmodel';
import styles from './page.module.css';

// ── Page ─────────────────────────────────────────────────────────────────────

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
        <div className={styles.card}>
          <div className={styles.profileHeader}>
            <div className={styles.photoWrap}>
              <div className={styles.avatar}>{vm.avatarLetter}</div>
              <button className={styles.cameraBtn} title="Upload photo (coming soon)" disabled>
                <CameraIcon />
              </button>
            </div>

            <div className={styles.headerInfo}>
              <input
                className={styles.nameInput}
                placeholder="Your name"
                value={vm.displayName}
                onChange={(e) => vm.setDisplayName(e.target.value)}
              />
              <div className={styles.locationRow}>
                <PinIcon />
                <select
                  className={styles.locationSelect}
                  value={vm.location}
                  onChange={(e) => vm.setLocation(e.target.value)}
                >
                  <option value="">Your region</option>
                  {REGION_OPTIONS.map((r) => (
                    <option key={r} value={r}>{formatEnum(r)}</option>
                  ))}
                </select>
              </div>
              <div className={styles.socialRow}>
                <span className={styles.socialLink}>
                  <InstagramIcon className={styles.socialIcon} />
                  @<input
                    className={styles.handleInput}
                    placeholder="yourhandle"
                    value={vm.instagramHandle}
                    onChange={(e) => vm.setInstagramHandle(e.target.value)}
                  />
                </span>
                <span className={styles.socialLink}>
                  <TikTokIcon className={styles.socialIcon} />
                  @<input
                    className={styles.handleInput}
                    placeholder="yourhandle"
                    value={vm.tikTokHandle}
                    onChange={(e) => vm.setTikTokHandle(e.target.value)}
                  />
                </span>
              </div>
            </div>
          </div>

          <p className={styles.sectionLabel}>Bio</p>
          <textarea
            className={styles.bioTextarea}
            placeholder="Tell us a bit about yourself..."
            value={vm.bio}
            onChange={(e) => vm.setBio(e.target.value)}
          />

          <div className={styles.saveRow}>
            {vm.saveSuccess ? (
              <span className={styles.savedText}>Saved!</span>
            ) : vm.isDirty ? (
              <Button variant="primary" size="sm" onClick={vm.handleSave} disabled={vm.saving}>
                {vm.saving ? 'Saving…' : 'Save profile'}
              </Button>
            ) : null}
            {vm.error && <span className={styles.error}>{vm.error}</span>}
          </div>
        </div>

        {/* ── Card 2: Surf Preferences ── */}
        <div className={styles.card}>
          <div className={styles.prefsHeader}>
            <p className={styles.sectionLabel} style={{ marginBottom: 0 }}>Surf Preferences</p>
            <span className={styles.prefsSubLabel}>
              <LinesIcon />
              from your quiz
            </span>
          </div>

          {vm.preferences ? (
            <div className={styles.prefsGrid}>
              {vm.prefRows.map(({ label, getValue }) => (
                <div key={label} className={styles.prefItem}>
                  <span className={styles.prefLabel}>{label}</span>
                  <span className={styles.prefPill}>{getValue(vm.preferences!)}</span>
                </div>
              ))}
            </div>
          ) : (
            <p className={styles.noPrefs}>No preferences saved yet — take the quiz first.</p>
          )}
        </div>

        {/* ── Card 3: Favourite Spots ── */}
        <div className={styles.card}>
          <div className={styles.spotsHeader}>
            <p className={styles.sectionLabel} style={{ marginBottom: 0 }}>Favourite Spots</p>
            <button className={styles.addSpotBtn} disabled>+ Add spot</button>
          </div>
          <p className={styles.spotsEmpty}>Your favourite spots will appear here.</p>
        </div>
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
