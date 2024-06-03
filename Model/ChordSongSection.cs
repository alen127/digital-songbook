#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class ChordSongSection
{
    [Key] public int Id { get; set; }

    [ForeignKey("Chord")] public int ChordId { get; set; }
    public virtual Chord Chord { get; set; }

    [ForeignKey("SongSection")] public int SectionId { get; set; }
    public virtual SongSection Section { get; set; }

    // Represents the position of a chord in a progression starting from 0
    // otherwise we wouldn't know the order of the chords
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Position cannot be negative.")]
    public int Position { get; set; } 
    
    public string UserId { get; set; }
    public virtual ApplicationUser User
    {
        get;
        set;
    }
}