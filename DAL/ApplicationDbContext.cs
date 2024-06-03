using System.Xml.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Chord> Chords { get; set; }
    public DbSet<SongSection> Sections { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<ChordSongSection> ChordSongSections { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var artists = new List<Artist>
        {
            new() { Id = 1, Name = "The Beatles", UserId = "41e11539-332c-49a3-90f3-b4c0455c9dee" },
            new() { Id = 2, Name = "The Animals", UserId = "41e11539-332c-49a3-90f3-b4c0455c9dee" }
        };
        builder.Entity<Artist>()
            .HasData(artists);
    }
}