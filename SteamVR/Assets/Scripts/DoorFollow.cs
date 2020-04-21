using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFollow : MonoBehaviour
{

    public Transform target;
    Rigidbody rb;
    Vector3 endPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        endPosition = transform.position + new Vector3(0, 0, 0.3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.tag == "Drawer")
        {
            if (transform.position.z >= endPosition.z)
            {
                transform.position = endPosition;
            }
            else
            {
                rb.MovePosition(target.transform.position);
            }
        }
        else
        {
            rb.MovePosition(target.transform.position);
        }

    }
}