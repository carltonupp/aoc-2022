namespace SupplyStacks;

public class Shipyard
{
    private readonly ICollection<CrateStack> _stacks = new List<CrateStack>();

    public Shipyard(params CrateStack[] stacks)
    {
        foreach (var stack in stacks)
        {
            _stacks.Add(stack);
        }
    }
    
    public IEnumerable<string> GetTopCratesOnEachStack()
    {
        return _stacks.OrderBy(s => s.ID).Select(stack => stack.Pop());
    }

    public CrateStack? GetCrateStack(int id)
    {
        return _stacks.FirstOrDefault(s => s.ID == id);
    }

    public void UpdateCrateStack(int id, CrateStack value)
    {
        var existing = _stacks.FirstOrDefault(s => s.ID == id);
        if (existing != null)
        {
            _stacks.Remove(existing);
        }
        _stacks.Add(value);
    }
}