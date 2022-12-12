namespace CampCleanup.Tests;

public class CleanupCalculatorTests : IClassFixture<CleanupCalculator>
{
    private readonly CleanupCalculator _fixture;
    public CleanupCalculatorTests(CleanupCalculator fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void Test_CorrectSectionRangeLength()
    {
        var input1 = new SectionRange(2, 8);
        var input2 = new SectionRange(3, 7);
        
        Assert.Equal(7, input1.Length);
        Assert.Equal(5, input2.Length);
    }

    [Fact]
    public void Test_RangeFullyContainsOther()
    {
        var input1 = new SectionRange(2, 8);
        var input2 = new SectionRange(3, 7);
        
        Assert.True(_fixture.RangeFullyContainsOther(input1, input2));
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
            .Select(s =>
            {
                var splitLine = s.Split(',');

                var range1 = splitLine[0].Split('-').Select(x => int.Parse(x)).ToArray();
                var sectionRange1 = new SectionRange(range1[0], range1[1]);

                var range2 = splitLine[1].Split('-').Select(x => int.Parse(x)).ToArray();
                var sectionRange2 = new SectionRange(range2[0], range2[1]);

                return new Tuple<SectionRange, SectionRange>(sectionRange1, sectionRange2);
            });
        
        Assert.Equal(100, _fixture.GetFullyOverlappingRanges(inputs));
    }
}