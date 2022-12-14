namespace TuningTrouble.Tests;

public class DataStreamReaderTests
{
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void Can_ReadPacketFromBuffer_SampleInput(string buffer, int firstMarker)
    {
        var result = DataStreamReader.FindPacket(buffer);
        Assert.Equal(firstMarker, result);
    }

    [Fact]
    public void Can_ReadPacketFromBuffer_RealInput()
    {
        var input = File.ReadAllText("./inputs.txt");
        var result = DataStreamReader.FindPacket(input);
        Assert.Equal(1140, result);
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void Can_ReadMessageFromBuffer_SampleInputs(string buffer, int firstMarker)
    {
        var result = DataStreamReader.FindMessage(buffer);
        Assert.Equal(firstMarker, result);
    }
    
    [Fact]
    public void Can_ReadMessageFromBuffer_RealInput()
    {
        var input = File.ReadAllText("./inputs.txt");
        var result = DataStreamReader.FindMessage(input);
        Assert.Equal(3495, result);
    }
}