namespace CampCleanup;

public class CleanupCalculator
{
    public int GetFullyOverlappingRanges(IEnumerable<Tuple<SectionRange, SectionRange>> ranges)
    {
        return ranges.Where(r =>
        {
            var (r1, r2) = r;
            return RangeFullyContainsOther(r1, r2);
        }).Count();
    }
    
    private static bool RangeFullyContainsOther(SectionRange range1, SectionRange range2)
    {
        var (common, smallest) = (range1.Length, range2.Length) switch
        {
            var (r1, r2) when r1 > r2 => new Tuple<IEnumerable<int>, SectionRange>(
                IntersectSectionRanges(range1, range2), range2),
            var (r1, r2) when r2 > r1 => new Tuple<IEnumerable<int>, SectionRange>(
                IntersectSectionRanges(range2, range1), range1),
            _ => new Tuple<IEnumerable<int>, SectionRange>(IntersectSectionRanges(range1, range2), range2)
        };

        var enumerated = EnumerateSectionRange(smallest);

        return common.Count() == enumerated.Count()
               && !common.Except(enumerated).Any();
    }

    private static IEnumerable<int> IntersectSectionRanges(SectionRange largest, SectionRange smallest)
    {
        return EnumerateSectionRange(largest)
            .Intersect(
                EnumerateSectionRange(smallest));
    }

    private static IEnumerable<int> EnumerateSectionRange(SectionRange sr)
    {
        return Enumerable.Range(sr.Start, sr.Length);
    }
}