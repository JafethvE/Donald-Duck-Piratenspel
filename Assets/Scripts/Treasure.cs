﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour {

    //The amount of money a player gets when returning the treasure.
    [SerializeField]
    private int worth;

    public int Worth
    {
        get { return worth; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
