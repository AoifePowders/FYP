using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonGame : MonoBehaviour
{
    public bool playGame = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ButtonPressurePoint")
        {
            playGame = true;
        }
    }
}
