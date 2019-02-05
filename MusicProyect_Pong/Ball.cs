using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    // Use this for initialization
    public Vector3 ball_xMov;
    public Vector3 ball_yMov;

    public Text textPoint;

    public float minBallXSpeed;
    public float maxBallXSpeed;
    public float minBallYSpeed;
    public float maxBallYSpeed;
    public float points = 0;

    public Image life1;
    public Image life2;
    public Image life3;
    public float lifeNum = 3;

    protected float ball_xSpeed = 1;
    protected float ball_ySpeed = 1;

    public ParticleSystem hitParticles;
    public Material ballMat;

    public Transform iniPos;

    public GameController gc;

    private float timer;
    private bool startTimer;

    public Animation anim;

    public AudioSource moveSource;
    public AudioSource scorePointSource;
    public AudioSource loseHpSource;
    public AudioSource agudoSource;
    public AudioSource graveSource;

    public Player1 player;
    public GameObject topCorner;
    public GameObject botCorner;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }
    public virtual void Start ()
    {
        RestartGame();
        lifeNum = 3;

        hitParticles.Stop();


    }
	
	// Update is called once per frame
	public virtual void Update () {

        if (lifeNum == 0)
            transform.position = iniPos.position;
        else
        {
            transform.position += ball_xSpeed * ball_xMov * Time.deltaTime;
            transform.position += ball_ySpeed * ball_yMov * Time.deltaTime;

        }

        controllerLifes(lifeNum);
        updateText();



        if(ball_xMov == new Vector3(-1, 0, 0))
        {
            UpdateLeftPan();

        }
        else
        {
            UpdateRightPan();
        }

        if (ball_yMov == new Vector3(0,1,0))
        {
            UpdatePitchTop();
        }
        else
        {
            UpdatePitchBottom();
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
        moveSource.pitch = 1 - dist/40;
    }
    void UpdateLeftPan()
    {
        moveSource.panStereo -= 0.25f * Time.deltaTime;
        //moveSource.pitch += 0.02f * Time.deltaTime;

        Vector2 dir = player.transform.position - transform.position;
        float dist = dir.magnitude;
        moveSource.pitch += 2*dist;
        
        
        
        //moveSource.volume += 0.08f * Time.deltaTime;
    }
    void UpdateRightPan()
    {
        moveSource.panStereo += 0.2f * Time.deltaTime;
        moveSource.pitch-= 0.02f * Time.deltaTime;
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "TopCorner")
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

        if (collision.gameObject.tag == "DeadZone")
        {
            loseHpSource.Play();
            AnimationClip clip = anim.GetClip("Ball_Idle");
            anim.Play(clip.name);
            gc.RestartGame();
            //hitParticles.transform.position = transform.position;
            //hitParticles.Play();
        }

        if(collision.gameObject.tag == "Player")
        {
            //hitParticles.transform.position = transform.position;
            //hitParticles.Play();
            AnimationClip clip = anim.GetClip("Ball_Idle");
            anim.Play(clip.name);
            scorePointSource.Play();
            points += 1;
            gc.PlayerScores();

            //sum points
        }
    }

    public virtual void RestartGame()
    {
        GiveRandomSpeed();
        transform.position = iniPos.position;
        anim.Play();
        moveSource.panStereo = 0.0f;
        moveSource.pitch = 1f;
    }

    private void updateText()
    {
        textPoint.text = "" + points;
    }

    private void controllerLifes(float lifeNum)
    {
        if (lifeNum == 2)
        {
            life3.enabled = false;
        }
        if (lifeNum == 1)
        {
            life2.enabled = false;
        }
        if (lifeNum == 0)
        {
            life1.enabled = false;

            //ResetGame or Menu
        }
    }

    private void GiveRandomSpeed()
    {
        ball_xMov = new Vector3(-1, 0, 0);
        ball_yMov = new Vector3(0, -1, 0);


        float rnd = Random.Range(0, 2);

        if (rnd == 0)
        {
            ball_yMov = new Vector3(0, -1, 0);
        }
        else
        {
            ball_yMov = new Vector3(0, 1, 0);
        }

        ball_xSpeed = Random.Range(minBallXSpeed / 2, maxBallXSpeed / 2);
        ball_ySpeed = Random.Range(minBallYSpeed / 2, maxBallYSpeed / 2);
    }
}
