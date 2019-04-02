using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour {

	//The ships located on this tile. The maximum of ships is decided by the house rules.
	protected Ship[] ships;

    protected Color standardBackgroundColour;

    //The gameboard that contains the house rules.
	[SerializeField]
	protected GameBoard gameBoard;

    public GameBoard Gameboard
    {
        get { return gameBoard; }
    }

    [SerializeField]
    protected Button button;

    //The background of this tile.
    [SerializeField]
    protected Image background;

    //The tiles that can be reached from this tile.
    [SerializeField]
	protected List<Tile> neighbours;

    protected bool travelable;

    [SerializeField]
    protected float flashDelay;

    protected float flash;

    [SerializeField]
    protected GameObject lineRendererPrefab;

    [SerializeField]
    protected UIHoverListener uIHoverListener;

    [SerializeField]
    protected CameraMover camera;

    // Use this for initialization
    protected void Awake () {
		ships = new Ship[gameBoard.MaxAmountOfShipsOnTile];
        travelable = false;
        flash = flashDelay;
        standardBackgroundColour = background.color;
        DrawLines();
    }

    //Draws the lines between neighbours to see routes.
    protected void DrawLines()
    {
        foreach(Tile tile in neighbours)
        {
            GameObject lineObject = Instantiate(lineRendererPrefab);
            lineObject.transform.SetParent(gameObject.transform);
            Line line = lineObject.GetComponent<Line>();
            line.SetTiles(gameObject.transform.position, tile.gameObject.transform.position);
        }
    }
	
	// Update is called once per frame
	protected void Update ()
    {
        if (travelable)
        {
            if(gameBoard.Rolled && !gameBoard.Moved)
            {
                if (flash < 0)
                {
                    if (background.color == Color.white)
                    {
                        background.color = standardBackgroundColour;
                    }
                    else
                    {
                        background.color = Color.white;
                    }
                    flash = flashDelay;
                }
                else
                {
                    flash -= Time.deltaTime;
                }
            }
            else
            {
                flash = flashDelay;
                travelable = false;
                button.interactable = false;
                background.color = standardBackgroundColour;
            }
        }
    }

    public void AddShip(Ship ship)
    {
        for(int i = 0;i<gameBoard.MaxAmountOfShipsOnTile;i++)
        {
            if(ships[i] == null)
            {
                ships[i] = ship;
                ship.transform.SetParent(transform, false);
                ship.transform.SetAsLastSibling();
                break;
            }
        }
    }

    public void FindRoutes(int roll)
    {
        List<Tile> endgoals = new List<Tile>();
        List<Tile> goals = neighbours;
        roll--;
        while(roll>0)
        {
            List<Tile> temp = new List<Tile>();
            foreach(Tile tile in goals)
            {
                foreach(Tile neighbour in tile.neighbours)
                { 
                    temp.Add(neighbour);
                }
            }
            goals = temp;
            roll--;
        }


        endgoals = goals;
        foreach (Tile tile in endgoals)
        {
            tile.SetAsTravelGoal();
        }
    }

    protected void SetAsTravelGoal()
    {
        if(HasRoom())
        { 
            travelable = true;
            button.interactable = true;
        }
    }

    public void RemoveShip(Ship shiptoRemove)
    {
        for(int i = 0;i<ships.Length;i++)
        {
            if(ships[i] == shiptoRemove)
            {
                ships[i] = null;
            }
        }
    }

    protected bool HasRoom()
    {
        bool hasRoom = false;
        for(int i = 0; i< gameBoard.MaxAmountOfShipsOnTile;i++)
        {
            if(ships[i] == null)
            {
                hasRoom = true;
                break;
            }
        }
        return hasRoom;
    }

    void OnMouseDown()
    {
        camera.CameraMoveMode = true;
    }

    void OnMouseUp()
    {
        camera.CameraMoveMode = false;
    }
}
