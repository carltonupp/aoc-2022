namespace SupplyStacks.Tests;

public class CargoCraneTests
{
    [Fact]
    public void Can_ProcessInstruction()
    {
        var crate1 = new CrateStack(1) { new[] { "Z", "N" } };
        var crate2 = new CrateStack(2) { new[] { "M", "C", "D" } };
        var crate3 = new CrateStack(3) { new[] { "P" } };
        
        var shipyard = new Shipyard(crate1, crate2, crate3);
        var instruction = CraneInstruction.ParseFromString("move 1 from 2 to 1");

        shipyard = CargoCrane.ProcessInstructionOnShipyard(instruction, shipyard);
        
        var result = shipyard.GetCrateStack(1)?.Pop();

        Assert.Equal("D", result);
    }
}