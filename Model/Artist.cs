#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;

public class Artist
{
    [Required] [Key] public int Id { get; set; }

    [Required] [MaxLength(150)] public string Name { get; set; }

    public virtual List<Song> Songs { get; set; }
    
    public string UserId { get; set; }
    public virtual ApplicationUser User
    {
        get;
        set;
    }
}