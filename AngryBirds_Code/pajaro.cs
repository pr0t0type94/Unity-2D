using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class pajaro : MonoBehaviour
{
    public GameObject prefab;
    public Rigidbody2D myRigidBody;
    public CircleCollider2D myCollider;
    public GameObject tirachinas;
    CircleCollider2D tirach;
    public Vector2 iniposicion;

    public float impulseForce = 10.0f;
   
    float maxDistance = 1.4f;
    float maxDistsqrt;
    float resetSpeed = 0.06f;
    public string state;
    Vector2 direccion;
    public Sprite[] spritelist;


    Ray raytomouse;

    public AudioSource source;
    public AudioSource source2;
    public AudioClip hit;
    public AudioClip drag;
    public AudioClip fly;
    public AudioClip slingshot;

    public GameManager gamemanager;

    bool draggin;
    bool dead;
    bool yelow;
    void Start()
    {
        //myRigidBody.isKinematic = true;
        //tirach = tirachinas.GetComponent<CircleCollider2D>();
        if(gameObject.tag == "yelow")
        {
            yelow = true;
        }
        //
        iniposicion = transform.position;
        maxDistsqrt = maxDistance * maxDistance;
        //raytomouse = new Ray(tirachinas.GetComponent<Rigidbody2D>().position, Vector3.zero);
        raytomouse = new Ray(iniposicion, Vector3.zero);

        state = "ready";

        gameObject.GetComponent<SpriteRenderer>().sprite = this.gameObject.GetComponent<SpriteRenderer>().sprite;

        GameObject gamemanagerobject = GameObject.FindGameObjectWithTag("GameManager");
        gamemanager = gamemanagerobject.GetComponent<GameManager>();
    }

    void Update()
    {
        if(yelow)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                myRigidBody.AddRelativeForce(Vector2.right * 10, ForceMode2D.Impulse);
            }
        }



        if (myRigidBody.velocity.sqrMagnitude < resetSpeed && state == "hit" || Input.GetKeyDown(KeyCode.Space))
        {
         
            if (!dead)
            {
                Reset();
            }
            
            //Resources.Load("Prefabs/Red.prefab");
            //Instantiate(prefab, iniposicion, Quaternion.identity);
        }
        else if (myRigidBody.velocity.magnitude > resetSpeed && state != "hit" && state !="ready")
        {
            state = "flying";
        }

      if (state =="flying")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritelist[0];

        }

      if (state == "hit")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spritelist[1];

        }


        //Debug.Log(myRigidBody.velocity.sqrMagnitude);
    }


    private void OnMouseDrag()
    {
        //Debug.Log(Input.mousePosition);
        if (!draggin)
        {
            SoundManager.instance.PlaySingle(drag);
            draggin = true;
        }

        Vector2 mouseScreen = Input.mousePosition;
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(mouseScreen);

        direccion = mouseWorld - iniposicion;
        
        if(direccion.sqrMagnitude>maxDistsqrt)
        {
            raytomouse.direction = direccion;
            mouseWorld = raytomouse.GetPoint(maxDistance);
        }

        transform.position = new Vector3(mouseWorld.x, mouseWorld.y, transform.position.z);

        Debug.Log(mouseWorld);



    }

    private void OnMouseUp()
    {
        myRigidBody.isKinematic = false;
        myRigidBody.AddRelativeForce(-direccion * impulseForce, ForceMode2D.Impulse);
        source.PlayOneShot(fly);
        SoundManager.instance.PlaySingle(slingshot);
    }


    private void OnMouseDown()
    {
        //  Debug.Log(Input.mousePosition);
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 1)
        {
            source2.PlayOneShot(hit);
            state = "hit";
        }
    }


    private void Reset()
    {
        dead = true;
        gamemanager.UpdateMaxBirds();
        Destroy(this.gameObject, 4f);
        gamemanager.numbirds = 0;
    }



}