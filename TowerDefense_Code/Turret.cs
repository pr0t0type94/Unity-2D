using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]

public class Turret : MonoBehaviour {
    public GameObject bala;
    private GameObject bullet;

    public AudioSource source;

    private float shoottimer;

    public float firerate;

    public static int metracost;
    public static int cañoncost;

    public int dmg;

    
    public float radius;
    public Quaternion inirotation;

    public GameObject target;
    private GameObject[] enemies;

    private bool nearenemies;

    // Use this for initialization
    void Start () {


        source = GetComponent<AudioSource>();
        metracost = 50;
        cañoncost = 150;
        shoottimer = firerate;
        inirotation = transform.rotation;
	}
	void Clicked()
    {
        
    }
	// Update is called once per frame
    bool Nearenemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(enemy.transform.position, transform.position) < radius)
            {
                return true;
                //Debug.Log(Vector2.Distance(target.transform.position, transform.position));
            }

        }

        return false;
    }

    public GameObject findTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(enemy.transform.position, transform.position) < radius)
            {
                target = enemy;
                return target;
                //Debug.Log(Vector2.Distance(target.transform.position, transform.position));
            }

        }

        return null;
    }


    void Update () {

        if(Nearenemy() == true)
        {
            target = findTarget();

            float angle = Mathf.Atan2(target.transform.position.y, target.transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.5f * Time.deltaTime);
            Shoot();
            //Debug.Log(target);
            //Debug.Log(angle);

        }

        else
        {
            transform.rotation = inirotation;
            target = null;
        }
        
    }

    void Shoot()
    {
        shoottimer -= Time.deltaTime;

        if(shoottimer <= 0 )
        {
            bullet = Instantiate(bala, transform.position, transform.rotation);
            shoottimer = firerate;
            bullet.transform.parent = gameObject.transform;
            source.PlayOneShot(source.clip);
        }

    }

    void showRadius()
    {

    }
}
