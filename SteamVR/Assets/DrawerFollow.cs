using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerFollow : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;
    Vector3 endPosition;

    GameObject right;
    GameObject left;

    GrabbingandReleasingObjects garoRight;
    GrabbingandReleasingObjects garoLeft;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        endPosition = transform.position + new Vector3(0, 0, 0.3f);

        right = FindObjectOfType<GameManager>().rightHand;
        left = FindObjectOfType<GameManager>().leftHand;

        garoRight = right.GetComponent<GrabbingandReleasingObjects>();
        garoLeft = left.GetComponent<GrabbingandReleasingObjects>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.z >= endPosition.z)
        {
            transform.position = endPosition;
        }
        else
        {
            if (garoRight.objectInHand != null || garoLeft.objectInHand != null)
            {
                if (garoRight.objectInHand.name == "Handle Grab" || garoLeft.objectInHand.name == "Handle Grab")
                {
                    rb.MovePosition(target.transform.position);
                }
            }
        }
    }
}
