using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounterUI : MonoBehaviour
{
    private Text textWave;
    private enemySpawn enemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        textWave = GetComponent<Text>();
        enemySpawn = FindObjectOfType<enemySpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        textWave.text = "WAVE: " + enemySpawn.wave;
    }
}
