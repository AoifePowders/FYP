using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGameParticles : MonoBehaviour
{

    public ParticleSystem part;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Car")
        {
            part.Play();
        }
    }
}
