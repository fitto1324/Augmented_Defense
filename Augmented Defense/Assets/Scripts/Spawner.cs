using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float spawnRate;
    float lastSpawn;
    public int toSpawn;

    public Enemy enemyPrefab;

    Vector3 spawnPos;

    Targeter towersTargeter;

	// Use this for initialization
	void Start () {
        towersTargeter = GameObject.Find("Targeter").GetComponent<Targeter>();
        lastSpawn = Time.time;
        spawnPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (toSpawn > 0 && (lastSpawn + spawnRate) <= Time.time)
        {
            Spawn();
        }
	}

    private void Spawn()
    {
        Enemy enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity) as Enemy;
        lastSpawn = Time.time;
        toSpawn--;
        towersTargeter.AddEnemy(enemy);
    }

    public void StartSpawning(int amount, Enemy enemyPrefabToSpawn)
    {
        enemyPrefab = enemyPrefabToSpawn;
        toSpawn = amount;
    }
}
