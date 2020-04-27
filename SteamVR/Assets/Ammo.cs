using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject gun;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.name == "Gun")
        {
            Debug.Log("here");
            gun.GetComponent<Shoot>().ammo = 15;
            Destroy(gameObject);
        }
    }
}
