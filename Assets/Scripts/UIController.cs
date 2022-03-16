using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameController gameController;
    public Text clickToStartText;
    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public GameObject panel;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameController.inGame)
        {
            clickToStartText.enabled = false;
            panel.SetActive(false);
        }

        if (gameController.isGameOver)
        {
            panel.SetActive(true);
            gameOverUI.SetActive(true);
        }

        if (gameController.isGameClear)
        {
            panel.SetActive(true);
            gameClearUI.SetActive(true);
        }
    }
}
