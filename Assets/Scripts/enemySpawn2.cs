using UnityEngine;
using System.Collections;

public class enemySpawn2 : MonoBehaviour
{

    public int numberOfEnemiesAlive = 0;

    public bool isSpawning = true;

    private int wave = 1;

    [SerializeField] private GameObject enemy;

    [SerializeField] private Transform StartPoint;

    [SerializeField] private int multiplierOfEnemies = 3; //Multiplier of enemies per wave

    [SerializeField] private float cooldownBetweenSpawn = 2f;

    private void Update()
    {
        if (isSpawning)
        {
            StartCoroutine(SpawnEnemy());
            isSpawning = false;
        }
        if(isSpawning == false && numberOfEnemiesAlive <= 0)
        {
            wave++;
            isSpawning=true;
        }
    }

    IEnumerator SpawnEnemy()
    {
        for(int i = 0; i < multiplierOfEnemies * wave; i++)
        {
            Instantiate(enemy, StartPoint.position, Quaternion.identity);
            numberOfEnemiesAlive++;
            yield return new WaitForSeconds(cooldownBetweenSpawn);
        }
    }

}
