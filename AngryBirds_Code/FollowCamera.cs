using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public Transform projectile;        // The transform of the projectile to follow.
    public Transform farLeft;           // The transform representing the left bound of the camera's position.
    public Transform farRight;          // The transform representing the right bound of the camera's position.
    public float speed;
    public bool stillmoving;

    void Start()
    {

    }
    void Update()
    {
        TryFindProjectile();

        transform.position += new Vector3(projectile.position.x, 0, projectile.position.z);


            if (projectile)
        {
            
            UpdateCamera();
        }
        
        
        /*
        else if (control.CurrentGame.CheckMovementStopped())
        {
            if (ResetCamera())
                TryFindProjectile();
        }*/


    }

    void TryFindProjectile()
    {
        
            if (GameObject.FindGameObjectWithTag("pajaro"))
            {
                projectile = GameObject.FindGameObjectWithTag("pajaro").transform;
            }
            if (GameObject.FindGameObjectWithTag("yelow"))
            {
                projectile = GameObject.FindGameObjectWithTag("yelow").transform;
            }
        
    }

    void UpdateCamera()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(5 * speed * Time.deltaTime, 0, 0);
        }


        Vector3 newPosition = transform.position;

        newPosition.x = projectile.position.x;

        newPosition.x = Mathf.Clamp(newPosition.x, farLeft.position.x, farRight.position.x);
        transform.position = newPosition;
    }

    bool ResetCamera()
    {
        Vector3 newPosition = farLeft.position;
        if (transform.position.x != farLeft.position.x)
        {
            newPosition.x -= Time.deltaTime;
            newPosition.z = -10f;
            newPosition.y = 0;
            newPosition.x = Mathf.Clamp(newPosition.x, farLeft.position.x, farRight.position.x);
            transform.position = newPosition;
            return false;
        }
        return true;

    }
}
