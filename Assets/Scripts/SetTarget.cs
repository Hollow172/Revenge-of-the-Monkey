using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTarget : MonoBehaviour
{
    [SerializeField]
    private TowerAttack towerAttack;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        towerAttack.ListOfObjectsInRange.Add(collider.gameObject);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        towerAttack.ListOfObjectsInRange.Remove(collider.gameObject);
    }
}
