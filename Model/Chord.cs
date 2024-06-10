using System.ComponentModel.DataAnnotations;

namespace Model;

public class Chord
{
    [Required] [Key] public int Id { get; set; }

    [Required] [MaxLength(20)] public string Name { get; set; }

    // Indexes 0 - 5 represent strings E, A, D, G, B, E
    // 0 - open string, -1 - muted string, [N] - fret number
    [Required] public int[] Frets { get; set; }


    // Indexes 0 - 5 represent strings E, A, D, G, B, E
    // 0 - thumb, 1 - index, 2 - middle, 3 - ring, 4 - pinky, -1 - no finger
    public int[] Fingers { get; set; }

    public virtual List<SongSection> Sections { get; }


    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
}