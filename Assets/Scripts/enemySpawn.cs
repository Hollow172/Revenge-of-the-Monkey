using System.Collections;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public int NumberOfEnemiesAlive = 0;

    public int wave = 1;

    private bool isSpawning = true;

    private bool finishedSpawning = false;

    private bool finishedWaiting = false;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Transform StartPoint;

    [SerializeField]
    private int multiplierOfEnemies = 3; //Multiplier of enemies per wave

    [SerializeField]
    private float cooldownBetweenSpawn = 2f;

    [SerializeField]
    private float cooldownBetweenWaves = 5f;

    private void Update()
    {
        if (isSpawning)
        {
            StartCoroutine(SpawnEnemy());
            isSpawning = false;
        }
        if (finishedSpawning == true && NumberOfEnemiesAlive <= 0)
        {
            StartCoroutine(NextWaveWaiter());
            if (finishedWaiting)
            {
                wave++;
                isSpawning = true;
                finishedSpawning = false;
                finishedWaiting = false;
            }
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

        //yield return new WaitForSeconds(cooldownBetweenWaves);
        finishedSpawning = true;
    }

    IEnumerator NextWaveWaiter()
    {
        yield return new WaitForSeconds(cooldownBetweenWaves);
        finishedWaiting = true;
    }
}
