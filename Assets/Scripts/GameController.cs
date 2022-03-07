using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public bool inGame = false;
    public bool isGameClear = false;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !inGame)
        {
            inGame = true;
        }

        if (isGameClear || isGameOver)
        {
            if (Input.GetMouseButton(0))
            {
                Scene loadScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(loadScene.name);
            }
        }
    }
}
