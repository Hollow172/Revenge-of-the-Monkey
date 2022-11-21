using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    public static bool game_end = false;

    [SerializeField]
    private GameObject Button;

    private GameObject Base;

    public static Action OnGameStarted = delegate { };

    private void Start()
    {
        PauseGame();
    }

    private void Update()
    {
        if (Base == null)
        {
            EndGame();
        }

    }

    public void EndGame()
    {
        StopAllCoroutines();
        Time.timeScale = 0;
        //enemySpawn.isSpawning = false;
        Debug.Log("Game Over");
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Game Reset");
    }

    public void PauseGame()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        } else
        {
            Time.timeScale = 0;
        }

    }

    public void StartGame()
    {
        Destroy(Button);
        Base = GameObject.FindGameObjectWithTag("Player");
        OnGameStarted.Invoke();
        PauseGame();
    }
}