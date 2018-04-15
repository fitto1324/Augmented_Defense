using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public List<Transform> wayPoints;
    public List<Wave> waves;
    int waveIndex = 0;

    public float timeBetweenWaves;
    float timeToNextWave;
    Spawner spawner;
    public bool gameStarted = false;
	// Use this for initialization
	void Start () {
        spawner = GameObject.Find("SpawnPoint").GetComponent<Spawner>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameStarted)
        {
            if (spawner.toSpawn == 0 && timeToNextWave < Time.time)
            {
                Wave wave = waves[waveIndex];
                print(waveIndex);
                if (wave == null)
                {
                    print("You won the game!");
                }
                spawner.StartSpawning(wave.amountToSpawn, wave.enemyPrefab);
                waveIndex++;
            }
            else if (spawner.toSpawn != 0)
            {
                timeToNextWave = Time.time + timeBetweenWaves;
            }
        }

	}

    //Enemies retrieve waypoints
    public List<Transform> GetWayPoints()
    {
        return wayPoints;
    }

    public void StartGame()
    {
        gameStarted = true;
    }

}

[System.Serializable]
public class Wave
{
    public Enemy enemyPrefab;
    public int amountToSpawn;
}