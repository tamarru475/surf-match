/**
 * @jest-environment jsdom
 */
import { act, renderHook } from '@testing-library/react';
import { useAuthModalViewModel } from '@/components/auth/AuthModal.viewmodel';

const mockPush = jest.fn();
const mockCloseAuthModal = jest.fn();
const mockUser = { id: 'user-123', email: 'test@example.com' };

jest.mock('next/navigation', () => ({
  useRouter: () => ({ push: mockPush, replace: mockPush }),
}));

jest.mock('../lib/AuthContext', () => ({
  useAuth: () => ({
    authModalOpen: true,
    authModalMode: 'login',
    closeAuthModal: mockCloseAuthModal,
    user: null,
  }),
}));

const mockSignInWithPassword = jest.fn();
const mockSignUp = jest.fn();
const mockSignInWithOAuth = jest.fn();

jest.mock('../lib/supabase', () => ({
  supabase: {
    auth: {
      signInWithPassword: (...args: unknown[]) => mockSignInWithPassword(...args),
      signUp: (...args: unknown[]) => mockSignUp(...args),
      signInWithOAuth: (...args: unknown[]) => mockSignInWithOAuth(...args),
    },
  },
}));

jest.mock('../lib/api', () => ({
  fetchUserPreferences: jest.fn(),
}));

beforeEach(() => jest.clearAllMocks());

describe('useAuthModalViewModel — mode toggle', () => {
  it('starts in login mode by default', () => {
    const { result } = renderHook(() => useAuthModalViewModel());
    expect(result.current.mode).toBe('login');
  });

  it('toggleMode switches between login and signup', async () => {
    const { result } = renderHook(() => useAuthModalViewModel());
    await act(async () => { result.current.toggleMode(); });
    expect(result.current.mode).toBe('signup');
    await act(async () => { result.current.toggleMode(); });
    expect(result.current.mode).toBe('login');
  });

  it('toggleMode clears the error', async () => {
    mockSignInWithPassword.mockResolvedValue({ error: { message: 'Invalid credentials' } });
    const { result } = renderHook(() => useAuthModalViewModel());
    await act(async () => { result.current.setEmail('a@b.com'); result.current.setPassword('wrong'); });
    await act(async () => { await result.current.handleSubmit(); });
    expect(result.current.error).toBe('Invalid credentials');
    await act(async () => { result.current.toggleMode(); });
    expect(result.current.error).toBeNull();
  });
});

describe('useAuthModalViewModel — email/password submit', () => {
  it('calls signInWithPassword in login mode', async () => {
    mockSignInWithPassword.mockResolvedValue({ error: null });
    const { result } = renderHook(() => useAuthModalViewModel());
    await act(async () => {
      result.current.setEmail('surf@nz.com');
      result.current.setPassword('password123');
    });
    await act(async () => { await result.current.handleSubmit(); });
    expect(mockSignInWithPassword).toHaveBeenCalledWith({
      email: 'surf@nz.com',
      password: 'password123',
    });
  });

  it('calls signUp in signup mode', async () => {
    mockSignUp.mockResolvedValue({ error: null });
    const { result } = renderHook(() => useAuthModalViewModel());
    await act(async () => { result.current.toggleMode(); });
    await act(async () => {
      result.current.setEmail('new@nz.com');
      result.current.setPassword('securepass');
    });
    await act(async () => { await result.current.handleSubmit(); });
    expect(mockSignUp).toHaveBeenCalledWith({ email: 'new@nz.com', password: 'securepass' });
  });

  it('sets error when auth fails', async () => {
    mockSignInWithPassword.mockResolvedValue({ error: { message: 'Invalid login credentials' } });
    const { result } = renderHook(() => useAuthModalViewModel());
    await act(async () => { await result.current.handleSubmit(); });
    expect(result.current.error).toBe('Invalid login credentials');
    expect(result.current.loading).toBe(false);
  });

  it('clears error and sets loading on a fresh submit attempt', async () => {
    mockSignInWithPassword.mockResolvedValue({ error: null });
    const { result } = renderHook(() => useAuthModalViewModel());
    await act(async () => { await result.current.handleSubmit(); });
    expect(result.current.error).toBeNull();
    expect(result.current.loading).toBe(false);
  });
});
