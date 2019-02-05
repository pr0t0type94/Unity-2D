using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public Player1 player;
    public GameObject Player1Paddle;
    public Ball ball;
    public GameObject ballOBJ;

    public Canvas restartCanvas;
    private void Awake()
    {
        restartCanvas.gameObject.SetActive(false);
        
    }
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(ball.lifeNum==0)
        {
            restartCanvas.gameObject.SetActive(true);

        }
    }

    IEnumerator Restart()
    {
        Time.timeScale = 0.0f;

        //GameObject newBall = Instantiate(ballOBJ,ball.iniPos.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(0.5f);

        ball.RestartGame();

        yield return new WaitForSecondsRealtime(2.0f);

        //ball = newBall.GetComponent<Ball>();
        Time.timeScale = 1.0f;

    }

    public void RestartGame()
    {
        StartCoroutine(Restart());
        ball.lifeNum--;
    }
    public void PlayerScores()
    {
        StartCoroutine(Restart());
    }

    public void ResetGame()
    {
        Time.timeScale = 0.0f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);

    }
}
