using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 1000;

    [SerializeField]
    private int currHealth;

    public HealthBar healthBar;

    private enemySpawn enemySpawn;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
        enemySpawn = FindObjectOfType<enemySpawn>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //This will be for different types of enemies
        //They'll deal more hp to base
        //takeDamage(collision.gameObject.damage)
        takeDamage(100);
        FindObjectOfType<AudioManager>().Play("Enemy Attack");
        Destroy(collision.gameObject);
        enemySpawn.NumberOfEnemiesAlive--;
    }

    void takeDamage(int damage)
    {
        currHealth -= damage;
        healthBar.SetHealth (currHealth);
        if (currHealth <= 0)
        {
            //End game here
            Destroy (gameObject);
        }
    }
}
