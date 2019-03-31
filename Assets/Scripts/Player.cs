using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private Color colour;
    
    private Ship ship;

    public Ship Ship
    {
        get { return ship; }
        set { ship = value; }
    }

    public Color Colour
    {
        get { return colour; }
    }

    [SerializeField]
    private string playerName;

    public string PlayerName
    {
        get { return playerName; }
    }

	private int duckaten;

    public int Duckaten
    {
        get { return duckaten; }
    }

    [SerializeField]
    private Tile startTile;
    
    public Tile StartTile
    {
        get { return startTile; }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Initialise(int startingMoney)
    {
        duckaten = startingMoney;
    }
}
