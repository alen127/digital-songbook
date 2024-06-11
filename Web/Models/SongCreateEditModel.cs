namespace Web.Models;

public class SongCreateEditModel
{
    public string Name { get; set; }
    public int? Bpm { get; set; }
    public StrummingPatternCreateEditModel[] StrummingPattern { get; set; } = new StrummingPatternCreateEditModel[16];
    public int ArtistId { get; set; }
    public string UserId { get; set; }

    // Property that converts StrummingPattern to bool array
    public bool[] StrummingPatternArray =>
        StrummingPattern.Select(strummingPattern => strummingPattern.IsChecked).ToArray();

    public static StrummingPatternCreateEditModel[] ConvertBoolArrayToStrummingPattern(bool[] values)
    {
        if (values.Length != 16)
            throw new ArgumentException("Input array length must match StrummingPattern length", nameof(values));

        var strummingPattern = new StrummingPatternCreateEditModel[16];
        for (var i = 0; i < values.Length; i++)
            strummingPattern[i] = new StrummingPatternCreateEditModel { IsChecked = values[i] };

        return strummingPattern;
    }
}