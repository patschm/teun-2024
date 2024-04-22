namespace ACME.Domain.Reviews.ValueObjects;

public record Date
{
    public Date(int year, int month, int day)
    {
        var date = new DateTime(year, month, day);
        Year = year;
        Month = month;
        Day = day;
    }
    public int Year { get; init; }
    public int Month { get; init; }
    public int Day { get; init; }

    public static implicit operator Date(DateTime date)
    {
        return new Date(date.Year, date.Month, date.Day);
    }
}
