using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x + 3 < player.transform.position.x)
        {
            transform.position += new Vector3(0.1f, 0, 0);
        }
        else if (transform.position.x - 3 > player.transform.position.x)
        {
            transform.position += new Vector3(-0.1f, 0, 0);
        }
    }
}
