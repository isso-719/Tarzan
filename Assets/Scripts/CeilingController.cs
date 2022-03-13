using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingController : MonoBehaviour
{
    public GameObject ceilingBlock;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = -50; x < 100; x++)
        {
            Instantiate(ceilingBlock, new Vector3(x, 13.5f, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
