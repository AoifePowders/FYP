using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    GameObject right;
    GrabbingandReleasingObjects garoRight;
    int grabbed = 0;
    // Start is called before the first frame update
    void Start()
    {
        right = FindObjectOfType<GameManager>().rightHand;
        garoRight = right.GetComponent<GrabbingandReleasingObjects>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (grabbed == 1)
        //{
        //    if (garoRight.objectReleased && !garoRight.objectGrabbed)
        //    {
        //        this.GetComponent<Rigidbody>().useGravity = false;
        //        //GetComponent<Rigidbody>().AddForce(transform.forward * 1);
        //        grabbed = 0;
        //    }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Hand"))
        {
            if (garoRight.objectGrabbed && !garoRight.objectReleased)
            {
                if (grabbed == 0)
                {
                    grabbed = 1;
                }
            }
        }
    }
}
