/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { useHomepageViewModel } from '@/app/page.viewmodel';

function setConnection(props: Record<string, unknown> | null) {
  Object.defineProperty(navigator, 'connection', {
    value: props,
    writable: true,
    configurable: true,
  });
}

beforeEach(() => {
  jest.useFakeTimers();
  setConnection(null);
});

afterEach(() => {
  jest.useRealTimers();
});

describe('connection detection', () => {
  it('attempts video on a fast connection', async () => {
    setConnection({ saveData: false, effectiveType: '4g' });
    let result: ReturnType<typeof renderHook<ReturnType<typeof useHomepageViewModel>, unknown>>['result'];
    await act(async () => { ({ result } = renderHook(() => useHomepageViewModel())); });
    expect(result!.current.tryVideo).toBe(true);
  });

  it('skips video when saveData is true', async () => {
    setConnection({ saveData: true, effectiveType: '4g' });
    let result: ReturnType<typeof renderHook<ReturnType<typeof useHomepageViewModel>, unknown>>['result'];
    await act(async () => { ({ result } = renderHook(() => useHomepageViewModel())); });
    expect(result!.current.tryVideo).toBe(false);
  });

  it.each(['2g', 'slow-2g'])('skips video on %s connection', async (effectiveType) => {
    setConnection({ saveData: false, effectiveType });
    let result: ReturnType<typeof renderHook<ReturnType<typeof useHomepageViewModel>, unknown>>['result'];
    await act(async () => { ({ result } = renderHook(() => useHomepageViewModel())); });
    expect(result!.current.tryVideo).toBe(false);
  });
});

describe('buffer timeout', () => {
  it('abandons video after 5s', async () => {
    setConnection({ saveData: false, effectiveType: '4g' });
    let result: ReturnType<typeof renderHook<ReturnType<typeof useHomepageViewModel>, unknown>>['result'];
    await act(async () => { ({ result } = renderHook(() => useHomepageViewModel())); });
    act(() => { jest.advanceTimersByTime(5000); });
    expect(result!.current.tryVideo).toBe(false);
  });

  it('clears timeout once video starts playing', async () => {
    setConnection({ saveData: false, effectiveType: '4g' });
    let result: ReturnType<typeof renderHook<ReturnType<typeof useHomepageViewModel>, unknown>>['result'];
    await act(async () => { ({ result } = renderHook(() => useHomepageViewModel())); });
    act(() => { result!.current.handlePlaying(); });
    act(() => { jest.advanceTimersByTime(5000); });
    expect(result!.current.tryVideo).toBe(true);
  });
});

describe('loop overlay', () => {
  it('sets loopFading when within 2s of end', async () => {
    setConnection({ saveData: false, effectiveType: '4g' });
    let result: ReturnType<typeof renderHook<ReturnType<typeof useHomepageViewModel>, unknown>>['result'];
    await act(async () => { ({ result } = renderHook(() => useHomepageViewModel())); });
    act(() => { result!.current.handleTimeUpdate(58.5, 60); });
    expect(result!.current.loopFading).toBe(true);
  });

  it('does not set loopFading when more than 2s remains', async () => {
    setConnection({ saveData: false, effectiveType: '4g' });
    let result: ReturnType<typeof renderHook<ReturnType<typeof useHomepageViewModel>, unknown>>['result'];
    await act(async () => { ({ result } = renderHook(() => useHomepageViewModel())); });
    act(() => { result!.current.handleTimeUpdate(57, 60); });
    expect(result!.current.loopFading).toBe(false);
  });

  it('clears loopFading once past the loop point (currentTime < 0.5)', async () => {
    setConnection({ saveData: false, effectiveType: '4g' });
    let result: ReturnType<typeof renderHook<ReturnType<typeof useHomepageViewModel>, unknown>>['result'];
    await act(async () => { ({ result } = renderHook(() => useHomepageViewModel())); });
    act(() => { result!.current.handleTimeUpdate(59.2, 60); });
    expect(result!.current.loopFading).toBe(true);
    act(() => { result!.current.handleTimeUpdate(0.1, 60); });
    expect(result!.current.loopFading).toBe(false);
  });
});
