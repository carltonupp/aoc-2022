namespace TuningTrouble;

public static class DataStreamReader
{
    public static int FindPacket(string buffer)
    {
        return FindFirstMarker(buffer, 4);
    }

    public static int FindMessage(string buffer)
    {
        return FindFirstMarker(buffer, 14);
    }

    private static int FindFirstMarker(string buffer, int distinctCharacters)
    {
        var marker = -1;
        
        for (var i = 0; i < buffer.Length; i++)
        {
            var selection = buffer.Substring(i, distinctCharacters);

            if (selection.Distinct().Count() != distinctCharacters) continue;
            marker = i + distinctCharacters;
            break;
        }
        
        return marker;
    }
}