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
    private GameObject bulletPrefab;

    public float attackRate;

    private float attackCountdown = 0f;

    public float projectailSpeed;

    public int damage;

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
            }
        }
        else
        {
            if (attackCountdown <= 0f)
            {
                transform.up = target.transform.position - transform.position;
                Shoot();
                attackCountdown = 1f / attackRate;
            }
            attackCountdown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject currBullet =
            (GameObject)
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = currBullet.GetComponent<Bullet>();

        if (bullet != null) bullet.Seek(target.transform);
    }
}
