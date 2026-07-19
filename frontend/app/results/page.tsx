'use client'

import Link from 'next/link'
import { TriangleAlert } from 'lucide-react'
import SpotCard from '@/components/results/SpotCard'
import SpotModal from '@/components/results/SpotModal'
import { useAuth } from '@/lib/AuthContext'
import { useResultsViewModel } from './results.viewmodel'
import styles from './page.module.css'

const ResultsPage = () => {
  const { user, openAuthModal } = useAuth()
  const vm = useResultsViewModel()

  if (!vm.data) return null

  const { recommendations, preferences, warnings } = vm.data

  return (
    <main className={styles.root}>
      <div className={styles.header}>
        <div>
          <h1 className={styles.headerTitle}>Your matches</h1>
          <p className={styles.headerSubtitle}>
            {recommendations.length} spot
            {recommendations.length !== 1 ? 's' : ''} found
          </p>
        </div>
        <div className={styles.headerActions}>
          {user ? (
            <Link href="/profile" className={styles.createAccount}>My profile</Link>
          ) : (
            <button className={styles.createAccount} onClick={() => openAuthModal('signup')}>
              Create account
            </button>
          )}
          <button className={styles.startOver} onClick={vm.handleStartOver}>
            Start over
          </button>
        </div>
      </div>

      {warnings.length > 0 && (
        <div className={styles.warningBanner}>
          <TriangleAlert size={18} className={styles.warningIcon} />
          <div className={styles.warningList}>
            {warnings.map((warning) => (
              <p key={warning} className={styles.warningText}>{warning}</p>
            ))}
          </div>
        </div>
      )}

      <div className={styles.grid}>
        {recommendations.map((spot) => (
          <SpotCard
            key={spot.spotId}
            spot={spot}
            preferences={preferences}
            onClick={() => vm.setActiveSpot(spot)}
            isFavorited={vm.favoritedIds.has(spot.spotId)}
            onToggleFavorite={vm.isLoggedIn ? () => vm.handleToggleFavorite(spot.spotId) : undefined}
          />
        ))}
      </div>

      {vm.activeSpot && (
        <SpotModal
          spot={vm.activeSpot}
          preferences={preferences}
          onClose={() => vm.setActiveSpot(null)}
          isFavorited={vm.favoritedIds.has(vm.activeSpot.spotId)}
          onToggleFavorite={vm.isLoggedIn ? () => vm.handleToggleFavorite(vm.activeSpot!.spotId) : undefined}
        />
      )}
    </main>
  )
}

export default ResultsPage
