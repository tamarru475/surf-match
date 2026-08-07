/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react'
import { useResultsViewModel } from '@/app/results/results.viewmodel'
import type { FavoriteSpot, RecommendationResponse } from '@/lib/types'

const mockReplace = jest.fn()
const mockPush = jest.fn()
jest.mock('next/navigation', () => ({
  useRouter: () => ({ replace: mockReplace, push: mockPush }),
}))

const mockFetchFavorites = jest.fn()
const mockAddFavorite    = jest.fn()
const mockRemoveFavorite = jest.fn()
const mockLogSurfSession = jest.fn()
jest.mock('../../../lib/api', () => ({
  ...jest.requireActual('../../../lib/api'),
  fetchFavorites:   (...args: unknown[]) => mockFetchFavorites(...args),
  addFavorite:      (...args: unknown[]) => mockAddFavorite(...args),
  removeFavorite:   (...args: unknown[]) => mockRemoveFavorite(...args),
  logSurfSession:   (...args: unknown[]) => mockLogSurfSession(...args),
}))

let mockUser: object | null = { id: 'user-1' }
jest.mock('../../../lib/AuthContext', () => ({
  useAuth: () => ({ user: mockUser }),
}))

const SPOT_ID = 'spot-abc'

const FAKE_DATA: RecommendationResponse = {
  preferences: {
    skillLevel: 'Intermediate',
    crowdTolerance: 'Quiet',
    preferredRegions: [],
    boardTypes: [],
    preferredWaveTypes: [],
    preferredWaveSizes: [],
    preferredFacilities: [],
  },
  recommendations: [],
  warnings: [],
}

const FAKE_FAVORITE: FavoriteSpot = {
  spotId: SPOT_ID,
  name: 'Piha',
  region: 'Auckland',
  waveType: 'BeachBreak',
  minSkillLevel: 'Intermediate',
  typicalCrowd: 'Busy',
  currentWaveSize: 'WaistHigh',
  facilities: [],
  description: 'Famous black-sand beach.',
  favoritedAt: new Date().toISOString(),
}

beforeEach(() => {
  jest.clearAllMocks()
  mockUser = { id: 'user-1' }
  sessionStorage.clear()
  mockFetchFavorites.mockResolvedValue([])
  mockAddFavorite.mockResolvedValue(FAKE_FAVORITE)
  mockRemoveFavorite.mockResolvedValue(undefined)
  mockLogSurfSession.mockResolvedValue({ sessionId: 'sess-1', spotId: SPOT_ID })
})

describe('data loading', () => {
  it('redirects to / when sessionStorage is empty', async () => {
    await act(async () => { renderHook(() => useResultsViewModel()) })
    expect(mockReplace).toHaveBeenCalledWith('/')
  })

  it('redirects to / when sessionStorage contains invalid JSON', async () => {
    sessionStorage.setItem('surfmatch_results', 'not-json')
    await act(async () => { renderHook(() => useResultsViewModel()) })
    expect(mockReplace).toHaveBeenCalledWith('/')
  })

  it('parses data from sessionStorage', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    expect(result!.current.data).toEqual(FAKE_DATA)
  })

  it('sets loading false after successfully reading sessionStorage', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    expect(result!.current.loading).toBe(false)
  })

  it('sets loading false even when redirecting due to missing data', async () => {
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    expect(result!.current.loading).toBe(false)
  })
})

describe('favorites loading', () => {
  it('fetches favorites when user is logged in', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    mockFetchFavorites.mockResolvedValue([FAKE_FAVORITE])
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    expect(result!.current.favoritedIds.has(SPOT_ID)).toBe(true)
  })

  it('does not fetch favorites when logged out', async () => {
    mockUser = null
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    await act(async () => { renderHook(() => useResultsViewModel()) })
    expect(mockFetchFavorites).not.toHaveBeenCalled()
  })

  it('adds a pending_favorite from sessionStorage after fetching favorites', async () => {
    const pendingId = 'pending-spot-id'
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    sessionStorage.setItem('pending_favorite', pendingId)
    mockFetchFavorites.mockResolvedValue([])
    mockAddFavorite.mockResolvedValue({})
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    expect(result!.current.favoritedIds.has(pendingId)).toBe(true)
    expect(mockAddFavorite).toHaveBeenCalledWith(pendingId)
    expect(sessionStorage.getItem('pending_favorite')).toBeNull()
  })

  it('does not call addFavorite for pending_favorite already in fetched list', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    sessionStorage.setItem('pending_favorite', SPOT_ID)
    mockFetchFavorites.mockResolvedValue([FAKE_FAVORITE])
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    expect(result!.current.favoritedIds.has(SPOT_ID)).toBe(true)
    expect(mockAddFavorite).not.toHaveBeenCalled()
  })
})

describe('handleToggleFavorite', () => {
  it('optimistically adds a spot to favoritedIds', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    await act(async () => { result!.current.handleToggleFavorite(SPOT_ID) })
    expect(result!.current.favoritedIds.has(SPOT_ID)).toBe(true)
  })

  it('optimistically removes a spot from favoritedIds', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    mockFetchFavorites.mockResolvedValue([FAKE_FAVORITE])
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    await act(async () => { result!.current.handleToggleFavorite(SPOT_ID) })
    expect(result!.current.favoritedIds.has(SPOT_ID)).toBe(false)
  })

  it('reverts add when API call fails', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    mockAddFavorite.mockRejectedValue(new Error('Network error'))
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    await act(async () => { result!.current.handleToggleFavorite(SPOT_ID) })
    expect(result!.current.favoritedIds.has(SPOT_ID)).toBe(false)
  })

  it('reverts remove when API call fails', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    mockFetchFavorites.mockResolvedValue([FAKE_FAVORITE])
    mockRemoveFavorite.mockRejectedValue(new Error('Network error'))
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    await act(async () => { result!.current.handleToggleFavorite(SPOT_ID) })
    expect(result!.current.favoritedIds.has(SPOT_ID)).toBe(true)
  })
})

describe('handleLogSession', () => {
  it('adds spotId to loggedSessionIds on success', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    await act(async () => { result!.current.handleLogSession(SPOT_ID) })
    expect(result!.current.loggedSessionIds.has(SPOT_ID)).toBe(true)
  })

  it('does not add spotId to loggedSessionIds when API fails', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    mockLogSurfSession.mockRejectedValue(new Error('Network error'))
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    await act(async () => { result!.current.handleLogSession(SPOT_ID) })
    expect(result!.current.loggedSessionIds.has(SPOT_ID)).toBe(false)
  })
})

describe('handleStartOver', () => {
  it('pushes to /', async () => {
    sessionStorage.setItem('surfmatch_results', JSON.stringify(FAKE_DATA))
    let result: ReturnType<typeof renderHook<ReturnType<typeof useResultsViewModel>, unknown>>['result']
    await act(async () => {
      ;({ result } = renderHook(() => useResultsViewModel()))
    })
    act(() => { result!.current.handleStartOver() })
    expect(mockPush).toHaveBeenCalledWith('/')
  })
})
