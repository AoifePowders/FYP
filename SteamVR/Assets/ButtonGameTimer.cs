using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGameTimer : MonoBehaviour
{
    float time = 0.0f;
    public Text text;
    bool start = false;

    // Start is called before the first frame update
    void Start()
    {
        text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        start = GameObject.Find("ButtonStart").GetComponent<PlayButtonGame>().playGame;
        if (start)
        {
            Debug.Log(start);
            time += Time.deltaTime;
            double displayTime = System.Math.Round(time, 1);
            text.text = "Time : " + displayTime;
        }
    }
}
