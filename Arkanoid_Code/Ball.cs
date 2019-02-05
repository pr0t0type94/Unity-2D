using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Ball : MonoBehaviour {

    public static float slowtimer=30.0f;
    public static float inispeed = 5f;
    public static float speed;
    public GameObject myBall;
    public string[] states = new string[] { };
    public static string activestate;
    public string state;
    public string ballstate;

    public static Vector3 ForwardVec = new Vector3(0,1,0);
    public Vector2 CorrectionBall = new Vector2(0,-0.1f);
    
    public GameObject myBar;
    public GameObject derbar;
    public GameObject izbar;
    public GameObject top;
    public GameObject deadzon;
    public GameObject overcanvas;
    public GameObject canvas;

    SpriteRenderer techo;
    SpriteRenderer parediz;
    SpriteRenderer pareder;
    SpriteRenderer ball1;
    SpriteRenderer barra;
    SpriteRenderer deadzone;

    public static int score;
    public int lives;
    public Text scor;
    public Text points;
    public Text livs;
    public Text Over;
    
    /// 
    public AudioClip rebote;
    public AudioClip life;
    private AudioSource source;

    float barraiz;
    float barrader;
    public int x;
    public Scene scene;

    public static bool slowball;
    public bool slowcheck;
    public static bool gover;
    /// 
    /// <param name="barra"></param>
    /// <param name="bola"></param>
    /// <returns></returns>
    /// 
    float hit(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
      
        return (ballPos.x - racketPos.x) / racketWidth;
    }


    void SetText(Text type)
    {
        if (type == scor)
        {
            type.text = "SCORE:";
               
        }
        if (type == livs)
        {
            type.text = "LIVES: " + lives.ToString();

        }
        if (type== points)
        {
            type.text= score.ToString();
        }

        if (type== Over)
        {
           type.text= "YOU LOOSE!! PRESS ENTER TO RESTART GAME";
        }
    }


    public void ResetPosition()
    {
        ForwardVec = new Vector3(0, 1, 0);
        //myBall.transform.position = new Vector3(3.09f,0.75f,0);
        myBar.transform.position = new Vector3(3.09f, 0.0f, 0);
        activestate = "playing";
        ballstate = "idle";
        //ChangeState();
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }
    }

    void GameOver()
    {
        overcanvas.SetActive(true);
        activestate = "gameover";
        if (Over.IsActive())
        {
            SetText(Over);
        }
       
    }
    // Use this for initialization
    void Start()
        {
        
            DontDestroyOnLoad(canvas);
        

        speed = inispeed;

        activestate = "playing";
        ballstate = "idle";

        techo = top.GetComponent<SpriteRenderer>();
        ball1 = myBall.GetComponent<SpriteRenderer>();
        barra = myBar.GetComponent<SpriteRenderer>();
        parediz = izbar.GetComponent<SpriteRenderer>();
        pareder = derbar.GetComponent<SpriteRenderer>();
        deadzone = deadzon.GetComponent<SpriteRenderer>();

        score = 000;
        lives = 3;

        source = GetComponent<AudioSource>();

        scene = SceneManager.GetActiveScene();

        overcanvas.SetActive(false);

    }


    // Update is called once per frame
    void Update () {
        state = activestate;
        slowcheck = slowball;

        if(scene.buildIndex==0)
        {
            SetText(scor);
            SetText(points);
            SetText(livs);
        }
       

        if(activestate=="waiting")
        {
            ResetPosition();
        }

        if (activestate == "playing")
        {

            if (Input.GetKey(KeyCode.Space))
            {
                ballstate = "moving";
            }

            if (ballstate != "moving")
            {
                myBall.transform.position = myBar.transform.position + new Vector3(0, +0.35f, 0);
            }
            else
            {
                myBall.transform.Translate(ForwardVec * speed * Time.deltaTime);

            }

            ///////////

          
            x = (int)hit(myBall.transform.position, myBar.transform.position, barra.size.x);

            if (ballstate != "idle")
            {
                if (myBall.transform.position.y <= (myBar.transform.position.y + barra.size.y) / barra.size.x)
                {
                    if ((myBall.transform.position.x  < barra.bounds.max.x) && (myBall.transform.position.x > barra.bounds.min.x))
                    {
                        ForwardVec = new Vector2(x, -ForwardVec.y);
                        source.PlayOneShot(rebote, 2);

                    }

                }
            }

            if (ball1.bounds.max.y > techo.bounds.min.y - ball1.size.x / 2)
            {
                ForwardVec.y = -ForwardVec.y;
                source.PlayOneShot(rebote, 2);

            }

            if (ball1.bounds.max.x > pareder.bounds.min.x - ball1.size.x/2)
            {
                ForwardVec.x = -ForwardVec.x;
                source.PlayOneShot(rebote, 2);

            }

            if (ball1.bounds.min.x < parediz.bounds.max.x + ball1.size.x / 2)
            {
                ForwardVec.x = -ForwardVec.x;
                source.PlayOneShot(rebote, 2);

            }

            if (ball1.bounds.min.y <= deadzone.bounds.max.y)
            {
                source.PlayOneShot(life,0.8f);
                lives -= 1;
                SetText(livs);
                ResetPosition();
                activestate = "waiting";
            }
       

            if(slowball)
            {
                speed = inispeed / 2.0f;

                slowtimer -= Time.deltaTime;
                if (slowtimer <=0)
                {
                    slowball = false;
                }
            }
            else
            {
                speed = inispeed ;
                slowtimer = 30.0f;
            }


            if (lives==0)
            {
                GameOver();
            }

        }

        if (activestate=="gameover")
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
