/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { useAvatarCropModalViewModel } from '@/components/profile/AvatarCropModal.viewmodel';
import type { Area } from 'react-easy-crop';

const FAKE_BLOB = new Blob(['img'], { type: 'image/jpeg' });
const mockGetCroppedBlob = jest.fn().mockResolvedValue(FAKE_BLOB);

jest.mock('../../../lib/cropImage', () => ({
  getCroppedBlob: (...args: unknown[]) => mockGetCroppedBlob(...args),
}));

const FAKE_CROP_PIXELS: Area = { x: 10, y: 20, width: 300, height: 300 };

beforeEach(() => jest.clearAllMocks());

describe('useAvatarCropModalViewModel — initial state', () => {
  it('starts with default crop, zoom 1, and saving false', () => {
    const { result } = renderHook(() =>
      useAvatarCropModalViewModel('blob:fake', jest.fn())
    );
    expect(result.current.crop).toEqual({ x: 0, y: 0 });
    expect(result.current.zoom).toBe(1);
    expect(result.current.saving).toBe(false);
  });
});

describe('useAvatarCropModalViewModel — crop interactions', () => {
  it('setCrop updates the crop position', () => {
    const { result } = renderHook(() =>
      useAvatarCropModalViewModel('blob:fake', jest.fn())
    );
    act(() => { result.current.setCrop({ x: 50, y: 30 }); });
    expect(result.current.crop).toEqual({ x: 50, y: 30 });
  });

  it('setZoom updates the zoom level', () => {
    const { result } = renderHook(() =>
      useAvatarCropModalViewModel('blob:fake', jest.fn())
    );
    act(() => { result.current.setZoom(2.5); });
    expect(result.current.zoom).toBe(2.5);
  });
});

describe('useAvatarCropModalViewModel — handleSave', () => {
  it('does nothing when croppedAreaPixels is null', async () => {
    const onConfirm = jest.fn();
    const { result } = renderHook(() =>
      useAvatarCropModalViewModel('blob:fake', onConfirm)
    );
    await act(async () => { await result.current.handleSave(); });
    expect(mockGetCroppedBlob).not.toHaveBeenCalled();
    expect(onConfirm).not.toHaveBeenCalled();
  });

  it('calls getCroppedBlob and onConfirm with the resulting blob', async () => {
    const onConfirm = jest.fn();
    const { result } = renderHook(() =>
      useAvatarCropModalViewModel('blob:fake-src', onConfirm)
    );

    act(() => { result.current.handleCropComplete({} as Area, FAKE_CROP_PIXELS); });
    await act(async () => { await result.current.handleSave(); });

    expect(mockGetCroppedBlob).toHaveBeenCalledWith('blob:fake-src', FAKE_CROP_PIXELS);
    expect(onConfirm).toHaveBeenCalledWith(FAKE_BLOB);
  });
});
