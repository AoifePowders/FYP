using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasButtonGameTimer : MonoBehaviour
{
    float time = 0.0f;
    public Text text;
    public bool start = false;
    bool startTimer = false;

    public GameObject rHand;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        text.GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        start = rHand.GetComponent<UISelect>().playGame;
        startTimer = rHand.GetComponent<UISelect>().startTimer;
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
            rHand.GetComponent<UISelect>().playGame = false;
        }

        double canvasdisplayTime = System.Math.Round(time, 1);
        text.text = "Time : " + canvasdisplayTime;
    }
}