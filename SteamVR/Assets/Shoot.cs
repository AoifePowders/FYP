using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public GameObject projectile;
    GameObject instantiatedProjectile;
    public int ammo = 15;

    GameObject right;
    GameObject left;

    GrabbingandReleasingObjects garoRight;
    GrabbingandReleasingObjects garoLeft;

    void Start()
    {
        right = FindObjectOfType<GameManager>().rightHand;
        garoRight = right.GetComponent<GrabbingandReleasingObjects>();
    }


    public void shoot()
    {
        if (garoRight.objectInHand != null)
        {
            if (garoRight.objectInHand.name == "Gun")
            {
                if (ammo <= 15 && ammo >= 0)
                {
                    instantiatedProjectile = Instantiate(projectile);
                    instantiatedProjectile.transform.position = transform.position;
                    instantiatedProjectile.transform.rotation = transform.rotation;
                    ammo--;
                }
            }
        }
    }
}
