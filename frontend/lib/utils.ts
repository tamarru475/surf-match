/** Joins truthy class names — lightweight alternative to clsx. */
export const cx = (...args: (string | undefined | false | null)[]): string =>
  args.filter(Boolean).join(' ');
