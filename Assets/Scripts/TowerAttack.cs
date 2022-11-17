using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public List<GameObject> ListOfObjectsInRange = new List<GameObject>();

    [HideInInspector]
    public GameObject target;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject bullet;

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
            {
                target = ListOfObjectsInRange[0];
                bullet.GetComponent<Bullet>().Seek(target.transform);
                Debug.Log("passed info to bullet");
            }
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
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
