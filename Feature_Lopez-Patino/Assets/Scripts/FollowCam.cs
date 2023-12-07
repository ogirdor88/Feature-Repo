using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public FollowCam instance;

    public GameObject poi;
    public float camY;
    public float easing = 5f;

    private void Awake()
    {
        instance = this;
        camY = this.transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set the poi to be the player gameobject
        poi = GameObject.FindWithTag("Player");

        //set the destination to be the players position with some offsets to keep the player in the center of the camera
        Vector3 destination = new Vector3(poi.transform.position.x - 4, camY, poi.transform.position.z + 7);

        //use lerp to ease the camera movement to follow the player
        destination = Vector3.Lerp(transform.position, destination, easing);

        //apply the movement to the camera.
        transform.position = destination;

    }
}
