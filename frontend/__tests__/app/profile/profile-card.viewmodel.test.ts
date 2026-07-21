/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { useProfileCardViewModel } from '@/app/profile/profile-card/profile-card.viewmodel';
import type { Profile } from '@/lib/types';

const mockUpdateProfile = jest.fn();
const mockUploadAvatar = jest.fn();
jest.mock('../../../lib/api', () => ({
  ...jest.requireActual('../../../lib/api'),
  updateProfile: (...args: unknown[]) => mockUpdateProfile(...args),
  uploadAvatar:  (...args: unknown[]) => mockUploadAvatar(...args),
}));

const mockCreateObjectURL = jest.fn(() => 'blob:fake-url');
const mockRevokeObjectURL = jest.fn();
Object.defineProperty(URL, 'createObjectURL', { writable: true, value: mockCreateObjectURL });
Object.defineProperty(URL, 'revokeObjectURL',  { writable: true, value: mockRevokeObjectURL });

const FAKE_PROFILE: Profile = {
  id: 'user-1',
  email: 'tamar@example.com',
  displayName: 'Tamar',
  avatarUrl: null,
  location: 'Auckland',
  bio: 'Loves big waves',
  instagramHandle: 'tamar_surfs',
  tikTokHandle: null,
};

beforeEach(() => {
  jest.clearAllMocks();
});

describe('useProfileCardViewModel — seed state', () => {
  it('seeds fields from profile prop', () => {
    const { result } = renderHook(() => useProfileCardViewModel(FAKE_PROFILE));

    expect(result.current.displayName).toBe('Tamar');
    expect(result.current.location).toBe('Auckland');
    expect(result.current.bio).toBe('Loves big waves');
    expect(result.current.instagramHandle).toBe('tamar_surfs');
    expect(result.current.tikTokHandle).toBe('');
    expect(result.current.avatarLetter).toBe('T');
  });

  it('isDirty is false after seeding', () => {
    const { result } = renderHook(() => useProfileCardViewModel(FAKE_PROFILE));
    expect(result.current.isDirty).toBe(false);
  });
});

describe('useProfileCardViewModel — dirty state', () => {
  it('isDirty is true when a field is changed', () => {
    const { result } = renderHook(() => useProfileCardViewModel(FAKE_PROFILE));
    act(() => { result.current.setDisplayName('Someone Else'); });
    expect(result.current.isDirty).toBe(true);
  });

  it('isDirty resets to false after save', async () => {
    mockUpdateProfile.mockResolvedValue({ ...FAKE_PROFILE, displayName: 'New Name' });

    const { result } = renderHook(() => useProfileCardViewModel(FAKE_PROFILE));
    act(() => { result.current.setDisplayName('New Name'); });
    await act(async () => { await result.current.handleSave(); });

    expect(result.current.isDirty).toBe(false);
    expect(result.current.saveSuccess).toBe(true);
  });
});

describe('useProfileCardViewModel — avatar crop flow', () => {
  const fakeFile = new File(['img'], 'photo.jpg', { type: 'image/jpeg' });
  const fakeBlob = new Blob(['img'], { type: 'image/jpeg' });

  it('handleFilePicked sets pendingImageSrc via createObjectURL', () => {
    const { result } = renderHook(() => useProfileCardViewModel(FAKE_PROFILE));
    act(() => { result.current.handleFilePicked(fakeFile); });
    expect(mockCreateObjectURL).toHaveBeenCalledWith(fakeFile);
    expect(result.current.pendingImageSrc).toBe('blob:fake-url');
  });

  it('handleCropCancel clears pendingImageSrc and revokes object URL', () => {
    const { result } = renderHook(() => useProfileCardViewModel(FAKE_PROFILE));
    act(() => { result.current.handleFilePicked(fakeFile); });
    act(() => { result.current.handleCropCancel(); });
    expect(result.current.pendingImageSrc).toBeNull();
    expect(mockRevokeObjectURL).toHaveBeenCalledWith('blob:fake-url');
  });

  it('handleCropConfirm uploads blob and sets avatarUrl on success', async () => {
    const updatedProfile = { ...FAKE_PROFILE, avatarUrl: 'https://cdn.example.com/avatar.jpg' };
    mockUploadAvatar.mockResolvedValue(updatedProfile);

    const { result } = renderHook(() => useProfileCardViewModel(FAKE_PROFILE));
    act(() => { result.current.handleFilePicked(fakeFile); });
    await act(async () => { await result.current.handleCropConfirm(fakeBlob); });

    expect(mockUploadAvatar).toHaveBeenCalledWith(expect.any(File));
    expect(result.current.avatarUrl).toBe('https://cdn.example.com/avatar.jpg');
    expect(result.current.pendingImageSrc).toBeNull();
    expect(result.current.error).toBeNull();
  });

  it('handleCropConfirm sets error and clears pending on failure', async () => {
    mockUploadAvatar.mockRejectedValue(new Error('500'));

    const { result } = renderHook(() => useProfileCardViewModel(FAKE_PROFILE));
    act(() => { result.current.handleFilePicked(fakeFile); });
    await act(async () => { await result.current.handleCropConfirm(fakeBlob); });

    expect(result.current.error).toBe('Failed to upload photo. Please try again.');
    expect(result.current.pendingImageSrc).toBeNull();
    expect(result.current.avatarUrl).toBeNull();
  });
});

describe('useProfileCardViewModel — save', () => {
  it('calls updateProfile with trimmed values and sets saveSuccess', async () => {
    mockUpdateProfile.mockResolvedValue({ ...FAKE_PROFILE, displayName: 'Tamar R' });

    const { result } = renderHook(() => useProfileCardViewModel(FAKE_PROFILE));
    act(() => { result.current.setDisplayName('  Tamar R  '); });
    await act(async () => { await result.current.handleSave(); });

    expect(mockUpdateProfile).toHaveBeenCalledWith(expect.objectContaining({ displayName: 'Tamar R' }));
    expect(result.current.saveSuccess).toBe(true);
  });

  it('sets error when updateProfile fails', async () => {
    mockUpdateProfile.mockRejectedValue(new Error('500'));

    const { result } = renderHook(() => useProfileCardViewModel(FAKE_PROFILE));
    await act(async () => { await result.current.handleSave(); });

    expect(result.current.error).toBe('Failed to save. Please try again.');
  });
});
