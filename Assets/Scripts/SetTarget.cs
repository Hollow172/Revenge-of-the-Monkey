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
        Debug.Log(towerAttack.ListOfObjectsInRange.Count);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        towerAttack.ListOfObjectsInRange.Remove(collider.gameObject);
        Debug.Log(towerAttack.ListOfObjectsInRange.Count);
    }
}
