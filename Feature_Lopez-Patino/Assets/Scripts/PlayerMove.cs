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
    private float easing = 0.05f;
    private bool hasDest;

    private void Awake()
    {
        hasDest = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "indicator") 
        {
            hasDest = false;
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if (!hasDest) 
        {
            if(GameObject.FindWithTag("indicator"))
            {
                hasDest = true;
                destination = GameObject.FindWithTag("indicator").transform.position;
            }
        }
        //destination = GameObject.FindWithTag("indicator").transform.position;

        //destination = Vector3.Lerp(transform.position, destination, easing);
        if (hasDest) 
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, easing);
        }
    
        //transform.position = Vector3.MoveTowards(transform.position, destination, easing);

        //move to new location
        //transform.position = destination;
    }
}
