using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingController : MonoBehaviour
{
    public GameObject ceilingBlock;
    public int backwardMax;
    public int forwardMax;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = backwardMax; x < forwardMax; x++)
        {
            Instantiate(ceilingBlock, new Vector3(x, 13.5f, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
