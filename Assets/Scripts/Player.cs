using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController gameController;
    Rigidbody playerRigidbody;

    public GameObject playerRig;
    Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();

        playerAnimator = playerRig.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.inGame)
        {
            playerRigidbody.useGravity = true;
            playerAnimator.SetBool("inGame", true);
        }

        if (transform.position.y < -10f) GameOver();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") GameOver();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal") GameClear();
    }

    void GameOver()
    {
        gameController.inGame = false;
        gameController.isGameOver = true;
        playerAnimator.SetBool("inGame", false);
        playerAnimator.SetInteger("gameState", 1);
        Debug.Log("Game Over");
    }

    void GameClear()
    {
        gameController.inGame = false;
        gameController.isGameClear = true;
        playerAnimator.SetBool("inGame", false);
        playerAnimator.SetInteger("gameState", 2);
        Debug.Log("Goal!");
    }
}
