using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public ObservableCollection<GameObject>
        ListOfObjectsInRange = new ObservableCollection<GameObject>();

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
        ListOfObjectsInRange.CollectionChanged += ListenCollectionChanged;
    }

    private void ListenCollectionChanged(
        object sender,
        NotifyCollectionChangedEventArgs e
    )
    {
        if (ListOfObjectsInRange.Count != 0)
            target = ListOfObjectsInRange[0];
        else
            target = null;
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
                rotateToEnemy();
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

    private void OnDestroy()
    {
        ListOfObjectsInRange.CollectionChanged += ListenCollectionChanged;
    }

    private void rotateToEnemy()
    {
        Vector3 targetPos;
        Vector3 thisPos;
        float angle;
        targetPos = target.transform.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
