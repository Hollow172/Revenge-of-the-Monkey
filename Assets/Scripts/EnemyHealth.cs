using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private int currHealth;

    public HealthBar healthBar;

    private EnemySpawn enemySpawn;

    private CashManager cashManager;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
        enemySpawn = FindObjectOfType<EnemySpawn>();
        cashManager =
            GameObject.Find("GameManager").GetComponent<CashManager>();
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
        if (currHealth <= 0)
        {
            enemySpawn.NumberOfEnemiesAlive--;
            cashManager.addCash(30); //Here change it to money, enemy is worth
            Destroy (gameObject);
        }
    }
}
