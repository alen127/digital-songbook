namespace Web.Models;

public class ChordCreateEditModel
{
    public string Name { get; set; }
    public int E2Fret { get; set; }
    public int AFret { get; set; }
    public int DFret { get; set; }
    public int GFret { get; set; }
    public int BFret { get; set; }
    public int E4Fret { get; set; }

    public int E2Finger { get; set; }
    public int AFinger { get; set; }
    public int DFinger { get; set; }
    public int GFinger { get; set; }
    public int BFinger { get; set; }
    public int E4Finger { get; set; }

    public int[] Frets => [E2Fret, AFret, DFret, GFret, BFret, E4Fret];
    public int[] Fingers => [E2Finger, AFinger, DFinger, GFinger, BFinger, E4Finger];

    public string UserId { get; set; }
}