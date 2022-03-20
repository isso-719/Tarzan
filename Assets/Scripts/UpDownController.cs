using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownController : MonoBehaviour
{
    float time = 0;
    // up = 1, down = -1
    int mode = 1;

    public float delay;
    float globalTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (globalTime > delay)
        {
            if (time < 2)
            {
                if (mode == 1)
                {
                    transform.position += new Vector3(0, 0.05f, 0);
                    time += Time.deltaTime;
                }
                else
                {
                    transform.position -= new Vector3(0, 0.05f, 0);
                    time += Time.deltaTime;
                }
            }
            else
            {
                time = 0;
                mode *= -1;
            }
        } else
        {
            globalTime += Time.deltaTime;
        }
    }
}
