/**
 * @jest-environment jsdom
 */
import '@testing-library/jest-dom';
import { render, screen, fireEvent } from '@testing-library/react';
import userEvent from '@testing-library/user-event';
import Button from '@/components/ui/Button';
import ProgressIndicator from '@/components/ui/ProgressIndicator';
import AnswerButton from '@/components/ui/AnswerButton';

// ── Button ────────────────────────────────────────────────────────────────────

describe('Button', () => {
  it('renders its children', () => {
    render(<Button>Click me</Button>);
    expect(screen.getByRole('button', { name: 'Click me' })).toBeInTheDocument();
  });

  it('is disabled when the disabled prop is set', () => {
    render(<Button disabled>Nope</Button>);
    expect(screen.getByRole('button')).toBeDisabled();
  });

  it('fires onClick when clicked', async () => {
    const onClick = jest.fn();
    render(<Button onClick={onClick}>Go</Button>);
    await userEvent.click(screen.getByRole('button'));
    expect(onClick).toHaveBeenCalledTimes(1);
  });

  it('does not fire onClick when disabled', async () => {
    const onClick = jest.fn();
    render(<Button disabled onClick={onClick}>Go</Button>);
    await userEvent.click(screen.getByRole('button'));
    expect(onClick).not.toHaveBeenCalled();
  });
});

// ── ProgressIndicator ─────────────────────────────────────────────────────────

describe('ProgressIndicator', () => {
  it('shows the current question number and total', () => {
    render(<ProgressIndicator current={3} total={7} />);
    expect(screen.getByText('Question 3 of 7')).toBeInTheDocument();
  });

  it('sets bar width to the correct percentage', () => {
    const { container } = render(<ProgressIndicator current={1} total={4} />);
    const fill = container.querySelector('[style]');
    expect(fill).toHaveStyle('width: 25%');
  });

  it('shows 100% width on the last step', () => {
    const { container } = render(<ProgressIndicator current={7} total={7} />);
    const fill = container.querySelector('[style]');
    expect(fill).toHaveStyle('width: 100%');
  });
});

// ── AnswerButton ──────────────────────────────────────────────────────────────

describe('AnswerButton', () => {
  it('renders the label', () => {
    render(<AnswerButton label="Beginner" selected={false} onClick={jest.fn()} />);
    expect(screen.getByRole('button', { name: 'Beginner' })).toBeInTheDocument();
  });

  it('applies the selected class when selected', () => {
    render(<AnswerButton label="Intermediate" selected={true} onClick={jest.fn()} />);
    expect(screen.getByRole('button')).toHaveClass('selected');
  });

  it('applies the unselected class when not selected', () => {
    render(<AnswerButton label="Intermediate" selected={false} onClick={jest.fn()} />);
    expect(screen.getByRole('button')).toHaveClass('unselected');
  });

  it('calls onClick when clicked', () => {
    const onClick = jest.fn();
    render(<AnswerButton label="Advanced" selected={false} onClick={onClick} />);
    fireEvent.click(screen.getByRole('button'));
    expect(onClick).toHaveBeenCalledTimes(1);
  });
});
