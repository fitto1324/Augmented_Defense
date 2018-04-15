using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int startingHealth;
    int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Enemy enemy = other.GetComponent<Enemy>();
        //if (enemy != null)
        //{
        //    enemy.DoDamage();
        //    TakeDamage(1);
        //}
    }


    public void Reset()
    {
        health = startingHealth;
    }

    public void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        print("Player died, do something to reset");
    }
}
