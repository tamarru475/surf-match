/**
 * @jest-environment jsdom
 */
import '@testing-library/jest-dom';
import { render, screen, fireEvent, act } from '@testing-library/react';
import SpotModal from '@/components/results/SpotModal';
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
  notes: [],
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

describe('SpotModal', () => {
  beforeEach(() => jest.useFakeTimers());
  afterEach(() => jest.useRealTimers());

  it('renders the spot name and description', () => {
    render(<SpotModal spot={spot} preferences={prefs} onClose={jest.fn()} />);
    expect(screen.getByRole('heading', { name: 'Piha' })).toBeInTheDocument();
    expect(screen.getByText("Auckland's most famous surf beach.")).toBeInTheDocument();
  });

  it('shows wave type and current height in the detail grid', () => {
    render(<SpotModal spot={spot} preferences={prefs} onClose={jest.fn()} />);
    expect(screen.getByText('Beach Break')).toBeInTheDocument();
    expect(screen.getByText('Head High')).toBeInTheDocument();
  });

  it('shows skill level and crowd in the detail grid', () => {
    render(<SpotModal spot={spot} preferences={prefs} onClose={jest.fn()} />);
    expect(screen.getByText('Intermediate')).toBeInTheDocument();
    expect(screen.getByText('Busy')).toBeInTheDocument();
  });

  it('shows facility chips', () => {
    render(<SpotModal spot={spot} preferences={prefs} onClose={jest.fn()} />);
    expect(screen.getByText('Bathrooms')).toBeInTheDocument();
    expect(screen.getByText('Showers')).toBeInTheDocument();
  });

  it('does not show the Notes section when there are no notes', () => {
    render(<SpotModal spot={spot} preferences={prefs} onClose={jest.fn()} />);
    expect(screen.queryByText('Notes')).not.toBeInTheDocument();
  });

  it('shows each note as a separate list item', () => {
    const withNotes = {
      ...spot,
      notes: ['None of your boards are ideal for this spot.', 'Big conditions today.'],
    };
    render(<SpotModal spot={withNotes} preferences={prefs} onClose={jest.fn()} />);
    expect(screen.getByText('Notes')).toBeInTheDocument();
    expect(screen.getByText('None of your boards are ideal for this spot.')).toBeInTheDocument();
    expect(screen.getByText('Big conditions today.')).toBeInTheDocument();
  });

  it('calls onClose after 240ms when the close button is clicked', () => {
    const onClose = jest.fn();
    render(<SpotModal spot={spot} preferences={prefs} onClose={onClose} />);
    fireEvent.click(screen.getByRole('button', { name: 'Close' }));
    expect(onClose).not.toHaveBeenCalled();
    act(() => { jest.advanceTimersByTime(240); });
    expect(onClose).toHaveBeenCalledTimes(1);
  });

  it('calls onClose after 240ms when Escape is pressed', () => {
    const onClose = jest.fn();
    render(<SpotModal spot={spot} preferences={prefs} onClose={onClose} />);
    fireEvent.keyDown(window, { key: 'Escape' });
    expect(onClose).not.toHaveBeenCalled();
    act(() => { jest.advanceTimersByTime(240); });
    expect(onClose).toHaveBeenCalledTimes(1);
  });

  it('shows the match percentage', () => {
    render(<SpotModal spot={spot} preferences={prefs} onClose={jest.fn()} />);
    expect(screen.getByText('100% match')).toBeInTheDocument();
  });
});
