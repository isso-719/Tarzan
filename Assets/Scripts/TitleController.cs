using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    public GameObject clickToPlayText;
    public GameObject stageSelectButtons;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && clickToPlayText.activeSelf)
        {
            clickToPlayText.SetActive(false);
            stageSelectButtons.SetActive(true);
        }
    }

    public void SelectStage(int stageNum)
    {
        SceneManager.LoadScene("Stage" + stageNum);
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}