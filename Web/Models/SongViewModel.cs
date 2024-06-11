namespace Web.Models;

public class SongViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ArtistViewModel Artist { get; set; }
    public int? Bpm { get; set; }
    public StrummingViewModel StrummingPattern { get; set; }
    public List<SongSectionViewModel> Sections { get; set; }
}