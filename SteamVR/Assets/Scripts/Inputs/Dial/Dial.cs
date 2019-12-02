using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dial : MonoBehaviour
{
    public Light l;
    // Update is called once per frame
    void Update()
    {
        float r = transform.localRotation.eulerAngles.z;
        float value;

        value = 0 + r;

        value /= 100;

        l.intensity = value;
    }
}
