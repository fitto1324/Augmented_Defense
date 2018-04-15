using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    //Pathing component
    EnemyManager enManager;

    Rigidbody rb;

    public List<Transform> wayPointList;
    int wayPointIndex = 0;


    Targeter towersTargeter;

	// Use this for initialization
	void Start ()
    {
        enManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        towersTargeter = GameObject.Find("Targeter").GetComponent<Targeter>();
        rb = GetComponent<Rigidbody>();
        wayPointList = enManager.GetWayPoints();
	}

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(1);
            Die();
        }
        if (other.transform == wayPointList[wayPointIndex])
        {
            wayPointIndex++;
        }
    }


    // Update is called once per frame
    void FixedUpdate ()
    {
        if (wayPointList.Count >= wayPointIndex)
        {
            float step = speed * Time.deltaTime;
            Vector3 movePosition = Vector3.MoveTowards(transform.position, wayPointList[wayPointIndex].position, step);
            rb.MovePosition(movePosition);
        }
	}

    public void DoDamage()
    {
        Die();
    }

    void Die()
    {
        towersTargeter.RemoveEnemy(this);
        GameObject.Destroy(this.gameObject);
        print("Enemy died");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
}
