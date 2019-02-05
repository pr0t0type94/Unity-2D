using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public MovingPath pathToFollow;

    public int CurrentWaypoint;

    public float speed;
    public float reachDistance= 0.1f;
    public string pathname;

    Vector3 last_pos;
    Vector3 current_pos;

    // Use this for initialization
    void Start () {       

        speed = gameObject.GetComponent<Enemy>().speed;

        pathToFollow = GameObject.Find(pathname).GetComponent<MovingPath>();
        last_pos = transform.position;

        CurrentWaypoint = 1;

	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector2.Distance(pathToFollow.path[CurrentWaypoint].position, transform.position);
        transform.position = Vector2.MoveTowards(transform.position, pathToFollow.path[CurrentWaypoint].position,speed*Time.deltaTime);

        //var rotation = Quaternion.LookRotation(pathToFollow.path[CurrentWaypoint].position-transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation,rotationspeed* Time.deltaTime);


        if (distance <= reachDistance)
        {
            CurrentWaypoint++;
        }

        if (CurrentWaypoint >= pathToFollow.path.Count)
        {
            GameManager.instance.UpdateLives();

            Destroy(this.gameObject);
        }
    }
}
