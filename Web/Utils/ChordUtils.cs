namespace Web.Utils;

public class ChordUtils
{
    public static string getChordImageUrl(string name, string chordString, string FingeringString)
    {
        const string URI = "https://chordgenerator.net/";
        const int IMAGE_SIZE = 15;
        var imageUrl = $"{URI}{name}.png?p={chordString}&f={FingeringString}&s={IMAGE_SIZE}";
        return imageUrl;
    }
    
    public static string getChordString(int[] frets)
    {
        var result = "";
        var isAboveOrEqualTenthFret = false;
        foreach (var i in frets)
        {
            if (i >= 10)
            {
                isAboveOrEqualTenthFret = true;
            }

            var s = i + "-";
            if (i == -1)
            {
                s = "x-";
            }

            result += s;
        }

        result = !isAboveOrEqualTenthFret ? result.Replace("-", "") : result[..^1];

        return result;
    }
    
    public static string getFingeringString(int[] fingers)
    {
        var result = "";
        foreach (var i in fingers)
        {
            var s = i.ToString();
            if (i == 0)
            {
                s = "T";
            }
            else if (i == -1)
            {
                s = "-";
            }

            result += s;
        }


        return result;
    }
}