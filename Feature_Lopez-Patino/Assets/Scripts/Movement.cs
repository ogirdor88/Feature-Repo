using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements.Experimental;

//Rodrigo, Lopez-Patino
//11/21/23
//set up Click to move


public class Movement : MonoBehaviour
{
    public GameObject Indicator;
    public GameObject indicatorPrefab;
    public GameObject player;
    private Camera mainCamera;
    public bool hasDest;

    private void Awake()
    {
        mainCamera = Camera.main;
        hasDest = false;
    }

    //get the location where the user clicked and store it
    private void OnMouseDown()
    {
        //use ray to get the mouse position based on the camera 
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit) && hit.collider)
        {
            //if indicator is null place an indicator where the user clicked the mouse 
            if (Indicator == null)
            {
                Indicator = Instantiate(indicatorPrefab);
                Indicator.transform.position = hit.point;
                hasDest = true;
            }
            //if there is already an indicator and the user clicks again
            //delete the previous indicatior and spawn a new one in the new location
            if (Indicator != null)
            {
                Destroy(Indicator.gameObject);
                hasDest = false;
                Indicator = Instantiate(indicatorPrefab);
                Indicator.transform.position = hit.point;
                hasDest = true;
            }
        }
    }
}
