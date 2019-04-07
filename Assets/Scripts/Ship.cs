using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour {

    private Tile currentTile;

    private Player player;

    [SerializeField]
    private Image image;

    public Player Player
    {
        get { return player;  }
    }

    public Ship(Player player)
    {
    }

    private List<Treasure> treasures;

	// Use this for initialization
	void Awake () {
        treasures = new List<Treasure>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveToTile(Tile tile)
    {
        if(currentTile)
        { 
            currentTile.RemoveShip(this);
        }
        tile.AddShip(this);
        currentTile = tile;

        if(tile is TreasureTile)
        {
            //TODO: Implement:
            //Get player treasure map tile and check if it's the same tile.
            Debug.Log("Take The Treasure!");
            TreasureTile treasureTile = tile.GetComponent<TreasureTile>();
            Debug.Log("TreasureTile: " + treasureTile);
            if (treasureTile.TreasureCanBeTaken())
            {
                Debug.Log("Before: " + treasures.Count);
                Treasure treasure = treasureTile.TakeTreasure();
                treasures.Add(treasure);
                treasure.transform.SetParent(transform);
                Debug.Log("After: " + treasures.Count);
            }
            
        }
    }

    public void Initialise(Player player)
    {
        this.player = player;
        player.Ship = this;
        MoveToTile(player.StartTile);
        image.color = player.Colour;
    }

    public void FindRoutes(int roll)
    {
        currentTile.FindRoutes(roll);
    }
}
