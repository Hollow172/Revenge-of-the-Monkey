using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WaveManager
{
    public GameObject Enemy;
    public int[] Waves;
}

public class EnemySpawn1 : MonoBehaviour
{
    public List<WaveManager> nodeData = new List<WaveManager>();
    public bool gameInactive = true;
    public int WaveToShow = 0;

    [SerializeField] ScriptableLevel level;
    [SerializeField] Transform spawnPosition;
    [SerializeField] Text nextWave;

    //settings for spawning
    float spawnRate;
    float cooldownBetweenWaves;
    float timeBeforeFirstWave;
    int maxWave;
    int wave = 0;
    float timeRemaining = 0;

    //flags for setting spawns:
    bool isWaveActive = true;
    bool stopSpawning = false;
    bool flag = false;
    bool initializingFlag = false;


    private void Awake()
    {
        Game.OnGameStarted += GameStart;
        maxWave = level.MaxAmountOfWaves;
        cooldownBetweenWaves = level.CooldownBetweenWaves;
        spawnRate = level.SpawnRate;
        timeBeforeFirstWave = level.SecondsBeforeWaves;
        timeRemaining = cooldownBetweenWaves;
    }

    private void GameStart()
    {
        gameInactive = false;
    }

    void Update()
    {
        if (!initializingFlag)
        {
            nextWave.gameObject.SetActive(true);
            timeBeforeFirstWave -= Time.deltaTime;
            nextWave.text = "NEXT WAVE: " + timeBeforeFirstWave.ToString("f0");
            StartCoroutine(ActivateWave());
        }
        if (!gameInactive && maxWave > wave && initializingFlag)
        {
            nextWave.gameObject.SetActive(false);
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        int whichEnemy = 0;

        if (!isWaveActive && stopSpawning)
        {
            nextWave.gameObject.SetActive(true);
            timeRemaining -= Time.deltaTime;
            nextWave.text = "NEXT WAVE: " + timeRemaining.ToString("f0");
            yield return new WaitForSeconds(cooldownBetweenWaves);
            stopSpawning = false;
        }

        if (flag)
        {
            flag = false;
            isWaveActive = true;
            WaveToShow++;
            nextWave.gameObject.SetActive(false);
            timeRemaining = cooldownBetweenWaves;
        }

        while (isWaveActive && !stopSpawning)
        {
            
            isWaveActive = false;
            for (int i = 0; i < nodeData[whichEnemy].Waves[wave]; i++)
            {
                Instantiate(nodeData[whichEnemy].Enemy, spawnPosition.position, Quaternion.identity);
                yield return new WaitForSecondsRealtime(spawnRate);
            }
            if (whichEnemy == nodeData.Count - 1)
            {
                stopSpawning = true;
                wave++;
                flag = true;
            }
            if (whichEnemy < nodeData.Count-1)
            {
                whichEnemy++;
                isWaveActive = true;
            }

        }
        
    }

    IEnumerator ActivateWave()
    {
        yield return new WaitForSeconds(timeBeforeFirstWave);
        initializingFlag = true;
    }

}

