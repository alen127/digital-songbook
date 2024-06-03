using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Chord
{
    [Required] [Key] public int Id { get; set; }

    [Required] [MaxLength(20)] public string Name { get; set; }

    // Indexes 0 - 5 represent strings E, A, D, G, B, E
    // 0 - open string, -1 - muted string, [N] - fret number
    [Required] public int[] Frets { get; set; } = new int[6];

    // Indexes 0 - 5 represent strings E, A, D, G, B, E
    // 0 - thumb, 1 - index, 2 - middle, 3 - ring, 4 - pinky, -1 - no finger
    public int[]? Fingers { get; set; } = new int[6];

    public virtual List<ChordSongSection> ChordSongSections { get; set; }
    
    public string UserId { get; set; }
    public virtual ApplicationUser User
    {
        get;
        set;
    }
}