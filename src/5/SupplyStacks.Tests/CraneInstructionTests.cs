namespace SupplyStacks.Tests;

public class CraneInstructionTests
{
    [Fact]
    public void CraneStackInstructions_Test()
    {
        var instruction = CraneInstruction.ParseFromString("move 1 from 2 to 1");
        Assert.Equal(1, instruction.Take);
        Assert.Equal(2, instruction.From);
        Assert.Equal(1, instruction.To);
    }
}