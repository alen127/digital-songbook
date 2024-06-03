using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Song
{
    [Key] [Required] public int Id { get; set; }

    [Required] [MaxLength(150)] public string Name { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Bpm cannot be negative.")]
    public int? Bpm { get; set; }

    [MaxLength(64)] public string? StrummingPattern { get; set; }

    [ForeignKey("Artist")] public int ArtistId { get; set; }

    public virtual Artist Artist { get; set; }

    public virtual List<SongSection> Sections { get; set; }
    
    public string UserId { get; set; }
    public virtual ApplicationUser User
    {
        get;
        set;
    }
}