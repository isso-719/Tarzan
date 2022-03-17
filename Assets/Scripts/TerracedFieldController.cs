using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerracedFieldController : MonoBehaviour
{
    public GameObject ceilingBlock;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = -50; x < 50; x++)
        {
            Instantiate(ceilingBlock, new Vector3(x, -3, 0), Quaternion.identity);
            Instantiate(ceilingBlock, new Vector3(x, -4, 0), Quaternion.identity);
        }

        for (int x = 50; x < 100; x++)
        {
            Instantiate(ceilingBlock, new Vector3(x, -1, 0), Quaternion.identity);
            Instantiate(ceilingBlock, new Vector3(x, -2, 0), Quaternion.identity);
            Instantiate(ceilingBlock, new Vector3(x, -3, 0), Quaternion.identity);
            Instantiate(ceilingBlock, new Vector3(x, -4, 0), Quaternion.identity);
        }

        for (int x = 100; x < 175; x++)
        {
            Instantiate(ceilingBlock, new Vector3(x, 1, 0), Quaternion.identity);
            Instantiate(ceilingBlock, new Vector3(x, 0, 0), Quaternion.identity);
            Instantiate(ceilingBlock, new Vector3(x, -1, 0), Quaternion.identity);
            Instantiate(ceilingBlock, new Vector3(x, -2, 0), Quaternion.identity);
            Instantiate(ceilingBlock, new Vector3(x, -3, 0), Quaternion.identity);
            Instantiate(ceilingBlock, new Vector3(x, -4, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
