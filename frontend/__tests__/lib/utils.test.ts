import { cx } from '@/lib/utils';

describe('cx', () => {
  it('joins multiple class names', () => {
    expect(cx('foo', 'bar')).toBe('foo bar');
  });

  it('filters out falsy values', () => {
    expect(cx('foo', false, undefined, null, 'bar')).toBe('foo bar');
  });

  it('returns empty string when all values are falsy', () => {
    expect(cx(false, undefined, null)).toBe('');
  });

  it('returns single class with no extra spaces', () => {
    expect(cx('only')).toBe('only');
  });
});
