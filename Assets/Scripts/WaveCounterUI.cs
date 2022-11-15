using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounterUI : MonoBehaviour
{
    [SerializeField] private Text textWave;
    [SerializeField] private enemySpawn enemySpawn;

    void Update()
    {
        textWave.text = "WAVE: " + enemySpawn.wave;
    }
}
