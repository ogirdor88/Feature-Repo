using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public FollowCam instance;

    public GameObject poi;
    public float camZ;
    public float easing = 0.05f;

    private void Awake()
    {
        instance = this;
        camZ = this.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        poi = GameObject.FindWithTag("Player");
        Vector3 destination  = poi.transform.position;

        //interpolate beteween the cameras curent pos and the POI pos
        destination = Vector3.Lerp(transform.position, destination, easing);

        //move the camera
        transform.position = destination;
    }
}
