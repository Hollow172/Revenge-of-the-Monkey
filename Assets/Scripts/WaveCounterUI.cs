using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounterUI : MonoBehaviour
{
    public ScriptableLevel LevelObject;
    [SerializeField] private Text textWave;
    [SerializeField] private enemySpawn enemySpawn;
    private int maxAmountofWaves;

    private void Start()
    {
        maxAmountofWaves = LevelObject.MaxAmountOfWaves;
    }
    void Update()
    {
        textWave.text = "WAVE: " + enemySpawn.WaveToShow + "/" + maxAmountofWaves;
    }
}
