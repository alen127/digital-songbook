using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class SongSection
{
    [Key] [Required] public int Id { get; set; }

    [Required] [MaxLength(50)] public string Name { get; set; }

    [MaxLength(4096)] public string? Lyrics { get; set; }

    public bool[] StrummingPattern { get; set; } = new bool[16];
    public virtual List<Chord> Chords { get; set; }
    public virtual List<ChordSongSection> ChordSongSections { get; set; }

    // Represents the position of a section in a song starting from 0
    // otherwise we wouldn't know the order of the sections
    [Required]
    [Range(0, int.MaxValue, ErrorMessage = "Position cannot be negative.")]
    public int Position { get; set; }

    [ForeignKey("Song")] public int SongId { get; set; }

    public virtual Song Song { get; set; }
}