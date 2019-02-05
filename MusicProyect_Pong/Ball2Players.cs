using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball2Players : MonoBehaviour {

    public Vector3 ball_xMov;
    public Vector3 ball_yMov;

    public float minBallXSpeed;
    public float maxBallXSpeed;
    public float minBallYSpeed;
    public float maxBallYSpeed;
    public float pointsPlayer1 = 0;
    public float pointsPlayer2 = 0;
    public Text player1PointsText;
    public Text player2PointsText;


    protected float ball_xSpeed = 1;
    protected float ball_ySpeed = 1;

    public ParticleSystem hitParticles;

    public Transform iniPos;

    public GameController2Players gc;
    private Animation anim;

    public AudioSource moveSource;
    public AudioSource bounceSource;
    public AudioSource agudoSource;
    public AudioSource graveSource;
    public AudioSource scoreSource;

    public Player1 player1;
    public Player2 player2;

    public GameObject topCorner;
    public GameObject botCorner;

    private void Awake()
    {
        anim = GetComponent<Animation>();
        RestartGame();
    }
    public void Start()
    {
        UpdatePlayerPoints();
       

        hitParticles.Stop();
        transform.position = iniPos.position;
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position += ball_xSpeed * ball_xMov * Time.deltaTime;
        transform.position += ball_ySpeed * ball_yMov * Time.deltaTime;

        //controllerLifes(lifeNum);
        //updateText();
        if (ball_xMov == new Vector3(-1, 0, 0))
        {
            UpdateLeftPan();
        }
        else
        {
            UpdateRightPan();
        }



    }

    void UpdatePitchTop()
    {
        Vector2 dir = topCorner.transform.position - transform.position;
        float dist = dir.magnitude;
        moveSource.pitch = 1 + 1.8f / dist;
    }
    void UpdatePitchBottom()
    {
        Vector2 dir = topCorner.transform.position - transform.position;
        float dist = dir.magnitude;
        moveSource.pitch = 1 - dist / 30;
    }
    void UpdateLeftPan()
    {
        moveSource.panStereo -= 0.35f * Time.deltaTime;
        Vector2 dir = player1.transform.position - transform.position;
        float dist = dir.magnitude;
        Debug.Log(dist);
        moveSource.pitch = 1 + 1.7f / dist;

        //moveSource.pitch += 0.02f * Time.deltaTime;

        //moveSource.volume += 0.08f * Time.deltaTime;
    }
    void UpdateRightPan()
    {
        moveSource.panStereo += 0.35f * Time.deltaTime;

        Vector2 dir = player2.transform.position - transform.position;
        float dist = dir.magnitude;
        Debug.Log(dist);
        moveSource.pitch = 1 + 1.7f / dist;

        // moveSource.pitch -= 0.02f * Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            scoreSource.Play();
            pointsPlayer2 += 1;
            gc.RestartGame();
        }
        if (collision.gameObject.tag == "DeadZone2")
        {
            scoreSource.Play();
            pointsPlayer1 += 1;
            gc.RestartGame();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TopCorner")
        {
            ball_yMov = -ball_yMov;
            hitParticles.transform.position = transform.position;
            hitParticles.Play();
            agudoSource.Play();


        }

        if (collision.gameObject.tag == "DownCorner")
        {
            ball_yMov = -ball_yMov;
            hitParticles.transform.position = transform.position;
            hitParticles.Play();
            graveSource.Play();

        }

       
        if (collision.gameObject.tag == "Player")
        {        
            bounceSource.Play();
            ball_xMov = -ball_xMov;
        }

    }

    public void RestartGame()
    {
        GiveStartSpeed();
        UpdatePlayerPoints();
        transform.position = iniPos.position;
        anim.Play();
        moveSource.panStereo = 0.0f;
        moveSource.pitch = 1f;
    }
    void UpdatePlayerPoints()
    {
        player1PointsText.text = pointsPlayer1.ToString();
        player2PointsText.text = pointsPlayer2.ToString();

    }
    //private void updateText()
    //{
    //    textPoint.text = "" + points;
    //}
    void GiveStartSpeed()
    {
   
        float rnd = Random.Range(0, 2);
        float rnd2 = Random.Range(0, 2);
        if (rnd == 0)
        {
            ball_xMov = new Vector3(-1, 0, 0);
            if(rnd2==0)
            {
                ball_yMov = new Vector3(0, -1, 0);

            }
            else
            {
                ball_yMov = new Vector3(0, 1, 0);

            }
        }
        else
        {
            ball_xMov = new Vector3(1, 0, 0);

            if (rnd2 == 0)
            {
                ball_yMov = new Vector3(0, -1, 0);

            }
            else
            {
                ball_yMov = new Vector3(0, 1, 0);

            }
        }

        ball_xSpeed = Random.Range(minBallXSpeed/2, maxBallXSpeed / 2);
        ball_ySpeed = Random.Range(minBallYSpeed / 2, maxBallYSpeed / 2);
    }
    
}
