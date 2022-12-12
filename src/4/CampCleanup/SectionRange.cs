namespace CampCleanup;

public record SectionRange(int Start, int End)
{
    public int Length => End - Start + 1;
}