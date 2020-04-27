using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenuFollow : MonoBehaviour
{
    public Transform gun;

    // Update is called once per frame
    void Update()
    {
        gun.localPosition = transform.position;
        gun.localRotation = transform.rotation;
    }
}
