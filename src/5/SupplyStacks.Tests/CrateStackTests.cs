namespace SupplyStacks.Tests;

public class CrateStackTests
{
    [Fact]
    public void Can_CreateCrateStack_WithID()
    {
        var stack = new CrateStack(1);
        Assert.Equal(1, stack.ID);
    }

    [Fact]
    public void Can_TakeItemsFromCrateStack()
    {
        var stack = new CrateStack(1) { new List<string>{"A", "B", "C"} };

        var takeTwo = stack.Take(2);
        Assert.Equal(2, takeTwo.Count());
        Assert.Equal("C", takeTwo.First());
        Assert.Equal("B", takeTwo.Last());
    }
}