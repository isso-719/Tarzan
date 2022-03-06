using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class RopeController : MonoBehaviour
{
    public GameObject player;
    public GameObject pointer;
    ObiRope rope;
    ObiRopeBlueprint blueprint;

    bool isGrapped = false;

    void Start()
    {
        rope = GetComponent<ObiRope>();
        blueprint = ScriptableObject.CreateInstance<ObiRopeBlueprint>();
        blueprint.resolution = 0.5f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isGrapped)
            {
                rope.enabled = false;
                isGrapped = false;
            }
            else
            {
                blueprint.path.Clear();
                // blueprint の path には player の位置を追加する

                rope.enabled = true;
                isGrapped = true;
            }
        }
    }
}
