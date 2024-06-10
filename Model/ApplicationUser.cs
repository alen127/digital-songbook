using Microsoft.AspNetCore.Identity;

namespace Model;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Artist> Artists { get; set; }
    public virtual ICollection<Song> Songs { get; set; }
    public virtual ICollection<Chord> Chords { get; set; }
}