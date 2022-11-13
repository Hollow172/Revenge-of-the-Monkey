using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounterUI : MonoBehaviour
{
    private Text textWave;
    private EnemySpawn enemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        textWave = GetComponent<Text>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        textWave.text = "WAVE: " + enemySpawn.wave;
    }
}
