using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureTile : Tile
{
    private Treasure treasure;

    public Treasure Treasure
    {
        get { return treasure; }
        set { treasure = value; }
    }

    [SerializeField]
    private string name;

    public string Name
    {
        get { return name; }
    }

    public bool TreasureCanBeTaken()
    {
        return treasure != null;
    }

    public Treasure TakeTreasure()
    {
        Treasure returnTreasure = treasure;
        treasure = null;
        return returnTreasure;
    }
}
