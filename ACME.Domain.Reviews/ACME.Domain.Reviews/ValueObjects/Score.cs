namespace ACME.Domain.Reviews.ValueObjects;

public record Score
{
    public Score(byte score)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThan(score, 5);
        ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(score, 0);
        Value = score;      
    }
    public byte Value { get; init; }

    public static implicit operator Score(byte value)
    {
        return new Score(value);
    }
}
