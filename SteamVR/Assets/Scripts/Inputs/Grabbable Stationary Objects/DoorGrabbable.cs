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

    private void Start()
    {
        right = FindObjectOfType<GameManager>().rightHand;
        left = FindObjectOfType<GameManager>().leftHand;

        garoRight = right.GetComponent<GrabbingandReleasingObjects>();
        garoLeft = left.GetComponent<GrabbingandReleasingObjects>();

    }

    void Update()
    {
        if (garoRight.objectReleased || garoLeft.objectReleased)
        {
            transform.position = handle.transform.position;
            transform.rotation = handle.transform.rotation;
        }

        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().isKinematic = true;
    }
}
