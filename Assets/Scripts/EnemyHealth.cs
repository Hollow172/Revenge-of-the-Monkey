using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private int currHealth;

    public HealthBar healthBar;

    private enemySpawn enemySpawn;

    private CashManager cashManager;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
        enemySpawn = FindObjectOfType<enemySpawn>();
        cashManager =
            GameObject.Find("GameManager").GetComponent<CashManager>();
    }

    public void takeDamage(int damage)
    {
        currHealth -= damage;
        healthBar.SetHealth (currHealth);
    }

    void Update()
    {
        //enemy death
        if (currHealth <= 0)
        {
            enemySpawn.NumberOfEnemiesAlive--;
            cashManager.addCash(30); //Here change it to money, enemy is worth
            Destroy (gameObject);
        }
    }
}
