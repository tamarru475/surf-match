'use client'

import Image from 'next/image'
import { useEffect, useState } from 'react'
import { Map, MapPin, X } from 'lucide-react'
import { cx } from '@/lib/utils'
import type { SpotRecommendation, UserPreferences } from '@/lib/types'
import { toSpotModalViewModel } from './SpotCard.viewmodel'
import styles from './SpotModal.module.css'

interface SpotModalProps {
  spot: SpotRecommendation
  preferences: UserPreferences
  onClose: () => void
}

// Renders a single label/value block in the detail grid (wave type, skill level, etc.)
const DetailItem = ({ label, value }: { label: string; value: string }) => (
  <div className={styles.detailItem}>
    <p className={styles.detailLabel}>{label}</p>
    <p className={styles.detailValue}>{value}</p>
  </div>
)

const SpotModal = ({ spot, preferences, onClose }: SpotModalProps) => {
  const vm = toSpotModalViewModel(spot, preferences)
  const [isClosing, setIsClosing] = useState(false)

  const handleClose = () => {
    setIsClosing(true)
  }

  useEffect(() => {
    if (!isClosing) return
    const timer = setTimeout(onClose, 240)
    return () => clearTimeout(timer)
  }, [isClosing, onClose])

  useEffect(() => {
    const handler = (e: KeyboardEvent) => {
      if (e.key === 'Escape') handleClose()
    }
    window.addEventListener('keydown', handler)
    return () => window.removeEventListener('keydown', handler)
  }, [])

  return (
    <div className={cx(styles.backdrop, isClosing && styles.backdropClosing)}>
      <div className={styles.overlay} onClick={handleClose} />

      <div
        className={cx(styles.panel, isClosing && styles.panelClosing)}
        onClick={(e) => e.stopPropagation()}
      >
        {/* Photo header */}
        <div
          className={styles.photo}
          style={vm.imageUrl ? undefined : vm.backgroundStyle}
        >
          {vm.imageUrl && (
            <Image
              src={vm.imageUrl}
              alt={vm.name}
              fill
              sizes='600px'
              className='object-cover'
            />
          )}
          <div className={styles.photoTint} />

          <button
            className={styles.closeBtn}
            onClick={handleClose}
            aria-label='Close'
          >
            <X size={18} />
          </button>

          <span className={styles.matchBadge}>{vm.matchPct}% match</span>

          <div className={styles.photoMeta}>
            <h2 className={styles.photoTitle}>{vm.name}</h2>
            <p className={styles.photoRegion}>
              <MapPin className={styles.regionIcon} /> {vm.regionLabel}
            </p>
          </div>
        </div>

        {/* Scrollable body */}
        <div className={styles.body}>
          <p className={styles.description}>{vm.description}</p>

          <a
            href={vm.mapsUrl}
            target='_blank'
            rel='noopener noreferrer'
            className={styles.mapsLink}
          >
            <Map className={styles.mapsIcon} /> Open in Google Maps
          </a>

          <div className={styles.detailGrid}>
            <DetailItem label='Wave type' value={vm.waveType} />
            <DetailItem label='Current height' value={vm.currentHeight} />
            <DetailItem label='Skill level' value={vm.skillLevel} />
            <DetailItem label='Typical crowd' value={vm.crowdLevel} />
          </div>

          {vm.facilitiesLabels.length > 0 && (
            <div>
              <p className={styles.facilitiesHeading}>Facilities</p>
              <div className={styles.facilitiesList}>
                {vm.facilitiesLabels.map((label) => (
                  <span key={label} className={styles.facilityChip}>
                    {label}
                  </span>
                ))}
              </div>
            </div>
          )}

          {vm.hasNotes && (
            <div className={styles.notes}>
              <p className={styles.notesTitle}>Notes</p>
              <ul className={styles.notesList}>
                {vm.notes.map((note) => (
                  <li key={note} className={styles.notesText}>{note}</li>
                ))}
              </ul>
            </div>
          )}
        </div>
      </div>
    </div>
  )
}

export default SpotModal
