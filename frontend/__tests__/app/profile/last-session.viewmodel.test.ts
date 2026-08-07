/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { isToday, useLastSessionViewModel } from '@/app/profile/last-session/last-session.viewmodel';
import type { SurfSession } from '@/lib/types';

const mockFetchLastSession = jest.fn();
jest.mock('../../../lib/api', () => ({
  ...jest.requireActual('../../../lib/api'),
  fetchLastSession: (...args: unknown[]) => mockFetchLastSession(...args),
}));

const TODAY = '2026-07-19T08:00:00Z';
const YESTERDAY = '2026-07-18T10:00:00Z';

const makeSession = (surfedAt: string): SurfSession => ({
  sessionId: 'sess-1',
  spotId: 'spot-1',
  spotName: 'Piha',
  region: 'Auckland',
  waveType: 'BeachBreak',
  currentWaveSize: 'WaistHigh',
  surfedAt,
});

beforeEach(() => {
  jest.useFakeTimers();
  jest.setSystemTime(new Date('2026-07-19T12:00:00Z'));
  jest.clearAllMocks();
});

afterEach(() => {
  jest.useRealTimers();
});

describe('isToday', () => {
  it('returns true for a timestamp from the same UTC day', () => {
    expect(isToday(TODAY)).toBe(true);
  });

  it('returns false for yesterday', () => {
    expect(isToday(YESTERDAY)).toBe(false);
  });

  it('returns false for a date weeks ago', () => {
    expect(isToday('2026-07-01T12:00:00Z')).toBe(false);
  });
});

describe('useLastSessionViewModel', () => {
  it('starts in loading state', () => {
    mockFetchLastSession.mockResolvedValue(null);
    const { result } = renderHook(() => useLastSessionViewModel());
    expect(result.current.loading).toBe(true);
  });

  it('isActive is false when there is no session', async () => {
    mockFetchLastSession.mockResolvedValue(null);
    let result: ReturnType<typeof renderHook<ReturnType<typeof useLastSessionViewModel>, unknown>>['result'];
    await act(async () => {
      ({ result } = renderHook(() => useLastSessionViewModel()));
    });
    expect(result!.current.isActive).toBe(false);
    expect(result!.current.loading).toBe(false);
  });

  it('isActive is true when the session was logged today', async () => {
    mockFetchLastSession.mockResolvedValue(makeSession(TODAY));
    let result: ReturnType<typeof renderHook<ReturnType<typeof useLastSessionViewModel>, unknown>>['result'];
    await act(async () => {
      ({ result } = renderHook(() => useLastSessionViewModel()));
    });
    expect(result!.current.isActive).toBe(true);
  });

  it('isActive is false when the session was logged on a previous day', async () => {
    mockFetchLastSession.mockResolvedValue(makeSession(YESTERDAY));
    let result: ReturnType<typeof renderHook<ReturnType<typeof useLastSessionViewModel>, unknown>>['result'];
    await act(async () => {
      ({ result } = renderHook(() => useLastSessionViewModel()));
    });
    expect(result!.current.isActive).toBe(false);
  });

  it('handleDone sets isActive to false', async () => {
    mockFetchLastSession.mockResolvedValue(makeSession(TODAY));
    let result: ReturnType<typeof renderHook<ReturnType<typeof useLastSessionViewModel>, unknown>>['result'];
    await act(async () => {
      ({ result } = renderHook(() => useLastSessionViewModel()));
    });
    expect(result!.current.isActive).toBe(true);
    act(() => { result!.current.handleDone(); });
    expect(result!.current.isActive).toBe(false);
  });

  it('sets error when the API fails', async () => {
    mockFetchLastSession.mockRejectedValue(new Error('Network error'));
    let result: ReturnType<typeof renderHook<ReturnType<typeof useLastSessionViewModel>, unknown>>['result'];
    await act(async () => {
      ({ result } = renderHook(() => useLastSessionViewModel()));
    });
    expect(result!.current.error).toBeTruthy();
    expect(result!.current.loading).toBe(false);
  });
});
