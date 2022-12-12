namespace CampCleanup.Tests;

public class CleanupCalculatorTests : IClassFixture<CleanupCalculator>
{
    private readonly CleanupCalculator _fixture;
    public CleanupCalculatorTests(CleanupCalculator fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_RangeFullyContainsOther()
    {
        var input1 = new Range(2, 8);
        var input2 = new Range(3, 7);
        
        Assert.True(_fixture.RangeFullyContainsOther(input1, input2));
    }
}