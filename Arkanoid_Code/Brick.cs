using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brick : MonoBehaviour {

    public GameObject brick;
    public GameObject ball;
    public GameObject slowgift;
    public GameObject capsulegift;
    public GameObject gluegift;
    SpriteRenderer brik;
    SpriteRenderer ball1;
    public int lives;
    public float x;
    int rnd;
    int rnde;
    public bool special;
    public int counter;


    public AudioClip hitbrick;
    public AudioClip destroybrick;
    private AudioSource source;


    float hit(Vector2 ballPos, Vector2 brickpos,
               float racketWidth)
    {

        return (ballPos.x - brickpos.x) / racketWidth;
    }

    void CreateGift()
    {
        rnde = Random.Range(1, 2);
        switch (rnde)
        {
            case 1:
                Instantiate(slowgift,this.gameObject.transform.position,this.gameObject.transform.rotation);
                break;
            case 2:
                Instantiate(capsulegift,this.gameObject.transform.position, this.gameObject.transform.rotation);
                break;
            case 3:
                Instantiate(gluegift, this.gameObject.transform.position, this.gameObject.transform.rotation);
                break;
        }
    }

  

    void Start () {
        lives = Random.Range(1, 3);
        brik = brick.GetComponent<SpriteRenderer>();
        ball1 = ball.GetComponent<SpriteRenderer>();

        source = GetComponent<AudioSource>();

        rnd = Random.Range(1, 8);

        if(this.gameObject.tag=="special")
        {
            special = true;
        }



    }

    // Update is called once per frame
    void Update () {

       

        //x = (int)hit(ball.transform.position, brick.transform.position, brik.size.x);


        if (ball.transform.position.y +ball1.size.y/2 < this.brik.bounds.max.y && ball.transform.position.y +ball1.size.y / 2 > this.brik.bounds.min.y)
        {
            if (ball.transform.position.x + ball1.size.x / 2 < this.brik.bounds.max.x && ball.transform.position.x + ball1.size.x / 2 > this.brik.bounds.min.x)
            {
                if (!special)
                {
                    source.PlayOneShot(hitbrick, 5.0f);
                    lives -= 1;
                    Ball.ForwardVec = new Vector2(Ball.ForwardVec.x, -Ball.ForwardVec.y).normalized;

                    brik.color = new Color(brik.color.r, brik.color.g, brik.color.b, .7f);

                    if (lives == 0)
                    {
                        source.PlayOneShot(destroybrick, 5.0f);
                        Ball.score += 100;
                        Destroy(this.brick);

                        if (rnd == 1)
                        {
                            CreateGift();
                        }

                    }
                }
                else
                {
                    Ball.ForwardVec = new Vector2(Ball.ForwardVec.x, -Ball.ForwardVec.y).normalized;
                }

            }

        }
    }
}
