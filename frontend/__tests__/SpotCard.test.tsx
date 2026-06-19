/**
 * @jest-environment jsdom
 */
import '@testing-library/jest-dom';
import { render, screen, fireEvent } from '@testing-library/react';
import SpotCard from '@/components/results/SpotCard';
import type { SpotRecommendation, UserPreferences } from '@/lib/types';

const spot: SpotRecommendation = {
  spotId: '00000000-0000-0000-0000-000000000001',
  name: 'Piha',
  region: 'Auckland',
  waveType: 'BeachBreak',
  minSkillLevel: 'Intermediate',
  typicalCrowd: 'Busy',
  currentWaveSize: 'HeadHigh',
  facilities: ['Bathrooms', 'Showers'],
  description: "Auckland's most famous surf beach.",
  score: 20,
  summary: 'Good match.',
  breakdown: {
    skillMatch: 0, boardMatch: 0, crowdMatch: 20,
    regionMatch: 0, waveTypeMatch: 0, waveSizeMatch: 0, facilityMatch: 0,
  },
};

const prefs: UserPreferences = {
  skillLevel: 'Intermediate',
  crowdTolerance: 'Busy',
  boardTypes: [],
  preferredWaveTypes: [],
  preferredWaveSizes: [],
  preferredFacilities: [],
};

describe('SpotCard', () => {
  it('renders the spot name', () => {
    render(<SpotCard spot={spot} preferences={prefs} onClick={jest.fn()} />);
    expect(screen.getByText('Piha')).toBeInTheDocument();
  });

  it('shows the match percentage', () => {
    render(<SpotCard spot={spot} preferences={prefs} onClick={jest.fn()} />);
    expect(screen.getByText('100% match')).toBeInTheDocument();
  });

  it('shows the region', () => {
    render(<SpotCard spot={spot} preferences={prefs} onClick={jest.fn()} />);
    expect(screen.getByText('Auckland')).toBeInTheDocument();
  });

  it('shows the description', () => {
    render(<SpotCard spot={spot} preferences={prefs} onClick={jest.fn()} />);
    expect(screen.getByText("Auckland's most famous surf beach.")).toBeInTheDocument();
  });

  it('shows wave type and wave size badges', () => {
    render(<SpotCard spot={spot} preferences={prefs} onClick={jest.fn()} />);
    expect(screen.getByText('Beach Break')).toBeInTheDocument();
    expect(screen.getByText('Head High')).toBeInTheDocument();
  });

  it('shows the crowd badge', () => {
    render(<SpotCard spot={spot} preferences={prefs} onClick={jest.fn()} />);
    expect(screen.getByText('Crowded')).toBeInTheDocument();
  });

  it('shows the skill level badge', () => {
    render(<SpotCard spot={spot} preferences={prefs} onClick={jest.fn()} />);
    expect(screen.getByText('Intermediate')).toBeInTheDocument();
  });

  it('fires onClick when the card is clicked', () => {
    const onClick = jest.fn();
    render(<SpotCard spot={spot} preferences={prefs} onClick={onClick} />);
    fireEvent.click(screen.getByRole('button'));
    expect(onClick).toHaveBeenCalledTimes(1);
  });
});
