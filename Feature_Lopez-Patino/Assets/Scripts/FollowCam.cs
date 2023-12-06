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
        poi = GameObject.FindWithTag("Player");

        Vector3 destination = new Vector3(poi.transform.position.x - 4, camY, poi.transform.position.z + 7);

        destination = Vector3.Lerp(transform.position, destination, easing);

        transform.position = destination;

    }
}
