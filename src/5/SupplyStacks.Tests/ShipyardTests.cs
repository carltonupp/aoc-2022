namespace SupplyStacks.Tests;

public class ShipyardTests
{
    [Fact]
    public void CanGetTopCratesFromEachStack()
    {
        var crate1 = new CrateStack(1) { new[] { "C" } };
        var crate2 = new CrateStack(2) { new[] { "M" } };
        var crate3 = new CrateStack(3) { new[] { "P", "D", "N", "Z" } };

        var shipyard = new Shipyard(crate1, crate2, crate3);
        var topResults = shipyard.GetTopCratesOnEachStack().ToArray();
        
        Assert.Equal("C", topResults[0]);
        Assert.Equal("M", topResults[1]);
        Assert.Equal("Z", topResults[2]);
    }
}