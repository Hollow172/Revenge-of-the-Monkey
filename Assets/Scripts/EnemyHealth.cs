using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private int currHealth;

    public HealthBar healthBar;

    private EnemySpawn enemySpawn;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    void Update()
    {
        //this is just for testing
        //feel free to remove
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currHealth -= 20;
            healthBar.SetHealth (currHealth);
        }
        //enemy death
        if(currHealth <= 0)
        {
            enemySpawn.NumberOfEnemiesAlive--;
            Destroy (gameObject);
        }
    }
}
