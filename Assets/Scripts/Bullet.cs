using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public TowerAttack towerAttack;

    private Transform target;

    void Start()
    {
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target)
        {
            Vector2 dir = target.position - transform.position;
            float distanceThisFrame =
                towerAttack.projectailSpeed * Time.deltaTime;
            Debug.Log (distanceThisFrame);
            if (dir.sqrMagnitude <= distanceThisFrame)
            {
            }
            transform
                .Translate(dir.normalized * distanceThisFrame, Space.World);
        }
    }
}
