using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour {
    public float speed;
    public GameObject player;
    public GameObject deadzone;
    public SpriteRenderer playr;
    public SpriteRenderer giftt;
    public AudioClip gifted;
    private AudioSource source;

    public void GiveGift(string tag)
    {
        if (tag == "slow")
        {

            Ball.slowball = true;
           
        }
        else if (tag == "capsule")
        {

        }

        else if (tag == "glued")
        {

        }
    }
	// Use this for initialization
	void Start () {
        speed = 3;
        playr = player.GetComponent<SpriteRenderer>();
        giftt= this.gameObject.GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        
           if (giftt.bounds.Intersects(playr.bounds))
            {
                
                    Debug.Log("powerup");
                    GiveGift(this.gameObject.tag);
                    source.PlayOneShot(gifted, 2.0f);
                    Destroy(this.gameObject);

                
            }
        if (this.gameObject.transform.position.y < deadzone.transform.position.y)
        {

            Destroy(this.gameObject);
        }


    }
}
