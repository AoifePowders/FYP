using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipInPlace : MonoBehaviour
{

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("grabbable"))
        {
            if (other.name == name)
            {
                other.gameObject.GetComponent<Rigidbody>().useGravity = false;
                other.transform.position = transform.position;
                other.transform.localEulerAngles = transform.localEulerAngles;
            }
        }
    }
}
