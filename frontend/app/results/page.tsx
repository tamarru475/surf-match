'use client'

import { useEffect, useState } from 'react'
import { useRouter } from 'next/navigation'
import SpotCard from '@/components/results/SpotCard'
import SpotModal from '@/components/results/SpotModal'
import type { RecommendationResponse, SpotRecommendation } from '@/lib/types'
import styles from './page.module.css'

const ResultsPage = () => {
  const router = useRouter()
  const [data, setData] = useState<RecommendationResponse | null>(null)
  const [activeSpot, setActiveSpot] = useState<SpotRecommendation | null>(null)

  useEffect(() => {
    const raw = sessionStorage.getItem('surfmatch_results')
    if (!raw) {
      router.replace('/')
      return
    }
    try {
      setData(JSON.parse(raw))
    } catch {
      router.replace('/')
    }
  }, [router])

  if (!data) return null

  const { recommendations, preferences } = data

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
        <button className={styles.startOver} onClick={() => router.push('/')}>
          Start over
        </button>
      </div>

      {recommendations.length === 0 ? (
        <div className={styles.empty}>
          <p className={styles.emptyTitle}>No spots matched those filters.</p>
          <p className={styles.emptyText}>
            Try removing the wave size or wave type filter and search again.
          </p>
          <button
            className={styles.emptyAction}
            onClick={() => router.push('/quiz')}
          >
            Try different preferences
          </button>
        </div>
      ) : (
        <div className={styles.grid}>
          {recommendations.map((spot) => (
            <SpotCard
              key={spot.spotId}
              spot={spot}
              preferences={preferences}
              onClick={() => setActiveSpot(spot)}
            />
          ))}
        </div>
      )}

      {activeSpot && (
        <SpotModal
          spot={activeSpot}
          preferences={preferences}
          onClose={() => setActiveSpot(null)}
        />
      )}
    </main>
  )
}

export default ResultsPage
