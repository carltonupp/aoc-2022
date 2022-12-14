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

    [Fact]
    public void CanGetTopCratesFromEachStack_SampleInputs()
    {
        var crate1 = new CrateStack(1) { new[] { "Z", "N" } };
        var crate2 = new CrateStack(2) { new[] { "M", "C", "D" } };
        var crate3 = new CrateStack(3) { new[] { "P" } };
        
        var shipyard = new Shipyard(crate1, crate2, crate3);
        var instructions = new List<string>
        {
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        }.Select(CraneInstruction.ParseFromString);

        foreach (var instruction in instructions)
        {
            shipyard = CargoCrane.ProcessInstructionOnShipyard(instruction, shipyard);
        }
        
        var topResults = shipyard.GetTopCratesOnEachStack().ToArray();
        
        Assert.Equal("C", topResults[0]);
        Assert.Equal("M", topResults[1]);
        Assert.Equal("Z", topResults[2]);
    }
}