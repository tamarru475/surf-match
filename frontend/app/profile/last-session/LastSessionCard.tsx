'use client';

import Image from 'next/image';
import { MapPin, Wind, XCircle } from 'lucide-react';
import { REGION_GRADIENTS, SPOT_IMAGES, spotRegionLabel } from '@/lib/constants';
import { useLastSessionViewModel } from './last-session.viewmodel';
import styles from './LastSessionCard.module.css';

const LastSessionCard = () => {
  const vm = useLastSessionViewModel();

  if (vm.loading) return null;
  if (vm.error) return null;

  if (!vm.isActive) {
    return (
      <div className={styles.emptyCard}>
        <div className={styles.emptyIcon}>
          <Wind size={20} />
        </div>
        <div>
          <p className={styles.emptyTitle}>No active session</p>
          <p className={styles.emptyText}>
            Hit &ldquo;I&apos;m surfing here today&rdquo; on a spot below to go live.
          </p>
        </div>
      </div>
    );
  }

  const { spotName, region } = vm.session!;
  const imageUrl = SPOT_IMAGES[spotName];

  return (
    <div className={styles.activeBanner}>
      <div
        className={styles.bannerBg}
        style={imageUrl ? undefined : { background: REGION_GRADIENTS[region] }}
      >
        {imageUrl && (
          <Image src={imageUrl} alt={spotName} fill sizes="640px" className="object-cover" />
        )}
      </div>
      <div className={styles.bannerOverlay} />

      <div className={styles.bannerContent}>
        <div className={styles.bannerLeft}>
          <div className={styles.surfingNowRow}>
            <span className={styles.pulse} />
            <span className={styles.surfingNowLabel}>Surfing Now</span>
          </div>
          <p className={styles.bannerSpotName}>{spotName}</p>
          <p className={styles.bannerRegion}>
            <MapPin size={13} />
            {spotRegionLabel(spotName, region)}
          </p>
        </div>

        <button className={styles.doneBtn} onClick={vm.handleDone}>
          <XCircle size={16} />
          Done
        </button>
      </div>
    </div>
  );
};

export default LastSessionCard;
