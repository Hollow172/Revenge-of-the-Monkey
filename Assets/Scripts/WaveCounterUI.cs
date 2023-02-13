using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounterUI : MonoBehaviour
{
    public ScriptableLevel LevelObject;
    [SerializeField] private Text textWave;
    [SerializeField] private EnemySpawn1 enemyspawn;
    private int maxAmountofWaves;

    private void Start()
    {
        maxAmountofWaves = LevelObject.MaxAmountOfWaves;
    }
    void Update()
    {
        textWave.text = "WAVE: "+ (enemyspawn.WaveToShow + 1) + "/" + maxAmountofWaves;
    }
}
