import type { Config } from 'jest';
import nextJest from 'next/jest.js';

const createJestConfig = nextJest({ dir: './' });

const config: Config = {
  testEnvironment: 'node',
  forceExit: true,
  // .next/dev/cache can contain large Turbopack .sst cache files that the
  // default crawler will otherwise try to read, causing multi-minute hangs.
  modulePathIgnorePatterns: ['<rootDir>/.next/'],
  watchPathIgnorePatterns: ['<rootDir>/.next/'],
};

export default createJestConfig(config);
