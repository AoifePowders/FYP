using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColorChange : MonoBehaviour
{
    int UIcount = 0;
    Button buttonChild;
    bool startUI = false;
    public GameObject ButtonTimerScript;

    private void Start()
    {
        //startUI = gameObje
    }

    // Update is called once per frame
    void Update()
    {
        //UI Button Game
        startUI = ButtonTimerScript.GetComponent<CanvasButtonGameTimer>().start;
        if (startUI)
        {
            UIcount += 1;
            if (UIcount == 100)
            {
                buttonChild = transform.GetChild(Random.Range(0, this.gameObject.transform.childCount)).GetComponent<Button>();
                randUIColor();
            }
            if (UIcount > 200)
            {
                changeUIBack();
                UIcount = 0;
            }
        }
        else
        {
            changeUIBack();
        }
    }
    
    void randUIColor()
    {
        Color RandomColor = new Color(0, 0, 1);
        buttonChild.image.color = RandomColor;
        buttonChild.name = "Active";
    }

    void changeUIBack()
    {
        Color RandomColor = new Color(1, 0.50f, 0);
        buttonChild.image.color = RandomColor;
        buttonChild.name = "Button";
    }

}
