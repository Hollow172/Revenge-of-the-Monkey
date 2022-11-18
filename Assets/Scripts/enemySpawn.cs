using System.Collections;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public ScriptableLevel LevelObject;
    public int NumberOfEnemiesAlive = 0;
    public int WaveToShow = 1;

    private bool isSpawning = true;
    private bool finishedSpawning = false;
    private int multiplierOfEnemies; //Multiplier of enemies per wave
    private float cooldownBetweenSpawn;
    private float cooldownBetweenWaves;
    private int maxAmountOfWaves;
    private int wave = 1;

    private bool gameInactive = true;

    [SerializeField]
    private GameObject enemy;

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
        multiplierOfEnemies = LevelObject.MultiplierOfEnemies;
        cooldownBetweenSpawn = LevelObject.CooldownBetweenSpawn;
        cooldownBetweenWaves = LevelObject.CooldownBetweenWaves;
        maxAmountOfWaves = LevelObject.MaxAmountOfWaves;
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
                StartCoroutine(SpawnEnemy());
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

    IEnumerator SpawnEnemy()
    {
        Vector3 sourcePostion = StartPoint.position;
        UnityEngine.AI.NavMeshHit closestHit;

        for (int i = 0; i < multiplierOfEnemies * wave; i++)
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
                yield return new WaitForSeconds(cooldownBetweenSpawn);
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
