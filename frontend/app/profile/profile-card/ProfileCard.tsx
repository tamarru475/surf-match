'use client';

import Button from '@/components/ui/Button';
import { CameraIcon, InstagramIcon, TikTokIcon, PinIcon } from '@/components/ui/Icons';
import type { Profile } from '@/lib/types';
import { useProfileCardViewModel, REGION_OPTIONS } from './profile-card.viewmodel';
import { formatEnum } from '../profile.viewmodel';
import styles from './ProfileCard.module.css';

interface Props {
  profile: Profile | null;
}

const ProfileCard = ({ profile }: Props) => {
  const vm = useProfileCardViewModel(profile);

  return (
    <div className={styles.card}>
      <div className={styles.profileHeader}>
        <div className={styles.photoWrap}>
          <div className={styles.avatar}>{vm.avatarLetter}</div>
          <button className={styles.cameraBtn} title="Upload photo (coming soon)" disabled>
            <CameraIcon />
          </button>
        </div>

        <div className={styles.headerInfo}>
          <span className={styles.nameWrap}>
            <span className={styles.nameGhost} aria-hidden="true">
              {vm.displayName || 'Your name'}
            </span>
            <input
              className={styles.nameInput}
              placeholder="Your name"
              value={vm.displayName}
              onChange={(e) => vm.setDisplayName(e.target.value)}
            />
          </span>

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
        </div>
      </div>

      <p className={styles.sectionLabel}>Bio</p>
      <textarea
        className={styles.bioTextarea}
        placeholder="Tell us a bit about yourself..."
        value={vm.bio}
        onChange={(e) => vm.setBio(e.target.value)}
      />

      <div className={styles.socialRow}>
        <span className={styles.socialLink}>
          <InstagramIcon className={styles.socialIcon} />
          @<span className={styles.handleWrap}>
            <span className={styles.handleGhost} aria-hidden="true">
              {vm.instagramHandle || 'yourhandle'}
            </span>
            <input
              className={styles.handleInput}
              placeholder="yourhandle"
              value={vm.instagramHandle}
              onChange={(e) => vm.setInstagramHandle(e.target.value)}
            />
          </span>
        </span>
        <span className={styles.socialLink}>
          <TikTokIcon className={styles.socialIcon} />
          @<span className={styles.handleWrap}>
            <span className={styles.handleGhost} aria-hidden="true">
              {vm.tikTokHandle || 'yourhandle'}
            </span>
            <input
              className={styles.handleInput}
              placeholder="yourhandle"
              value={vm.tikTokHandle}
              onChange={(e) => vm.setTikTokHandle(e.target.value)}
            />
          </span>
        </span>
      </div>

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
  );
};

export default ProfileCard;
