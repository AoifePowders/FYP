using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindVelocity : MonoBehaviour
{
    Vector3 throwVelocity;

    Rigidbody rb;
    int numframes = 0;
    Vector3 previousPos;

    GameObject right;
    GameObject left;

    GrabbingandReleasingObjects garoRight;
    GrabbingandReleasingObjects garoLeft;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        right = FindObjectOfType<GameManager>().rightHand;
        left = FindObjectOfType<GameManager>().leftHand;

        garoRight = right.GetComponent<GrabbingandReleasingObjects>();
        garoLeft = left.GetComponent<GrabbingandReleasingObjects>();
    }

    // Update is called once per frame
    void Update()
    {
        if (garoRight.objectGrabbed || garoLeft.objectGrabbed)
        {
            throwVelocity = transform.position - previousPos;

            if (numframes > 4)
            {
                previousPos.x = transform.position.x;
                previousPos.y = transform.position.y;
                previousPos.z = transform.position.z;
                numframes = 0;
            }
            else
            {
                numframes++;
            }
        }

        if (garoRight.objectReleased || garoLeft.objectReleased)
        {
            rb.AddForce(throwVelocity, ForceMode.VelocityChange);
        }
    }
}
