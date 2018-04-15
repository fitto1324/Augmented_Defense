using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Laser))]
public class Tower : MonoBehaviour
{

    public float range;
    public int damage;
    public float attackDelayInSec;

    float lastAttack;

    Laser laser;

    public Transform target;


    public Targeter targeter;
	// Use this for initialization
	void Start ()
    {
        targeter = GameObject.Find("Targeter").GetComponent<Targeter>();
        laser = this.GetComponent<Laser>();
        lastAttack = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (target == null || Vector3.Distance(target.position, transform.position) > range)
        {
            target = null;
            //Get new target from enemy manager
            print("Getting new target");
            Enemy en = targeter.GetNearestTarget(this.transform, range);
            if (en != null)
            {
                target = en.transform;
            }
        }
        if ((lastAttack + attackDelayInSec) <= Time.time && target != null)
        {
            Attack();

        }
	}


    void Attack()
    {
        RaycastHit hit;
        Vector3 direction = (target.position - transform.position).normalized;
        Ray ray = new Ray(transform.position, direction);
        //Rangecheck before target is even 
        if (Physics.Raycast(ray, out hit, range))
        {
            StartCoroutine( laser.Shoot(hit.transform, transform));
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        lastAttack = Time.time;
    }
}
