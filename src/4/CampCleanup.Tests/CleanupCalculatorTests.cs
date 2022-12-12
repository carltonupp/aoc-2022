namespace CampCleanup.Tests;

public class CleanupCalculatorTests : IClassFixture<CleanupCalculator>
{
    private readonly CleanupCalculator _fixture;
    public CleanupCalculatorTests(CleanupCalculator fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Part1_SampleInputs()
    {
        var inputs = new List<Tuple<SectionRange, SectionRange>>
        {
            new(new SectionRange(2, 4), new SectionRange(6, 8)),
            new(new SectionRange(2, 3), new SectionRange(4, 5)),
            new(new SectionRange(5, 7), new SectionRange(7, 9)),
            new(new SectionRange(2, 8), new SectionRange(3, 7)),
            new(new SectionRange(6, 6), new SectionRange(4, 6)),
            new(new SectionRange(2, 6), new SectionRange(4, 8))
        };
        
        Assert.Equal(2, _fixture.GetFullyOverlappingRanges(inputs));
    }

    [Fact]
    public void Part1_RealInputs()
    {
        var inputs = File.ReadLines("./inputs.txt")
            .Select(TurnLineIntoSectionRangeTuple);
        
        Assert.Equal(496, _fixture.GetFullyOverlappingRanges(inputs));
    }

    [Fact]
    public void Part2_SampleInputs()
    {
        var inputs = new List<Tuple<SectionRange, SectionRange>>
        {
            new(new SectionRange(2, 4), new SectionRange(6, 8)),
            new(new SectionRange(2, 3), new SectionRange(4, 5)),
            new(new SectionRange(5, 7), new SectionRange(7, 9)),
            new(new SectionRange(2, 8), new SectionRange(3, 7)),
            new(new SectionRange(6, 6), new SectionRange(4, 6)),
            new(new SectionRange(2, 6), new SectionRange(4, 8))
        };
        
        Assert.Equal(4, _fixture.GetPartiallyOverlappingRanges(inputs));
    }

    [Fact]
    public void Part2_RealInputs()
    {
        var inputs = File.ReadLines("./inputs.txt")
            .Select(TurnLineIntoSectionRangeTuple);
        
        Assert.Equal(847, _fixture.GetPartiallyOverlappingRanges(inputs));
    }

    private static Tuple<SectionRange, SectionRange> TurnLineIntoSectionRangeTuple(string line)
    {
        return line.Split(',').Select(TurnSubStringIntoSectionRange).ToArray() switch
        {
            [var first, var last] => new Tuple<SectionRange, SectionRange>(first, last),
            _ => throw new Exception()
        };
    }

    private static SectionRange TurnSubStringIntoSectionRange(string str)
    {
        return str.Split('-').Select(int.Parse).ToArray() switch
        {
            [var start, var end] => new SectionRange(start, end),
            _ => throw new Exception()
        };
    }
}