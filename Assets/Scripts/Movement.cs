using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] GameObject[] points;
    [SerializeField] float movementSpeed;
    int i = 0;

    private void Start()
    {
        points = GameObject.FindGameObjectsWithTag("PathPoint");
    }
    void Update()
    {
        var step = movementSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, points[i].transform.position, step);
        if(Vector2.Distance(transform.position, points[i].transform.position) < 0.1f)
        {
            i++;
        }
    }
}
