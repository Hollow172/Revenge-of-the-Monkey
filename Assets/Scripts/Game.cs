using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField]
    public static bool game_end = false;

    [SerializeField]
    private GameObject Button;

    [SerializeField]
    private PauseButtonChange pauseButton;

    [SerializeField]
    private Image grayImage;

    private GameObject Base;

    private bool isStarted = false;

    public static Action
        OnGameStarted =
            delegate ()
            {
            };

    private void Start()
    {
        grayImage.enabled = true;
        //pauseButton.changeSpritetoPause();
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
        //Debug.Log("Game Over");
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //Debug.Log("Game Reset");
        isStarted = false;
    }

    public void PauseGame()
    {
        if (isStarted)
        {
            if (Time.timeScale == 0)
            {
                pauseButton.changeSpritetoPause();
                Time.timeScale = 1;
            }
            else
            {
                pauseButton.changeSpritetoPlay();
                Time.timeScale = 0;
            }
        }
    }

    public void StartGame()
    {
        isStarted = true;
        Destroy (Button);
        Base = GameObject.FindGameObjectWithTag("Player");
        OnGameStarted.Invoke();
        PauseGame();
    }

    public bool CheckStart()
    {
        if (isStarted)
        {
            return true;
        }
        return false;
    }
}
