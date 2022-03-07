using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController gameController;
    Rigidbody playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.inGame)
            playerRigidbody.useGravity = true;

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
        Debug.Log("Game Over");
    }

    void GameClear()
    {
        gameController.inGame = false;
        gameController.isGameClear = true;
        Debug.Log("Goal!");
    }
}
