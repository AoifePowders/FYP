using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPush : MonoBehaviour
{
    public Transform boxPrefab;
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Button")
        {
            Debug.Log("hi");
            Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
