using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class EnemySpawner : MonoBehaviour
{
    private IEnumerator spawnerCoroutine;
    
    [SerializeField]
    private WaveSO[] wavesData;

    [SerializeField] 
    private Transform[] spawnPointsReferences;

    [SerializeField]
    private float timeUntilNextSpawn;
    
    [SerializeField]
    private int currentWaveIndex = 0;
    
    private GameManager gameManager;

    private int enemiesInScene = 0;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void Activate()
    {
        spawnerCoroutine = Spawner();
        StartCoroutine(spawnerCoroutine);
    }

    public void Deactivate()
    {
        StopCoroutine(spawnerCoroutine);
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            WaveSO currentWave = wavesData[currentWaveIndex];
            enemiesInScene = currentWave.enemies.Count;
            yield return SpawnWave(currentWave);
            yield return new WaitForSeconds(timeUntilNextSpawn);
            currentWaveIndex = (currentWaveIndex + 1) % wavesData.Length;
        }
    }

    private IEnumerator SpawnWave(WaveSO wave)
    {

        foreach (var enemy in wave.enemies)
        {
            StartCoroutine(SpawnEnemyAndNotify(enemy));
        }

        while (enemiesInScene > 0)
        {
            yield return null;
        }
    }

    private IEnumerator SpawnEnemyAndNotify(AirCraftSpawnData spawnData)
    {
        yield return SpawnEnemy(spawnData);
    }

    private IEnumerator SpawnEnemy(AirCraftSpawnData spawnData)
    {
        yield return new WaitForSeconds(spawnData.spawnDelay);

        var spawnPoint = GetSpawnPointByLocation(spawnData.spawnLocation);
        
        InstantiateEnemy(spawnData.prefab, spawnPoint);
    }

    private void InstantiateEnemy(Enemy enemyPrefab, Transform spawningPoint)
    {
        var enemy = Instantiate(enemyPrefab, spawningPoint.position, enemyPrefab.transform.rotation);
        enemy.OnKilled += gameManager.OnEnemyKilled;
        enemy.OnGone += () => enemiesInScene--;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (var spawnPoint in spawnPointsReferences)
        {
            Gizmos.DrawSphere(spawnPoint.position, 0.5f);
        }
    }

    private Transform GetSpawnPointByLocation(SpawnLocationsEnum location)
    {
        return location switch
        {
            SpawnLocationsEnum.TopLeft => spawnPointsReferences[0],
            SpawnLocationsEnum.CenterLeft => spawnPointsReferences[1],
            SpawnLocationsEnum.Center => spawnPointsReferences[2],
            SpawnLocationsEnum.CenterRight => spawnPointsReferences[3],
            SpawnLocationsEnum.TopRight => spawnPointsReferences[4],
            _ => throw new Exception("Unknown Spawn Location")
        };
    }
}