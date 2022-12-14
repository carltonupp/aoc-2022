using System.Text.RegularExpressions;

namespace SupplyStacks;

public record CraneInstruction(int Take, int From, int To)
{
    public static CraneInstruction ParseFromString(string instruction)
    {
        var digits = Regex.Matches(instruction, @"\d");
        return digits.Select(d => int.Parse(d.Value)).ToList() switch
        {
            [var number, var from, var to] => new CraneInstruction(number, from, to),
            _ => throw new ArgumentException("Invalid string argument")
        };
    }
}

