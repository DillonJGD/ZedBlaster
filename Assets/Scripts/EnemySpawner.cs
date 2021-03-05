using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Game Params
    List<Transform> waypoints;

    // Cached Refs
    [SerializeField] WaveConfig waveConfig;
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public List<Transform> GetPath()
    {
        return waypoints;
    }

    IEnumerator SpawnEnemies()
    {
        for(int i = 0; i <= waveConfig.GetNumOfEnemies(); i++)
        {
            waypoints = waveConfig.GetWaypoints();
            Instantiate(
                waveConfig.GetEnemyPrefab(),
                waypoints[0].transform.position,
                Quaternion.identity
            );
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
