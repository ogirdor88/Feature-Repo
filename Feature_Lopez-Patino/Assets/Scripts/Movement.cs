using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Rodrigo, Lopez-Patino
//11/21/23
//set up Click to move


public class Movement : MonoBehaviour
{
    //Variabels 
    private bool isMoving = false;
    private bool followCam = true;
    public GameObject spawnIndicator;
    private Vector3 currPos;
    private Vector3 clickPos;


    private void FixedUpdate()
    {
        
    }

    //get the location where the user clicked and store it
    private void OnMouseDown()
    {
        clickPos = Input.mousePosition;
        float x = clickPos.x;
        float y = clickPos.y;

        Debug.Log(x + " " + y);
    }
}
