using UnityEngine;

public class LeaderboardElemetData
{
    public int Place;
    public Sprite Lang;
    public string Name;
    public int Result;

    public LeaderboardElemetData(int place, Sprite lang, string name, int result)
    {
        Place = place;
        Lang = lang;
        Name = name;
        Result = result;
    }
}