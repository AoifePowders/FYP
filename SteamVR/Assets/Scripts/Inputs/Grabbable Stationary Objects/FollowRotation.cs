using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    public Transform target;
    Rigidbody rb;

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

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (garoRight.objectGrabbed || garoLeft.objectGrabbed)
        {
            float rotSpeed = 360f;
            Vector3 D = target.position - transform.position;
            Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(D), rotSpeed * Time.deltaTime);
            transform.rotation = rot;
            // put 0 on the axis you do not want the rotation object to rotate
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, 0);
        }
    }
}
