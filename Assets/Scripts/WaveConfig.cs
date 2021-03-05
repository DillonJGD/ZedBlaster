using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<GameObject> pathPrefabs;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    int numOfEnemies;
    [SerializeField] float moveSpeed = 2f;
    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetNumOfEnemies() { return numOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
    public GameObject GetRandomPath()
    {
        var randomPath = pathPrefabs[Random.Range(0, pathPrefabs.Count)];
        return randomPath;
    }
    
    public List<Transform> GetWaypoints() 
    { 
        var waveWaypoints = new List<Transform>();
        // Get a random path and put its waypoints in waveWaypoints
        foreach(Transform child in GetRandomPath().transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints; 
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        numOfEnemies = Random.Range(1,6);
    }
}
