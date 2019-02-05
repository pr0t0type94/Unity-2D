using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice : MonoBehaviour {

    public float Health;
    public float currHealth;

    //public Collider2D myCollider;
    //public Rigidbody2D myRigidBody;
    public SpriteRenderer mySprite;
    public Animation destroy;
    float damageConstant = 3f;
    public Sprite[] spritelist;

    public AudioClip hit;
    public AudioClip destro;

    // Use this for initialization
    void Start()
    {
        Health = 40;
        currHealth = Health;

    }

    // Update is called once per frame
    void Update()
    {
        if (currHealth / Health > 0.8)
        {
            mySprite.sprite = spritelist[0];
        }

        if (currHealth / Health <= 0.8)
        {
            mySprite.sprite = spritelist[1];

        }
        if (currHealth / Health <= 0.6)
        {
            mySprite.sprite = spritelist[2];

        }
        if (currHealth / Health <= 0.4)
        {
            mySprite.sprite = spritelist[3];

        }

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > 1)
        {

            currHealth -= damageConstant * col.relativeVelocity.magnitude;
            SoundManager.instance.PlaySingle(hit);

        }

        if (currHealth < 0)
        {

            SoundManager.instance.PlaySingle(destro);

            Destroy(this.gameObject);

        }

    }

    void Destroy()
    {

        //instantiate some fancy particle system for special effects
        destroy.Play();
    }

   
}
