using System.Collections;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public int numberOfEnemiesAlive = 0;

    public static bool isSpawning = true;

    private int wave = 1;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private Transform StartPoint;

    [SerializeField]
    private int multiplierOfEnemies = 3; //Multiplier of enemies per wave

    [SerializeField]
    private float cooldownBetweenSpawn = 2f;

    private void Update()
    {
        if (isSpawning)
        {
            StartCoroutine(SpawnEnemy());
            isSpawning = false;
        }
        if (isSpawning == false && numberOfEnemiesAlive <= 0)
        {
            wave++;
            isSpawning = true;
        }
        //Debug.Log(wave);
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
                numberOfEnemiesAlive++;
                yield return new WaitForSeconds(cooldownBetweenSpawn);
            }
            else
            {
                Debug.Log("Failed to locate closest hit");
            }
        }
    }
}
