using ACME.Domain.Reviews.ValueObjects;

namespace ACME.Domain.Reviews.Tests;

public class DateTest
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1999, 0, 0)]
    public void Should_Throw_Exception(int year, int month, int day)
    {
        Assert.ThrowsAny<ArgumentOutOfRangeException>(() =>  new Date(year, month, day)); 
    }

    [Theory]
    [InlineData(2001, 1, 1)]
    public void Should_Be_Valid(int year, int month, int day)
    {
        var date = new Date(year, month, day);

        Assert.NotNull(date);
        Assert.Equal(year, date.Year);
        Assert.Equal(month, date.Month);
        Assert.Equal(day, date.Day);
    }

    [Fact]
    public void DateTime_Should_Be_Valid()
    {
        var dt = new DateTime(2005, 9, 9);

        Date date = dt;

        Assert.NotNull(date);
        Assert.Equal(dt.Year, date.Year);
        Assert.Equal(dt.Month, date.Month);
        Assert.Equal(dt.Day, date.Day);
    }
}
