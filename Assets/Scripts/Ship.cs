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

	// Use this for initialization
	void Start () {
		
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
