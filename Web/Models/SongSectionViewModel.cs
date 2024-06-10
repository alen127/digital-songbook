using Model;

namespace Web.Models;

public class SongSectionViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Lyrics { get; set; }

    public StrummingViewModel StrummingPattern { get; set; }
    public List<ChordViewModel> Chords { get; set; }
    public List<ChordSongSection> ChordSongSections { get; set; }

    public int Position { get; set; }
}