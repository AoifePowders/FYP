using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    public Transform target;

    Rigidbody rb;

    GameObject right;
    GameObject left;

    GrabbingandReleasingObjects garoRight;
    GrabbingandReleasingObjects garoLeft;

    Vector3 ogPos;
    Vector3 ogRot;

    public string hand;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        right = FindObjectOfType<GameManager>().rightHand;
        left = FindObjectOfType<GameManager>().leftHand;

        garoRight = right.GetComponent<GrabbingandReleasingObjects>();
        garoLeft = left.GetComponent<GrabbingandReleasingObjects>();

        ogPos = transform.position;
        ogRot = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (hand)
        {
            case "Right":
                if (garoRight.objectGrabbed)
                {
                    if (garoRight.objectInHand.name == "Grabbable Knob Right")
                    {
                        rb.MovePosition(target.transform.position);
                    }
                }
                else
                {
                    transform.position = ogPos;
                    transform.rotation = Quaternion.Euler(ogRot);
                }
                break;
            case "Left":
                if (garoLeft.objectGrabbed)
                {

                    if (garoLeft.objectInHand.name == "Grabbable Knob Left")
                    {
                        rb.MovePosition(target.transform.position);
                    }
                }
                else
                {
                    transform.position = ogPos;
                    transform.rotation = Quaternion.Euler(ogRot);
                }
                break;
        }
    }

}
