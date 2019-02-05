using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour {
    Vector2 iniposition;
    float speed=2.0f;
    float maxdist = 5f;
	// Use this for initialization
	void Start () {
        Vector3 iniposition= transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += Vector3.up * speed * Time.deltaTime;

        if(this.transform.position.y > iniposition.y + maxdist)
        {
            Destroy(this.gameObject);
        }
	}
}
