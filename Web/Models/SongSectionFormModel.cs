namespace Web.Models;

public class SongSectionFormModel
{
    public string Name { get; set; }
    public string? Lyrics { get; set; }
    public StrummingPatternCreateEditModel[] StrummingPattern { get; set; } = new StrummingPatternCreateEditModel[16];
    public List<int> ChordIds { get; set; }
    public int Position { get; set; }
    public int SongId { get; set; }

    public bool[] StrummingPatternArray => StrummingPattern.Where(strummingPattern => strummingPattern != null)
        .Select(strummingPattern => strummingPattern.IsChecked).ToArray();

    public static StrummingPatternCreateEditModel[] ConvertBoolArrayToStrummingPattern(bool[] values)
    {
        if (values.Length != 16)
        {
            throw new ArgumentException("Input array length must match StrummingPattern length", nameof(values));
        }

        var strummingPattern = new StrummingPatternCreateEditModel[16];
        for (var i = 0; i < values.Length; i++)
        {
            strummingPattern[i] = new StrummingPatternCreateEditModel { IsChecked = values[i] };
        }

        return strummingPattern;
    }
}