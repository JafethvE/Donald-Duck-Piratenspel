using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBoard : MonoBehaviour {

    private bool rolled;

    public bool Rolled
    {
        get { return rolled; }
    }

    private bool moved;

    public bool Moved
    {
        get { return moved; }
    }

	//Specifies the maximum amount of ships that can be on a tile.
	[SerializeField]
	private int maxAmountOfShipsOnTile;

	public int MaxAmountOfShipsOnTile
	{
		get{ return maxAmountOfShipsOnTile; }
	}

	//Specifies the max number of the dice that is used.
	[SerializeField]
	private int dice;

    public int Dice
    {
        get { return dice; }
    }

	//The price of repairing a ship in the harbour.
	[SerializeField]
	private int basePriceOfRepair;

    public int BasePriceOfRepair
    {
        get { return basePriceOfRepair; }
    }

	//The price of repairing a ship out at sea.
	[SerializeField]
	private int seaHarbourPriceOfRepair;

    public int SeaHarbourPriceOfRepair
    {
        get { return seaHarbourPriceOfRepair; }
    }

	//The price of a treasure map at the main harbour.
	[SerializeField]
	private int priceOfTreasureMap;

    public int PriceOfTreasureMap
    {
        get { return priceOfTreasureMap; }
    }

    [SerializeField]
    private Text currentPlayerText;

    [SerializeField]
    private Text duckatenText;

    [SerializeField]
    private Image treasureMapImage;

    [SerializeField]
	private List<Player> allPlayers;

    private List<Player> playingPlayers;

    [SerializeField]
    private int startingMoney;

    private Player currentPlayer;

    [SerializeField]
    private GameObject shipPrefab;

    [SerializeField]
    private CameraMover camera;

    [SerializeField]
    private UIHoverListener uIHoverListener;

    [SerializeField]
    private List<TreasureTile> treasureTiles;

    [SerializeField]
    private List<int> possibleTreasureValues;

    [SerializeField]
    private GameObject treasurePrefab;

    //Use this for initialization
    private void Start () {
        playingPlayers = new List<Player>();
		//DontDestroyOnLoad (gameObject);
        InitialiseGame(2, 0);
        rolled = false;
        PlaceTreasures();
	}

    public void Roll()
    {
        if(!rolled)
        { 
            int roll = Random.Range(1, dice);
            currentPlayer.Ship.FindRoutes(roll);
            rolled = true;
        }
    }
	
    //Initialises custom house rules from the main menu and initialises the game.
    public void InitialiseGame(int maxAmountOfShipsOnTile, int dice, int basePriceOfRepair, int seaHarbourPriceOfRepair, int amountOfHumanPlayers, int amountOfComputerPlayers)
    {
        this.maxAmountOfShipsOnTile = maxAmountOfShipsOnTile;
        this.dice = dice;
        this.basePriceOfRepair = basePriceOfRepair;
        this.seaHarbourPriceOfRepair = seaHarbourPriceOfRepair;
        InitialiseGame(amountOfHumanPlayers, amountOfComputerPlayers);
    }

    //Initialises the game proper.
    public void InitialiseGame(int amountOfHumanPlayers, int amountOfComputerPlayers)
    {
        for(int i = 0;i < amountOfHumanPlayers + amountOfComputerPlayers;i++)
        {
            playingPlayers.Add(allPlayers[i]);
            playingPlayers[i].Initialise(startingMoney);
            Ship ship = Instantiate(shipPrefab).GetComponent<Ship>();
            ship.Initialise(playingPlayers[i]);
        }

        currentPlayer = playingPlayers[0];
        currentPlayerText.text = currentPlayer.PlayerName;
        duckatenText.text = currentPlayer.Duckaten.ToString();

    }

    public void NextTurn()
    {
        if(rolled && moved)
        { 
            if(playingPlayers.IndexOf(currentPlayer) == playingPlayers.Count -1)
            {
                currentPlayer = playingPlayers[0];
            }
            else
            {
                currentPlayer = playingPlayers[playingPlayers.IndexOf(currentPlayer) + 1];
            }

            currentPlayerText.text = currentPlayer.PlayerName;
            duckatenText.text = currentPlayer.Duckaten.ToString();
            rolled = false;
            moved = false;
        }
    }

    public void ChooseTravelGoal(Tile tile)
    {
        Debug.Log(tile);
        currentPlayer.Ship.MoveToTile(tile);
        moved = true;
    }

    void OnMouseDown()
    {
        if(!uIHoverListener.IsUIOverride)
        { 
            camera.CameraMoveMode = true;
        }
    }

    void OnMouseUp()
    {
        camera.CameraMoveMode = false;
    }

    void PlaceTreasures()
    {
        foreach(TreasureTile treasureTile in treasureTiles)
        {
            GameObject treasureObject = Instantiate(treasurePrefab);
            treasureObject.GetComponent<Treasure>().Worth = possibleTreasureValues[Random.Range(0, possibleTreasureValues.Count)];
            treasureObject.transform.SetParent(treasureTile.transform);
        }
    }
}