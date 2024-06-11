using Web.Utils;

namespace Web.Models;

public class ChordViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int[] Frets { get; set; }
    public int[] Fingers { get; set; }

    public string getImageUrl()
    {
        return ChordUtils.getChordImageUrl(Name, ChordUtils.getChordString(Frets),
            ChordUtils.getFingeringString(Fingers));
    }
    // [-1, -1, 0, 2, 3, 2] = xx0232 or if above 10th fret seperated by dashes 10-10-11-12-13
}