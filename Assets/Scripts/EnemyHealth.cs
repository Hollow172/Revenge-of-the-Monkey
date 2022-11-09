using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;

    [SerializeField]
    private int currHealth;

    public HealthBar healthBar;

    void Start()
    {
        currHealth = maxHealth;
        healthBar.SetMaxHealth (maxHealth);
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
    }
}
