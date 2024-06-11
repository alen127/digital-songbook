namespace Model;

public class ChordSongSection
{
    public int Id { get; set; }
    public int ChordId { get; set; }
    public int SongSectionId { get; set; }

    public virtual Chord Chord { get; set; }
}