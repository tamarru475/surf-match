'use client';

import { useState } from 'react';
import Image from 'next/image';
import Link from 'next/link';
import { MapPin, X } from 'lucide-react';
import { REGION_GRADIENTS, REGION_LABELS, SPOT_IMAGES } from '@/lib/constants';
import type { FavoriteSpot } from '@/lib/types';
import SpotModal from '@/components/results/SpotModal';
import { useFavoritesViewModel } from './favorites.viewmodel';
import styles from './FavoritesCard.module.css';

const FavoritesCard = () => {
  const vm = useFavoritesViewModel();
  const [activeSpot, setActiveSpot] = useState<FavoriteSpot | null>(null);

  return (
    <div className={styles.card}>
      <div className={styles.header}>
        <p className={styles.label}>Favourite Spots</p>
        <Link href="/results" className={styles.addBtn}>+ Add spot</Link>
      </div>

      {vm.loading && <p className={styles.empty}>Loading…</p>}
      {vm.error && <p className={styles.error}>{vm.error}</p>}

      {!vm.loading && !vm.error && vm.favorites.length === 0 && (
        <p className={styles.empty}>No favourites yet — heart a spot from your results.</p>
      )}

      {!vm.loading && vm.favorites.length > 0 && (
        <div className={styles.gridWrap}><div className={styles.grid}>
          {vm.favorites.map(spot => {
            const imageUrl = SPOT_IMAGES[spot.name];
            return (
              <div
                key={spot.spotId}
                className={styles.spotCard}
                role="button"
                tabIndex={0}
                onClick={() => setActiveSpot(spot)}
                onKeyDown={e => (e.key === 'Enter' || e.key === ' ') && setActiveSpot(spot)}
              >
                <div
                  className={styles.photo}
                  style={imageUrl ? undefined : { background: REGION_GRADIENTS[spot.region] }}
                >
                  {imageUrl && (
                    <Image src={imageUrl} alt={spot.name} fill sizes="220px" className="object-cover" />
                  )}
                  <div className={styles.overlay} />
                  <button
                    className={styles.removeBtn}
                    onClick={e => { e.stopPropagation(); vm.handleRemove(spot.spotId); }}
                    aria-label={`Remove ${spot.name} from favourites`}
                  >
                    <X size={12} />
                  </button>
                  <div className={styles.meta}>
                    <p className={styles.spotName}>{spot.name}</p>
                    <p className={styles.spotRegion}>
                      <MapPin size={11} className={styles.pin} />
                      {REGION_LABELS[spot.region]}
                    </p>
                  </div>
                </div>
              </div>
            );
          })}
        </div></div>
      )}

      {activeSpot && (
        <SpotModal spot={activeSpot} onClose={() => setActiveSpot(null)} />
      )}
    </div>
  );
};

export default FavoritesCard;
