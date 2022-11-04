using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;

    public Transform StartPoint;


    // just simple spawn for testing th ai
    void Start()
    {
        Instantiate(enemy, StartPoint.position, Quaternion.identity);
    }
}
