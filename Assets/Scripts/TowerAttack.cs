using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public List<GameObject> ListOfObjectsInRange = new List<GameObject>();

    private GameObject target;

    [SerializeField]
    private Transform firePoint;

    public float attackRate;

    private float attackCountdown = 0f;

    public float projectailSpeed;

    public float damage;

    void Start()
    {
        ListOfObjectsInRange.Clear();
    }

    void Update()
    {
        if (!target)
        {
            if (ListOfObjectsInRange.Count >= 1)
                target = ListOfObjectsInRange[0];
        }
        else
        {
            if (attackCountdown <= 0f)
            {
                Shoot();
                attackCountdown = 1f / attackRate;
            }
            attackCountdown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        Debug.Log("Shoot");
    }
}
