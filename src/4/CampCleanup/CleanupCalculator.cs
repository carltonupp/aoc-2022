namespace CampCleanup;

public static class CleanupCalculator
{
    public static int GetFullyOverlappingRanges(IEnumerable<Tuple<SectionRange, SectionRange>> ranges) =>
        ranges.Count(r =>
        {
            var (common, smallest) = (r.Item1.Length, r.Item2.Length) switch
            {
                var (r1, r2) when r1 > r2 => new Tuple<IEnumerable<int>, IEnumerable<int>>(
                    IntersectSectionRanges(r.Item1, r.Item2), r.Item2.ToEnumerable()),
                var (r1, r2) when r2 > r1 => new Tuple<IEnumerable<int>, IEnumerable<int>>(
                    IntersectSectionRanges(r.Item2, r.Item1), r.Item1.ToEnumerable()),
                _ => new Tuple<IEnumerable<int>, IEnumerable<int>>(IntersectSectionRanges(r.Item1, r.Item2),
                    r.Item2.ToEnumerable())
            };

            return common.Count() == smallest.Count()
                   && !common.Except(smallest).Any();
        });

    public static int GetPartiallyOverlappingRanges(IEnumerable<Tuple<SectionRange, SectionRange>> ranges) =>
        ranges.Count(r => r.Item1.ToEnumerable()
            .Intersect(r.Item2.ToEnumerable())
            .Any());

    private static IEnumerable<int> IntersectSectionRanges(SectionRange largest, SectionRange smallest)
    {
        return largest.ToEnumerable().Intersect(
            smallest.ToEnumerable());
    }
}