using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] private Game gameScript;
    [SerializeField] private GameObject gameOverText;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            takeDamage(200);
            audioManager.Play("Enemy Attack");
            particles.Play();
            Destroy(collision.gameObject);
        }

    }

    void takeDamage(int damage)
    {
        currHealth -= damage;
        healthBar.SetHealth (currHealth);
        if (currHealth <= 0)
        {
            Destroy (gameObject);
            gameScript.EndGame();
            gameOverText.SetActive(true);
        }
    }
}
