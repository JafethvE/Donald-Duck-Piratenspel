using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private bool cameraMoveMode;

    [SerializeField]
    private float acceleration;

    public bool CameraMoveMode
    {
        get { return cameraMoveMode; }
        set { cameraMoveMode = value; Debug.Log("Changed!"); }
    }

    [SerializeField]
    private float zoomSpeed;

    private float targetOrtho;

    [SerializeField]
    private float smoothSpeed;

    [SerializeField]
    private float minOrtho;

    [SerializeField]
    private float maxOrtho;

    void Awake()
    {
        targetOrtho = Camera.main.orthographicSize;
        cameraMoveMode = false;
    }

    void LateUpdate()
    {
        //Do movement along the X and Y axes
        if(cameraMoveMode)
        {
            Vector3 position = transform.position;
            position.x -= Input.GetAxis("Mouse X") * acceleration;
            position.y -= Input.GetAxis("Mouse Y") * acceleration;
            transform.position = position;
        }

        //Do zooming.
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            targetOrtho -= scroll * zoomSpeed;
            targetOrtho = Mathf.Clamp(targetOrtho, minOrtho, maxOrtho);
        }

        Camera.main.orthographicSize = Mathf.MoveTowards(Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
    }
}
