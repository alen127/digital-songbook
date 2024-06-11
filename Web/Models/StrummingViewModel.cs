namespace Web.Models;

public class StrummingViewModel
{
    public bool[] StrummingPattern { get; set; }

    public bool Exists()
    {
        return StrummingPattern.Contains(true);
    }

    private static bool Is16Strumming(bool[] strummingPattern)
    {
        for (var i = 1; i < 16; i += 2)
            if (strummingPattern[i])
                return true;

        return false;
    }

    // returns strumming pattern with up and down arrows like so: ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↓ ↑
    //  1 e + a 2 e + a 3 e  +  a  4  e  +  a 
    //  0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15
    public string GetStrummingPatternArrows()
    {
        const string downStrum = "\u2193";
        const string upStrum = "\u2191";
        const string padding = " ";
        var strummingPatternSymbols = "";
        for (var i = 0; i < 16; i++)
            if (Is16Strumming(StrummingPattern))
            {
                if (!StrummingPattern[i]) strummingPatternSymbols += padding;
                else if (i % 2 == 0 && StrummingPattern[i]) strummingPatternSymbols += downStrum;
                else if (i % 2 != 0 && StrummingPattern[i]) strummingPatternSymbols += upStrum;
            }
            else
            {
                if (i % 2 == 0 && !StrummingPattern[i]) strummingPatternSymbols += padding;
                else if (i % 4 == 0 && StrummingPattern[i]) strummingPatternSymbols += downStrum;
                else if (i % 4 != 0 && StrummingPattern[i]) strummingPatternSymbols += upStrum;
            }

        return strummingPatternSymbols;
    }

    // returns strumming like so: 1 + 2 + 3 + 4 + a
    public string GetStrummingPatternLetters()
    {
        const string padding = " ";
        const string strummingLetters = "1e+a2e+a3e+a4e+a";
        var result = "";
        for (var i = 0; i < 16; i++)
        {
            if (!StrummingPattern[i]) continue;
            var c = strummingLetters[i] + padding;
            result += c;
        }

        return result;
    }

    public string GetAllStrummingLetters()
    {
        const string strumming16 = "1e+a2e+a3e+a4e+a";
        const string strumming8 = "1+2+3+4+";
        return Is16Strumming(StrummingPattern) ? strumming16 : strumming8;
    }
}