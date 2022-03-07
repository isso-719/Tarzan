using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    Text timerText;
    float time;

    public bool isCountTimer;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        timerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountTimer)
        {
            time += Time.deltaTime;
            int min = (int)time / 60;
            int sec = (int)time % 60;
            int msec = (int)(time * 1000 % 1000);


            timerText.text = min.ToString("d2") + ":" + sec.ToString("d2") + ":" + msec.ToString("d3");
        }
	}
}
