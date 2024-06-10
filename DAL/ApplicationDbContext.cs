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

        builder.Entity<Chord>()
            .HasMany(e => e.Sections)
            .WithMany(e => e.Chords)
            .UsingEntity<ChordSongSection>();

        builder.Entity<Song>()
            .HasOne(s => s.User)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        var userId = "39ffa927-8fd6-46a4-88ad-b8347c07adaa";

        SeedArtists(builder, userId);
        SeedChords(builder, userId);
        SeedSongs(builder, userId);
        SeedSections(builder);
        SeedSectionsChords(builder);
    }

    private void SeedSectionsChords(ModelBuilder builder)
    {
        builder.Entity<SongSection>()
            .HasMany(s => s.Chords)
            .WithMany(c => c.Sections)
            .UsingEntity(j => j.ToTable("ChordSongSection").HasData([
                new { Id = 1, SongSectionId = 1, ChordId = 1 },
                new { Id = 2, SongSectionId = 1, ChordId = 3 },
                new { Id = 3, SongSectionId = 1, ChordId = 4 },
                new { Id = 4, SongSectionId = 1, ChordId = 2 },
                new { Id = 5, SongSectionId = 1, ChordId = 1 },
                new { Id = 6, SongSectionId = 1, ChordId = 3 },
                new { Id = 7, SongSectionId = 2, ChordId = 1 },
                new { Id = 8, SongSectionId = 2, ChordId = 3 },
                new { Id = 9, SongSectionId = 2, ChordId = 3 },
                new { Id = 10, SongSectionId = 3, ChordId = 2 },
                new { Id = 11, SongSectionId = 3, ChordId = 1 },
            ]));
    }

    private void SeedSections(ModelBuilder builder)
    {
        var LetItBeSections = new List<SongSection>()
        {
            new()
            {
                Id = 1, Name = "Verse 1", Position = 1,
                Lyrics =
                    "When I find myself in times of trouble, Mother Mary comes to me\nSpeaking words of wisdom, let it be\nAnd in my hour of darkness she is standing right in front of me\nSpeaking words of wisdom, let it be",
                SongId = 1,
                StrummingPattern =
                [
                    true, false, false, false, true, false, true, false, true, false, false, false, true, false, true,
                    false
                ]
            },
            new()
            {
                Id = 2, Name = "Chorus", Position = 2,
                Lyrics =
                    "Let it be, let it be, let it be, let it be\nWhisper words of wisdom, let it be",
                SongId = 1,
                StrummingPattern =
                [
                    true, false, false, false, true, false, true, false, true, true, false, false, true, false, true,
                    false
                ],
            },
            new()
            {
                Id = 3, Name = "Verse 2", Position = 3,
                Lyrics =
                    "And when the broken hearted people living in the world agree\nThere will be an answer, let it be\nFor though they may be parted, there is still a chance that they will see\nThere will be an answer, let it be",
                SongId = 1
            },
        };

        builder.Entity<SongSection>().HasData(LetItBeSections);
    }

    private void SeedSongs(ModelBuilder builder, string userId)
    {
        var songs = new List<Song>
        {
            new()
            {
                UserId = userId, ArtistId = 1, Name = "Let it be", Id = 1,
                StrummingPattern =
                [
                    true, false, false, false, false, false, false, false, true, false, false, false, false, false,
                    false, false
                ],
                Bpm = 72
            },
            new() { UserId = userId, ArtistId = 2, Name = "House of the Rising Sun", Id = 2 }
        };

        builder.Entity<Song>().HasData(songs);
    }

    private void SeedChords(ModelBuilder builder, string userId)
    {
        var noFingering = new int[] { -1, -1, -1, -1, -1, -1 };
        var chords = new List<Chord>
        {
            new() { Id = 1, Frets = [0, 2, 2, 1, 0, 0], Fingers = noFingering, Name = "E", UserId = userId },
            new()
            {
                Id = 2, Frets = [-1, -1, 0, 2, 3, 2], Name = "D", Fingers = noFingering, UserId = userId
            },
            new()
            {
                Id = 3, Frets = [-1, 0, 2, 2, 2, 0], Fingers = [-1, -1, 1, 2, 3, -1], Name = "A",
                UserId = userId
            },
            new()
            {
                Id = 4, Frets = [12, 14, 12, 13, 12, 12], Fingers = [1, 3, 1, 2, 1, 1], Name = "E7",
                UserId = userId
            },
        };

        builder.Entity<Chord>()
            .HasData(chords);
    }

    private void SeedArtists(ModelBuilder builder, string userId)
    {
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
    }
}