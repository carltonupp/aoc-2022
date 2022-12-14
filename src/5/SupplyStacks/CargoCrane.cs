namespace SupplyStacks;
public class CargoCrane
{
    public static Shipyard ProcessInstructionOnShipyard(CraneInstruction instruction, Shipyard shipyard)
    {
        var from = shipyard.GetCrateStack(instruction.From);
        var to = shipyard.GetCrateStack(instruction.To);

        var moved = from?.Take(instruction.Take);
        to?.Add(moved);
        
        shipyard.UpdateCrateStack(from.ID, from);
        shipyard.UpdateCrateStack(to.ID, to);

        return shipyard;
    }
}
