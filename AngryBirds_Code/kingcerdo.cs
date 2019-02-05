using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class kingcerdo : MonoBehaviour
{

    public bool iscreated;
    public CircleCollider2D myCollider;
    public Rigidbody2D myRigidBody;
    public SpriteRenderer mySprite;
    public GameObject pig;
    public AnimationClip smoke;
    public Animation myAnimation;
    public string anim;
    float damageConstant = 3f;
    public float Health;
    public float currHealth;
    public Sprite[] spritelist;
    public int points = 10000;
    public GameObject point;

    public AudioClip[] serdo;
    public AudioSource source;
    public AudioSource source2;

    public GameManager gamemanager;

    // Use this for initialization
    void Start()
    {
        Health = 300;
        currHealth = Health;
        mySprite.sprite = spritelist[0];

        GameObject gamemanagerobject = GameObject.FindGameObjectWithTag("GameManager");
        gamemanager = gamemanagerobject.GetComponent<GameManager>();

        myAnimation = GetComponent<Animation>();

        myAnimation.clip = smoke;
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

        if (currHealth <= 0)
        {

            if(!iscreated)
            {
                Instantiate(point, transform.position, Quaternion.identity);

                SoundManager.instance.PlaySingle(serdo[1]);

                gamemanager.AddScore(points);
                iscreated = true;
                Destroy(this.gameObject);

            }


            myAnimation.Play(smoke.name);

            //var humo =Instantiate(destroanim, transform.position, Quaternion.identity);
            //humo.GetComponent<Animation>().Play();
            //Invoke("DestroyNow", smoke.length);


        }

    }
    void DestroyNow()
    {
        Destroy(this.gameObject);
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.relativeVelocity.magnitude > 0.01)
        {
            if (gameObject.GetComponent<SpringJoint2D>() == true)
            {
                
                Destroy(gameObject.GetComponent<SpringJoint2D>());
            }
            currHealth -= damageConstant * col.relativeVelocity.magnitude;
            SoundManager.instance.PlaySingle(serdo[0]);
            //source.PlayOneShot(serdo[0]);

        }



    }
}




