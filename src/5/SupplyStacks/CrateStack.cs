namespace SupplyStacks;

public class CrateStack : Stack<string>
{
    public CrateStack(int id)
    {
        ID = id;
    }

    public int ID { get; }

    public ICollection<string> Take(int number)
    {
        var crates = new List<string>();

        for (var i = 1; i <= number; i++)
        {
            var crate = Pop();
            crates.Add(crate);
        }

        return crates;
    }

    public void Add(IEnumerable<string> crates)
    {
        foreach (var crate in crates)
        {
            Push(crate);
        }
    }
}