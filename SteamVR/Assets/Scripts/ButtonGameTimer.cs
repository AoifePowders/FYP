using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGameTimer : MonoBehaviour
{
    float time = 0.0f;
    public Text text;
    public bool start = false;
    bool startTimer = false;
    public GameObject buttonStart;

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //Button Timer
        start = buttonStart.GetComponent<PlayButtonGame>().playGame;
        startTimer = buttonStart.GetComponent<PlayButtonGame>().startTimer;
        if (startTimer)
        {
            time = 0;
        }

        if (start)
        {
            if (time <= 10.0f)
            {
                time += Time.deltaTime;
            }

            else if (time >= 10.0f)
            {
                start = false;
            }
        }

        else
        {
            buttonStart.GetComponent<PlayButtonGame>().playGame = false;
        }


        double displayTime = System.Math.Round(time, 1);
        text.text = "Time : " + displayTime;
    }
}
