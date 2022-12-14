namespace TuningTrouble.Tests;

public class DataStreamReaderTests
{
    [Fact]
    public void Can_ReadDataStreamBuffer()
    {
        var result = DataStreamReader.Read("mjqjpqmgbljsphdztnvjfqwrcgsmlb");
        Assert.Equal(7, result);
    }
}