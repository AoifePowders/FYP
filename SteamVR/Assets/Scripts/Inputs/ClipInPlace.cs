using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipInPlace : MonoBehaviour
{
    GameObject right;
    GameObject left;

    GrabbingandReleasingObjects garoRight;
    GrabbingandReleasingObjects garoLeft;

    bool released = false;

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
            released = true;
        }
        else
        {
            released = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "grabbable")
        {
            Destroy(other.gameObject.GetComponent<Rigidbody>());
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "grabbable")
        {
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
