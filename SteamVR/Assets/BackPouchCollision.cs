using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPouchCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bat")
        {
            other.attachedRigidbody.isKinematic = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Bat")
        {
            other.attachedRigidbody.isKinematic = false;
        }
    }
}
