using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonGame : MonoBehaviour
{
    public bool playGame = false;
    public bool startTimer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ButtonPressurePoint")
        {
            playGame = true;
            startTimer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ButtonPressurePoint")
        {
            startTimer = false;
        }
    }
}
