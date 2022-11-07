using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float speed = 1f;

    private int currentWayPointNumber = 1;

    private Transform currentWayPoint;

    private Rigidbody2D rb;

    private Transform[] list;

    void Start()
    {
        list =
            GameObject
                .Find("Points")
                .transform
                .Find("Waypoints")
                .gameObject
                .GetComponentsInChildren<Transform>();
        currentWayPoint = list[currentWayPointNumber];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        nextWaypoint();
    }

    void Update()
    {
        Vector2 heading = currentWayPoint.position - this.transform.position;
        float distance = heading.magnitude;
        if (distance >= 0.1)
        {
            Vector2 direction = heading / distance;
            transform.Translate(direction * Time.deltaTime * speed);
        }
    }

    private Transform nextWaypoint()
    {
        if (currentWayPointNumber < list.Length - 1)
        {
            currentWayPointNumber++;
            currentWayPoint = list[currentWayPointNumber];
            return currentWayPoint;
        }
        return currentWayPoint;
    }
}
