'use client';

import { useRef } from 'react';
import Image from 'next/image';
import { Award, ChevronRight } from 'lucide-react';
import Button from '@/components/ui/Button';
import { CameraIcon, InstagramIcon, TikTokIcon, PinIcon } from '@/components/ui/Icons';
import AvatarCropModal from '@/components/profile/AvatarCropModal';
import { SKILL_LEVEL_THEMES } from '@/lib/skill-quiz';
import type { Profile, SkillLevel } from '@/lib/types';
import { useProfileCardViewModel, REGION_OPTIONS } from './profile-card.viewmodel';
import { formatEnum } from '../profile.viewmodel';
import styles from './ProfileCard.module.css';

interface Props {
  profile: Profile | null;
  skillLevel: SkillLevel | null;
  onOpenSkillQuiz: () => void;
}

const ProfileCard = ({ profile, skillLevel, onOpenSkillQuiz }: Props) => {
  const vm = useProfileCardViewModel(profile);
  const theme = skillLevel ? SKILL_LEVEL_THEMES[skillLevel] : null;
  const fileInputRef = useRef<HTMLInputElement>(null);

  return (
    <div className={styles.card}>
      <div className={styles.profileHeader}>
        <div className={styles.photoWrap}>
          {vm.avatarUrl ? (
            <Image
              src={vm.avatarUrl}
              alt="Profile photo"
              width={80}
              height={80}
              className={styles.avatarImg}
            />
          ) : (
            <div className={styles.avatar}>{vm.avatarLetter}</div>
          )}
          <button
            className={styles.cameraBtn}
            title="Upload photo"
            disabled={vm.uploading}
            onClick={() => fileInputRef.current?.click()}
          >
            <CameraIcon />
          </button>
          <input
            ref={fileInputRef}
            type="file"
            accept="image/jpeg,image/png,image/webp"
            className={styles.fileInput}
            onChange={(e) => {
              const file = e.target.files?.[0];
              if (file) vm.handleFilePicked(file);
              e.target.value = '';
            }}
          />
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

          <div className={styles.skillRow}>
            {theme && (
              <span
                className={styles.skillPill}
                style={{ background: theme.badgeBg, color: theme.accent }}
              >
                <Award size={12} />
                {theme.label}
              </span>
            )}
            <button className={styles.quizLink} onClick={onOpenSkillQuiz}>
              {theme ? 'Not sure? Take a quick quiz' : 'Assess my skill level'}
              <ChevronRight size={13} />
            </button>
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

      {vm.pendingImageSrc && (
        <AvatarCropModal
          imageSrc={vm.pendingImageSrc}
          onConfirm={vm.handleCropConfirm}
          onClose={vm.handleCropCancel}
        />
      )}
    </div>
  );
};

export default ProfileCard;
