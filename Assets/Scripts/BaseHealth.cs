using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public HealthBar healthBar;

    [SerializeField]
    private int maxHealth = 1000;

    [SerializeField]
    private int currHealth;

    [SerializeField]
    private ParticleSystem particles;

    [SerializeField]
    private AudioManager audioManager;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        takeDamage(200);
        audioManager.Play("Enemy Attack");
        particles.Play();
        Destroy(collision.gameObject);
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
