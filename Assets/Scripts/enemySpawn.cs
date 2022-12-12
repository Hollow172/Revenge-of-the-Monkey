using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public ScriptableLevel LevelObject;
    public List<ScriptableAmountEnemy> EnemyList;
    public int NumberOfEnemiesAlive = 0;
    public int WaveToShow = 1;

    private List<float> cooldownBetweenSpawns;
    private List<GameObject> enemies;
    private int maxAmountOfWaves;
    private float cooldownBetweenWaves;
    
    private bool finishedSpawning = false;
    private bool isSpawning = true;
    private int wave = 1;
    private bool gameInactive = true;

    [SerializeField]
    private Transform StartPoint;

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
        cooldownBetweenWaves = LevelObject.CooldownBetweenWaves;
        maxAmountOfWaves = LevelObject.MaxAmountOfWaves;
        cooldownBetweenSpawns = LevelObject.CooldownBetweenSpawn;
        enemies = LevelObject.EnemiesToSpawn;
    }

    private void Update()
    {
        if (gameInactive)
        {
            return;
        }

        if(wave <= maxAmountOfWaves)
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

        yield return new WaitForSeconds(cooldownBetweenWaves);
        finishedSpawning = true;
    }


}
