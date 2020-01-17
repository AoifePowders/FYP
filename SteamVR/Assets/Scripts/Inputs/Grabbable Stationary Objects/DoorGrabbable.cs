using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGrabbable : MonoBehaviour
{
    public Transform handle;

    GameObject right;
    GameObject left;

    GrabbingandReleasingObjects garoRight;
    GrabbingandReleasingObjects garoLeft;

    Vector3 startPosition;
    GameObject drawer;

    private void Start()
    {
        right = FindObjectOfType<GameManager>().rightHand;
        left = FindObjectOfType<GameManager>().leftHand;

        garoRight = right.GetComponent<GrabbingandReleasingObjects>();
        garoLeft = left.GetComponent<GrabbingandReleasingObjects>();

        drawer = GameObject.FindGameObjectWithTag("Drawer");
        startPosition = drawer.transform.position;
    }

    void Update()
    {
        if (garoRight.objectReleased || garoLeft.objectReleased)
        {
            transform.position = handle.transform.position;
            transform.rotation = handle.transform.rotation;
            drawer.transform.position = startPosition;     
        }

        this.GetComponent<Rigidbody>().useGravity = false;
    }

}
