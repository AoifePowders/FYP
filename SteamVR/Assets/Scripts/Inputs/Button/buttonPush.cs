using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPush : MonoBehaviour
{
    public Transform boxPrefab;
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        //unity struggles with string to string comparison
        if(other.CompareTag("Button"))
        {
            Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
