using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMenuFollow : MonoBehaviour
{
    public Transform gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gun.localPosition = transform.position;
        gun.localRotation = transform.rotation;
    }
}
