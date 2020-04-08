using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    private bool gameEnded = false;

    public GameObject gameOverUI;
    public GameObject winnerUI;

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;

        if (Input.GetKeyDown("space"))
        {
            EndGame(gameOverUI);
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame(gameOverUI);
        }

        if(PlayerStats.Lives > 0 && PlayerStats.killEnemy + PlayerStats.destroyEnemy == PlayerStats.Enemy)
        {
            EndGame(winnerUI);
        }
    }

    void EndGame(GameObject obj)
    {
        gameEnded = true;
        obj.SetActive(true);
    }
}

