using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public TowerAttack towerAttack;

    private Transform target;

    [SerializeField]
    private GameObject particles;

    void Start()
    {
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        transform.Rotate(new Vector3(5, 0, 0), Space.Self);
        if (target == null)
        {
            Destroy (gameObject);
            return;
        }
        else
        {
            Vector2 dir = target.position - transform.position;
            float distanceThisFrame =
                towerAttack.projectailSpeed * Time.deltaTime;
            if (dir.sqrMagnitude <= distanceThisFrame)
            {
                target
                    .GetComponent<EnemyHealth>()
                    .takeDamage(towerAttack.damage);
                FindObjectOfType<AudioManager>().Play("Enemy Got Hit");
                Instantiate(particles, transform.position, Quaternion.identity);
                Destroy (gameObject);
            }
            transform
                .Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }
}
