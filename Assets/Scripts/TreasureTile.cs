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

    private bool TreasureCanBeTaken()
    {
        return Treasure != null;
    }

    public Treasure TakeTreasure()
    {
        Treasure returnTreasure = treasure;
        treasure = null;
        return returnTreasure;
    }
}
