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

    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        start = GameObject.Find("ButtonStart").GetComponent<PlayButtonGame>().playGame;
        startTimer = GameObject.Find("ButtonStart").GetComponent<PlayButtonGame>().startTimer;
        if(startTimer)
        {
            time = 0;
        }

        if (start)
        {
            if (time <= 10.0f)
            {
                time += Time.deltaTime;
            }
            else if(time >= 10.0f)
            {
                start = false;
            }
        }
        else
        {
            GameObject.Find("ButtonStart").GetComponent<PlayButtonGame>().playGame = false;
            Debug.Log(GameObject.Find("ButtonStart").GetComponent<PlayButtonGame>().playGame);
        }

        double displayTime = System.Math.Round(time, 1);
        text.text = "Time : " + displayTime;
    }
}
