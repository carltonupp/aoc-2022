namespace SupplyStacks;

public class Shipyard
{
    private ICollection<CrateStack> _stacks = new List<CrateStack>();

    public Shipyard(params CrateStack[] stacks)
    {
        foreach (var stack in stacks)
        {
            _stacks.Add(stack);
        }
    }
    
    public IEnumerable<string> GetTopCratesOnEachStack()
    {
        return _stacks.Select(stack => stack.Pop()).ToList();
    }

    public CrateStack? GetCrateStack(int id)
    {
        return _stacks.FirstOrDefault(s => s.ID == id);
    }

    public void UpdateCrateStack(int id, CrateStack value)
    {
        
    }
}