'use client'

import { useEffect, useState } from 'react'
import { useRouter } from 'next/navigation'
import { useAuth } from '@/lib/AuthContext'
import { addFavorite, fetchFavorites, removeFavorite } from '@/lib/api'
import type { RecommendationResponse, SpotRecommendation } from '@/lib/types'

export interface ResultsViewModel {
  data: RecommendationResponse | null
  activeSpot: SpotRecommendation | null
  setActiveSpot: (spot: SpotRecommendation | null) => void
  favoritedIds: Set<string>
  handleToggleFavorite: (spotId: string) => void
  handleStartOver: () => void
  isLoggedIn: boolean
}

export function useResultsViewModel(): ResultsViewModel {
  const router = useRouter()
  const { user } = useAuth()
  const [data, setData] = useState<RecommendationResponse | null>(null)
  const [activeSpot, setActiveSpot] = useState<SpotRecommendation | null>(null)
  const [favoritedIds, setFavoritedIds] = useState<Set<string>>(new Set())

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
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  useEffect(() => {
    if (!user) return
    fetchFavorites()
      .then(favs => setFavoritedIds(new Set(favs.map(f => f.spotId))))
      .catch(() => {})
  }, [user])

  const handleToggleFavorite = (spotId: string) => {
    const wasFavorited = favoritedIds.has(spotId)
    setFavoritedIds(prev => {
      const next = new Set(prev)
      wasFavorited ? next.delete(spotId) : next.add(spotId)
      return next
    })
    const op = wasFavorited ? removeFavorite(spotId) : addFavorite(spotId)
    op.catch(() => {
      setFavoritedIds(prev => {
        const next = new Set(prev)
        wasFavorited ? next.add(spotId) : next.delete(spotId)
        return next
      })
    })
  }

  const handleStartOver = () => router.push('/')

  return {
    data,
    activeSpot,
    setActiveSpot,
    favoritedIds,
    handleToggleFavorite,
    handleStartOver,
    isLoggedIn: !!user,
  }
}
