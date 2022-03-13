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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameController.inGame)
            clickToStartText.enabled = false;

        if (gameController.isGameOver)
            gameOverUI.SetActive(true);

        if (gameController.isGameClear)
            gameClearUI.SetActive(true);
    }
}
