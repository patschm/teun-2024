using ACME.Domain.Reviews.ValueObjects;

namespace ACME.Domain.Reviews.Tests;

public class ScoreTest
{
    [Theory]
   // [InlineData(-1)]
    [InlineData(0)]
    [InlineData(6)]
    public void Should_Throw_Exception_If_OutOfRange(byte value)
    {
        // Arrange
        //Score s1 = new Score(4);
        //Score s2 = 4;

        // Act
        Assert.Throws<ArgumentOutOfRangeException>(() => new Score(value));

        //Assert
    }

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    public void Should_Be_Valid(byte value)
    {
        // Arrange
        Score score = value;

        // Act
        

        //Assert
        Assert.NotNull(score);
        Assert.IsType<Score>(score);    
        Assert.Equal(value, score.Value);
    }
}