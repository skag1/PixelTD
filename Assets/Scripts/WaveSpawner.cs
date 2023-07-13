using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Waves[] waves;
    private int currentEnemyIndex;
    private int currentWaveIndex;
    private int enemiesLeftToSpawn;

    private void Start()
    {
        enemiesLeftToSpawn = waves[0].WaveSettings.Length;
        LaunchWave();
    }

    private IEnumerator SpawnEnemyInWave()
    {
        if (enemiesLeftToSpawn > 0)
        {
            yield return new WaitForSeconds(waves[currentWaveIndex]
                .WaveSettings[currentEnemyIndex]
                .SpawnDelay);
            Instantiate(waves[currentWaveIndex]
                .WaveSettings[currentEnemyIndex].Enemy,
                waves[currentWaveIndex].WaveSettings[currentEnemyIndex]
                .NeededSpawner.transform.position, Quaternion.identity);
            enemiesLeftToSpawn--;
            currentEnemyIndex++;
            StartCoroutine(SpawnEnemyInWave());
        }
        else
        {
            if (currentWaveIndex < waves.Length - 1)
            {
                currentWaveIndex++;
                enemiesLeftToSpawn = waves[currentWaveIndex].WaveSettings.Length;
                currentEnemyIndex = 0;
            }
        }
    }

    public void LaunchWave()
    {
        StartCoroutine(SpawnEnemyInWave());
    }
}

[System.Serializable]
public class Waves
{
    [SerializeField] private WaveSettings[] waveSettings;
    public WaveSettings[] WaveSettings { get => waveSettings; }
}

[System.Serializable]
public class WaveSettings
{
    [SerializeField] private GameObject enemy;
    public GameObject Enemy { get => enemy; }
    [SerializeField] private GameObject neededSpawner;
    public GameObject NeededSpawner { get => neededSpawner; }
    [SerializeField] private float spawnDelay;
    public float SpawnDelay { get => spawnDelay; }
}
