using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;

public class PlayerMove : MonoBehaviour
{
    private Vector3 destination;
    private float easing = 0.1f;
    private bool hasDest;

    private void Awake()
    {
        hasDest = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        //when the player touches the indicator, set hasDest to false and destroy the indicator
        if (other.gameObject.tag == "indicator") 
        {
            hasDest = false;
            Destroy(other.gameObject);
        }
    }
    private void FixedUpdate()
    {
        //if hasDest is false 
        if (!hasDest) 
        {
            //if there is a game object with the tag "indicator"
            if(GameObject.FindWithTag("indicator"))
            {
                //set hasDest to true and and set the destination to the location of the game object
                hasDest = true;
                destination = GameObject.FindWithTag("indicator").transform.position;
            }
        }
        //destination = GameObject.FindWithTag("indicator").transform.position;

        //destination = Vector3.Lerp(transform.position, destination, easing);

        //if hasDest is true move the player towards the destination
        if (hasDest) 
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, easing);
        }
    
        //transform.position = Vector3.MoveTowards(transform.position, destination, easing);

        //move to new location
        //transform.position = destination;
    }
}
