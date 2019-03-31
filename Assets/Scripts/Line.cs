using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    private LineRenderer line;

    public void SetTiles(Vector3 tile1Position, Vector3 tile2Position)
    {
        line.SetPosition(0, tile1Position);
        line.SetPosition(1, tile2Position);
    }

    void Awake()
    {
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.material.color = Color.black;
    }
}
