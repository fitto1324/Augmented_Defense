using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour {

    [SerializeField]
    List<Enemy> enemies;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (enemies.Contains(enemy))
        {
            enemies.Remove(enemy);
        }
    }

    public Enemy GetNearestTarget(Transform tower, float range)
    {
        Enemy bestTarget = null;
        float bestDistance = 10000;
        foreach (var enemy in enemies)
        {
            float distance = Vector3.Distance(tower.position, enemy.transform.position);
            if (distance <= range)
            {
                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestTarget = enemy;
                }
            }
        }
        return bestTarget;
    }
}
