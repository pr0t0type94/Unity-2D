using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {


    public float speed;
    public float damage;

    public GameObject target;
    public GameObject myturret;
    private Turret turret;
    // Use this for initialization

    void UpdateStats()
    {
        damage = GetComponentInParent<Turret>().dmg;

    }
    private void FixedUpdate()
    {
        UpdateStats();

    }

    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        target = GetComponentInParent<Turret>().target;

        if (target == null)
        {
            Destroy(gameObject);
        }

        else
        {
        var direction = target.transform.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
        }
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        { Destroy(this.gameObject); }
    }
}
