using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawn : MonoBehaviour
{
    public ScriptableLevel LevelObject;
    public List<ScriptableAmountEnemy> EnemyList;
    public int NumberOfEnemiesAlive = 0;
    public int WaveToShow = 1;

    private List<float> cooldownBetweenSpawns;
    private List<GameObject> enemies;
    private int maxAmountOfWaves;
    //private float cooldownBetweenWaves;
    private float waitBeforeFirstWave;
    
    private bool finishedSpawning = false;
    private bool isSpawning = true;
    private int wave = 1;
    public bool gameInactive = true;
    private bool delayWave = true;
    private float timeRemaining;

    [SerializeField]
    private Transform StartPoint;
    [SerializeField]
    private Text nextWave;


    private void Awake()
    {
        Game.OnGameStarted += GameStart;
    }

    private void GameStart()
    {
        gameInactive = false;
    }

    private void Start()
    {
        //cooldownBetweenWaves = LevelObject.CooldownBetweenWaves;
        maxAmountOfWaves = LevelObject.MaxAmountOfWaves;
        cooldownBetweenSpawns = LevelObject.CooldownBetweenSpawn;
        enemies = LevelObject.EnemiesToSpawn;
        waitBeforeFirstWave = LevelObject.SecondsBeforeWaves;
        timeRemaining = waitBeforeFirstWave;
    }

    private void Update()
    {
        if (gameInactive)
        {
            return;
        }

        if (wave <= maxAmountOfWaves && delayWave)
        {
            nextWave.gameObject.SetActive(true);
            timeRemaining -= Time.deltaTime;
            nextWave.text = "NEXT WAVE: "+timeRemaining.ToString("f0");
            StartCoroutine(DelayWaveTest());
        }

        if (wave <= maxAmountOfWaves && !delayWave)
        {
            if (isSpawning)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    StartCoroutine(SpawnEnemy(enemies[i], cooldownBetweenSpawns[i], i));
                }
                isSpawning = false;
            }
            if (finishedSpawning == true && NumberOfEnemiesAlive <= 0)
            {
                if(wave < maxAmountOfWaves)
                {
                    WaveToShow++;
                }
                wave++;
                isSpawning = true;
                finishedSpawning = false;
                delayWave = true;
                timeRemaining = waitBeforeFirstWave;   
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator SpawnEnemy(GameObject enemy, float cooldownEnemy, int enemyListPosition)
    {
        Vector3 sourcePostion = StartPoint.position;
        UnityEngine.AI.NavMeshHit closestHit;
        int temporarywave = wave;
        temporarywave--;

        for (int i = 0; i < EnemyList[enemyListPosition].EnemyPerWave[temporarywave]; i++)
        {
            if (
                UnityEngine
                    .AI
                    .NavMesh
                    .SamplePosition(sourcePostion, out closestHit, 500, 1)
            )
            {
                StartPoint.transform.position = closestHit.position;
                Instantiate(enemy, closestHit.position, Quaternion.identity);
                NumberOfEnemiesAlive++;
                yield return new WaitForSeconds(cooldownEnemy);
            }
            else
            {
                Debug.Log("Failed to locate closest hit");
            }
        }

        //yield return new WaitForSeconds(cooldownBetweenWaves);
        finishedSpawning = true;
    }

    IEnumerator DelayWaveTest()
    {
        yield return new WaitForSeconds(waitBeforeFirstWave);
        delayWave = false;
        nextWave.gameObject.SetActive(false);
    }


}
