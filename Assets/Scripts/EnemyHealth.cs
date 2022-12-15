using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 130;

    [SerializeField]
    private int currHealth;

    [SerializeField]
    private int enemyWorth = 5; //jak duzo golda dostaniemy za przeciwnika

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
            cashManager.addCash(enemyWorth); //Here change it to money, enemy is worth
            Destroy (gameObject);
            FindObjectOfType<AudioManager>().Play("Enemy Death");
        }
    }
}
