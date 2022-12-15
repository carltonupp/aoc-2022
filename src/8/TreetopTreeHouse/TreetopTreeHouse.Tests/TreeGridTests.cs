namespace TreetopTreeHouse.Tests;

public class TreeGridTests
{
    [Fact]
    public void Part1_SampleInputs()
    {
        int[,] testData =
        {
            {3, 0, 3, 7, 3}, 
            {2, 5, 5, 1, 2}, 
            {6, 5, 3, 3, 2}, 
            {3, 3, 5, 4, 9}, 
            {3, 5, 3, 9, 0}
        };

        var grid = new TreeGrid(testData);
        var result = grid.GetVisibleTrees();
        
        Assert.Equal(21, result);
    }
}