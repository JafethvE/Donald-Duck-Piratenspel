using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverListener : MonoBehaviour
{
    private bool isUIOverride;
    public bool IsUIOverride { get { return isUIOverride; } }

    // Update is called once per frame
    void Update()
    {
        isUIOverride = EventSystem.current.IsPointerOverGameObject();
    }
}
