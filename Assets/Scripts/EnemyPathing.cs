using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    /// Params
    int waypointIndex = 0;
    [SerializeField] float moveSpeed = 2f;

    /// Cached References
    List<Transform> waypoints;
    [SerializeField] WaveConfig waveConfig;
    EnemySpawner enemySpawner;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        waypoints = enemySpawner.GetPath();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        MoveAlongPath();
    }

    public List<Transform> GetWayPoints() { return waypoints; }

    void MoveAlongPath()
    {
        if(waypointIndex <= waypoints.Count - 1)
        {
            var targetPos = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(
                transform.position, 
                targetPos, 
                movementThisFrame
            );

            if (transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
