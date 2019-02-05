using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public AudioSource source;
    public GameObject prefab;
    public GameObject yelowprefab;
    public AudioClip WinAudio;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText scoreText;
    public GUIText wintext;
    public GUIText maxbirds;
    public Vector2 iniposicion;
    private bool gameOver;
    private bool restart;
    private bool win;
    private bool loadnextlevel;
    private int score;
    private int MaxBirds;
    private int currbirds;
    bool created;
    public int numbirds;
    public GameObject tirach;
    // Use this for initialization
    void Start () {
        gameOver = false;
        restart = false;
        win = false;
        loadnextlevel = false;
        restartText.text = "";
        gameOverText.text = "";
        wintext.text = "";
        score = 0;
        MaxBirds =4;
        currbirds = MaxBirds;
        UpdateScore();
        numbirds = 0;
    }
	
	// Update is called once per frame
	void Update () {
        //if (restart)
        //{
        //    if (Input.GetKeyDown(KeyCode.R))
        //    {
        //        SceneManager.LoadScene(0);
        //    }
        //}
        var pajaro = GameObject.FindGameObjectWithTag("pajaro");
        var yelow = GameObject.FindGameObjectWithTag("yelow");
        if (numbirds==0)
        {
            CreateBird();
        }
       
        var counter = GameObject.FindGameObjectsWithTag("Cerdo");
        if (counter.Length <= 0)
        {
            Win();
        }

        if (currbirds==0)
        {
            GameOver();
        }

        maxbirds.text = "Remaining Birds: "+ currbirds.ToString();
        
        if (gameOver)
        {
            gameOverText.text = "Game Over!";
            restartText.text = "Press 'R' for Restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }

        if (win)
        {

            
            source.Play();


            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(1);
            }
        }   
    }
    public void CreateBird()
    {
        
            if (currbirds >= 3)
            {
                Instantiate(prefab, tirach.transform.position, Quaternion.identity);
            }
            if (currbirds <= 2)
            {
                Instantiate(yelowprefab, tirach.transform.position, Quaternion.identity);

            }
            numbirds = 1;
        
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void  UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void UpdateMaxBirds()
    {

        currbirds -= 1;
        
    }
    public void GameOver()
    {
        gameOver = true;
    }

    public void Win()
    {
        wintext.text = "Win!! Press Enter to load next level";
        win = true;
    }

}

