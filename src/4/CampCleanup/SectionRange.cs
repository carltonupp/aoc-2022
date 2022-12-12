namespace CampCleanup;

public record SectionRange(int Start, int End)
{
    public int Length => End - Start + 1;
}

public static class SectionRangeExtensions
{
    public static IEnumerable<int> ToEnumerable(this SectionRange @this) => 
        Enumerable.Range(@this.Start, @this.Length);
}