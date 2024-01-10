using System;
using System.Numerics;

[Serializable]
public class Location
{
    public string name;
    public Vector2[] boundingBox;
    public string clue;
    public string information;

    public Location(String name, Vector2[] boundingBox, string clue, string information)
    {
        this.name = name;
        this.boundingBox = boundingBox; 
        this.clue = clue;
        this.information = information;
    }
}
