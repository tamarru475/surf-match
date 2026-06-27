/**
 * @jest-environment jsdom
 */
import '@testing-library/jest-dom';
import { render, screen, fireEvent, act } from '@testing-library/react';
import QuestionScreen from '@/components/quiz/QuestionScreen';
import type { Question } from '@/lib/questions';

const facilitiesQuestion: Question = {
  field: 'preferredFacilities',
  title: 'Any facilities you need?',
  subtitle: 'Optional',
  required: false,
  multiSelect: true,
  noneValue: 'None',
  tooltipWarning: 'Many spots have no facilities nearby.',
  options: [
    { label: 'No facilities needed', value: 'None' },
    { label: 'Bathrooms', value: 'Bathrooms' },
    { label: 'Showers', value: 'Showers' },
  ],
};

const skillLevelQuestion: Question = {
  field: 'skillLevel',
  title: "What's your surf level?",
  subtitle: 'Required',
  required: true,
  multiSelect: false,
  tooltipTerms: [
    { label: 'New to surfing', description: 'Never been on a board.' },
    { label: 'Beginner', description: 'Still learning to stand up.' },
  ],
  options: [
    { label: 'New to surfing', value: 'NewToSurfing' },
    { label: 'Beginner', value: 'Beginner' },
  ],
};

const waveTypeQuestion: Question = {
  field: 'preferredWaveTypes',
  title: 'What type of waves are you after?',
  subtitle: 'Optional',
  required: false,
  multiSelect: true,
  tooltipItems: [
    { label: 'Beach Break', description: 'Sand bottom, most forgiving.', image: '/images/beachbreak.jpg' },
    { label: 'Point Break', description: 'Wraps around a headland.', image: '/images/pointbreak.jpg' },
    { label: 'Reef Break', description: 'Breaks over rock or coral.', image: '/images/reefbreak.jpg' },
  ],
  options: [
    { label: 'Beach Break', value: 'BeachBreak' },
    { label: 'Point Break', value: 'PointBreak' },
    { label: 'Reef Break', value: 'ReefBreak' },
  ],
};

describe('QuestionScreen — tooltip', () => {
  it('does not render a tooltip trigger when the question has none', () => {
    const noTooltip: Question = { ...facilitiesQuestion, tooltipWarning: undefined };
    render(<QuestionScreen question={noTooltip} value={[]} onChange={jest.fn()} />);
    expect(screen.queryByLabelText('More info')).not.toBeInTheDocument();
  });

  it('shows the warning text after clicking the info icon', () => {
    render(<QuestionScreen question={facilitiesQuestion} value={[]} onChange={jest.fn()} />);
    expect(screen.queryByText('Many spots have no facilities nearby.')).not.toBeInTheDocument();
    fireEvent.click(screen.getByLabelText('More info'));
    expect(screen.getByText('Many spots have no facilities nearby.')).toBeInTheDocument();
  });

  it('shows a separate label + description line per term for tooltipTerms questions', () => {
    render(<QuestionScreen question={skillLevelQuestion} value="" onChange={jest.fn()} />);
    fireEvent.click(screen.getByLabelText('More info'));
    expect(screen.getByText('Never been on a board.')).toBeInTheDocument();
    expect(screen.getByText('Still learning to stand up.')).toBeInTheDocument();
  });

  it('opens a full info modal with an image+description per item for tooltipItems questions', () => {
    render(<QuestionScreen question={waveTypeQuestion} value={[]} onChange={jest.fn()} />);
    expect(screen.queryByText('Sand bottom, most forgiving.')).not.toBeInTheDocument();

    fireEvent.click(screen.getByLabelText('More info'));

    expect(screen.getByRole('button', { name: 'Close' })).toBeInTheDocument();
    expect(screen.getByText('Sand bottom, most forgiving.')).toBeInTheDocument();
    expect(screen.getByText('Wraps around a headland.')).toBeInTheDocument();
    expect(screen.getByText('Breaks over rock or coral.')).toBeInTheDocument();
  });

  it('closes the info modal (after its exit animation) when the close button is clicked', () => {
    jest.useFakeTimers();
    render(<QuestionScreen question={waveTypeQuestion} value={[]} onChange={jest.fn()} />);
    fireEvent.click(screen.getByLabelText('More info'));
    expect(screen.getByRole('button', { name: 'Close' })).toBeInTheDocument();

    fireEvent.click(screen.getByRole('button', { name: 'Close' }));
    act(() => { jest.advanceTimersByTime(240); });
    expect(screen.queryByRole('button', { name: 'Close' })).not.toBeInTheDocument();
    jest.useRealTimers();
  });
});

describe('QuestionScreen — noneValue mutual exclusivity', () => {
  it('selecting "No facilities needed" clears any other selection', () => {
    const onChange = jest.fn();
    render(
      <QuestionScreen
        question={facilitiesQuestion}
        value={['Bathrooms']}
        onChange={onChange}
      />,
    );
    fireEvent.click(screen.getByRole('button', { name: 'No facilities needed' }));
    expect(onChange).toHaveBeenCalledWith(['None']);
  });

  it('selecting a real facility removes "None" from the answer', () => {
    const onChange = jest.fn();
    render(
      <QuestionScreen question={facilitiesQuestion} value={['None']} onChange={onChange} />,
    );
    fireEvent.click(screen.getByRole('button', { name: 'Bathrooms' }));
    expect(onChange).toHaveBeenCalledWith(['Bathrooms']);
  });

  it('clicking "None" again while selected deselects it', () => {
    const onChange = jest.fn();
    render(
      <QuestionScreen question={facilitiesQuestion} value={['None']} onChange={onChange} />,
    );
    fireEvent.click(screen.getByRole('button', { name: 'No facilities needed' }));
    expect(onChange).toHaveBeenCalledWith([]);
  });

  it('selecting multiple real facilities works normally', () => {
    const onChange = jest.fn();
    render(
      <QuestionScreen question={facilitiesQuestion} value={['Bathrooms']} onChange={onChange} />,
    );
    fireEvent.click(screen.getByRole('button', { name: 'Showers' }));
    expect(onChange).toHaveBeenCalledWith(['Bathrooms', 'Showers']);
  });
});
