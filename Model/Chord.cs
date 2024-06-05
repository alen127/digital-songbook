using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Chord
{
    [Required] [Key] public int Id { get; set; }

    [Required] [MaxLength(20)] public string Name { get; set; }

    // Indexes 0 - 5 represent strings E, A, D, G, B, E
    // 0 - open string, -1 - muted string, [N] - fret number
    [Required] public int[] Strings { get; set; }

    // Indexes 0 - 5 represent strings E, A, D, G, B, E
    // 0 - thumb, 1 - index, 2 - middle, 3 - ring, 4 - pinky, -1 - no finger
    public int[] Fingering { get; set; }

    public virtual List<ChordSongSection> ChordSongSections { get; set; }

    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    // [-1, -1, 0, 2, 3, 2] = xx0232 or if above 10th fret seperated by dashes 10-10-11-12-13
    public string GetChordString()
    {
        var result = "";
        var isAboveOrEqualTenthFret = false;
        foreach (var i in Strings)
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

    public string GetFingeringString()
    {
        var result = "";
        foreach (var i in Fingering)
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