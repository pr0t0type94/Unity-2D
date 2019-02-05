using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController2Players : MonoBehaviour
{

    // Use this for initialization
    public Player1 player;
    public GameObject Player1Paddle;
    public Ball2Players ball;
    public GameObject ballOBJ;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Restart()
    {
        Time.timeScale = 0.0f;

        yield return new WaitForSecondsRealtime(0.5f);

        ball.RestartGame();

        yield return new WaitForSecondsRealtime(2.0f);

        //ball = newBall.GetComponent<Ball>();
        Time.timeScale = 1.0f;

    }

    public void RestartGame()
    {
        StartCoroutine(Restart());
    }
}