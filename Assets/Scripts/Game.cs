using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    public static bool game_end = false;

    [SerializeField]
    public int lives = 1;

    private void Update()
    {
        if (game_end == true)
        {
            return;
        }

        if (lives <= 0)
        {
            EndGame();
        }

    }

    void EndGame()
    {
        game_end = true;
        StopAllCoroutines();
        enemySpawn.isSpawning = false;
        Debug.Log("Game Over");
    }
}