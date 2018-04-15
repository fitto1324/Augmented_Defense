using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float thickness;

    public float duration;

    LineRenderer lineRenderer;
	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = (thickness);
        lineRenderer.endWidth = (thickness);
        lineRenderer.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    
    public IEnumerator Shoot(Transform target, Transform origin)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, origin.position);
        if (target != null)
        {
            lineRenderer.SetPosition(1, target.position);
        }
        else
        {
            lineRenderer.SetPosition(1, origin.position);
        }
        yield return new WaitForSeconds(duration);
        lineRenderer.enabled = false;
    }
}
