using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeaHarbour : Tile {

	//The player this harbour belongs to.
	[SerializeField]
	private Player player;
    
    [SerializeField]
    private bool mainharbour;

    public bool MainHarbour
    {
        get { return mainharbour; }
    }

    new protected void Awake()
    {
        background.color = player.Colour;
        base.Awake();
    }

    new protected void Update()
    {
        base.Update();
    }
}
