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

        builder.Entity("Model.SongSection", b =>
        {
            b.HasOne("Model.ApplicationUser", "User")
                .WithMany("SongSections")
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        });

        builder.Entity("Model.Song", b =>
        {
            b.HasOne("Model.ApplicationUser", "User")
                .WithMany("Songs")
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        });

        builder.Entity("Model.ChordSongSection", b =>
        {
            b.HasOne("Model.ApplicationUser", "User")
                .WithMany("ChordSongSections")
                .HasForeignKey("UserId")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
            b.HasOne("Model.SongSection", "Section")
                .WithMany("ChordSongSections")
                .HasForeignKey("SectionId")
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        });

        var userId = "cfa41478-4272-4ec9-a3bc-664ceb508dd1";
        var artists = new List<Artist>
        {
            new()
            {
                Id = 1, Name = "The Beatles", UserId = userId,
                ImageUrl =
                    "https://upload.wikimedia.org/wikipedia/commons/d/d8/The_Beatles_members_at_New_York_City_in_1964.jpg"
            },
            new()
            {
                Id = 2, Name = "The Animals", UserId = userId,
                ImageUrl =
                    "https://upload.wikimedia.org/wikipedia/commons/0/02/Eric_Burdon_%26_the_Animals.jpg"
            }
        };

        builder.Entity<Artist>()
            .HasData(artists);

        var noFingering = new int[] { -1, -1, -1, -1, -1, -1 };
        var chords = new List<Chord>
        {
            new() { Id = 1, Strings = [0, 2, 2, 1, 0, 0], Fingering = noFingering, Name = "E", UserId = userId },
            new()
            {
                Id = 2, Strings = [-1, -1, 0, 2, 3, 2], Name = "D", Fingering = noFingering, UserId = userId
            },
            new()
            {
                Id = 3, Strings = [-1, 0, 2, 2, 2, 0], Fingering = [-1, -1, 1, 2, 3, -1], Name = "A",
                UserId = userId
            },
            new()
            {
                Id = 4, Strings = [12, 14, 12, 13, 12, 12], Fingering = [1, 3, 1, 2, 1, 1], Name = "E7",
                UserId = userId
            },
        };

        builder.Entity<Chord>()
            .HasData(chords);


        var songs = new List<Song>
        {
            new() { UserId = userId, ArtistId = 1, Name = "Oh Darling!", Id = 1 },
            new() { UserId = userId, ArtistId = 2, Name = "House of the Rising Sun", Id = 2 }
        };

        builder.Entity<Song>().HasData(songs);
    }
}