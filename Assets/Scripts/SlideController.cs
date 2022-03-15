using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideController : MonoBehaviour
{
    public GameObject[] slides;
    int slideNum = 0;

    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (slideNum < 7)
        {
            slides[slideNum].SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                slideNum++;
                slides[slideNum - 1].SetActive(false);
            }
        }
        else
            panel.SetActive(false);
    }
}
