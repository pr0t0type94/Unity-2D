using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crownpig : MonoBehaviour
{
    public bool iscreated;

    public CircleCollider2D myCollider;
        public Rigidbody2D myRigidBody;
        public SpriteRenderer mySprite;
        public GameObject pig;
        public Animation destroanim;
        float damageConstant = 4f;
        public float Health;
        public float currHealth;
        public Sprite[] spritelist;
    public int points = 10000;
    public GameObject point;


    public AudioClip[] serdo;

    public AudioClip hit;
        public AudioClip destro;
    public GameManager gamemanager;

    // Use this for initialization
    void Start()
        {
            Health = 50;
            currHealth = Health;
            mySprite.sprite = spritelist[0];

        GameObject gamemanagerobject = GameObject.FindGameObjectWithTag("GameManager");
        gamemanager = gamemanagerobject.GetComponent<GameManager>();
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
            if (currHealth / Health <= 0.2)
            {
                mySprite.sprite = spritelist[4];

            }

        if (currHealth <= 0)
        {
            if (!iscreated)
            {
                Instantiate(point, transform.position, Quaternion.identity);
                gamemanager.AddScore(points);
                iscreated = true;
                SoundManager.instance.PlaySingle(serdo[1]);
                Destroy(this.gameObject);
            }
        }
    }


        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.relativeVelocity.magnitude > 1)
            {
           
                currHealth -= damageConstant * col.relativeVelocity.magnitude;
                SoundManager.instance.PlaySingle(serdo[0]);
            }

        }

    
}



