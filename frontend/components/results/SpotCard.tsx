'use client';

import Image from 'next/image';
import { MapPin } from 'lucide-react';
import { cx } from '@/lib/utils';
import type { SpotRecommendation, UserPreferences } from '@/lib/types';
import { toSpotCardViewModel } from './SpotCard.viewmodel';
import styles from './SpotCard.module.css';

interface SpotCardProps {
  spot: SpotRecommendation;
  preferences: UserPreferences;
  onClick: () => void;
}

const SpotCard = ({ spot, preferences, onClick }: SpotCardProps) => {
  const vm = toSpotCardViewModel(spot, preferences);

  return (
    <button className={styles.card} onClick={onClick}>
      {/* Photo / gradient header */}
      <div className={styles.photo} style={vm.imageUrl ? undefined : vm.backgroundStyle}>
        {vm.imageUrl && (
          <Image src={vm.imageUrl} alt={vm.name} fill sizes="400px" className="object-cover" />
        )}
        <div className={styles.photoOverlay} />
        <span className={styles.matchBadge}>{vm.matchPct}% match</span>
      </div>

      {/* Card body */}
      <div className={styles.body}>
        <h3 className={styles.name}>{vm.name}</h3>

        <p className={styles.location}>
          <MapPin className={styles.locationIcon} />
          {vm.regionLabel}
        </p>

        <p className={styles.caption}>{vm.description}</p>

        <div className={styles.badges}>
          <span className={cx(styles.badge, styles.badgeSky)}>{vm.waveTypeLabel}</span>
          <span className={cx(styles.badge, styles.badgeIndigo)}>{vm.waveSizeLabel}</span>
          <span className={cx(styles.badge, styles[vm.crowdBadge.variant])}>
            {vm.crowdBadge.label}
          </span>
          <span className={cx(styles.badge, styles[vm.skillBadge.variant])}>
            {vm.skillBadge.label}
          </span>
        </div>
      </div>
    </button>
  );
};

export default SpotCard;
