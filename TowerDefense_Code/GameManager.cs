using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;


    public Canvas InfoCanvas;
    public Text goldtext;
    public int gold;
    public Text Points;
    public int lives;

    public Image lives3;
    public Image lives2;
    public Image lives1;

    public int score;

    public AudioSource source;

    Animation animation;

    public Button metraButton;
    public Button cañonButton;


    // Use this for initialization
    void Start () {
        lives = 3;

        AddMoney(150);
        AddScore(0);

        animation = GetComponent<Animation>();
        //if (SceneManager.GetSceneByBuildIndex(1) == SceneManager.GetActiveScene())
        //{
        //    DontDestroyOnLoad(InfoCanvas);
        //}
    }
    void Awake()
    {

        if (instance == null)
            instance = this;
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update () {
        ButtonTransparency();

        if (gold <= 0)
        {
            gold = 0;
        }
    }


    private void ButtonTransparency()
    {
        if (gold < Turret.metracost)
        {
            Color c = metraButton.image.color;
            c.a = 0.5f;
            metraButton.image.color = c;
        }
        else
        {
            Color c = metraButton.image.color;
            c.a = 1f;
            metraButton.image.color = c;
        }
        if (gold < Turret.cañoncost)
        {
            Color c = cañonButton.image.color;
            c.a = 0.5f;
            cañonButton.image.color = c;
        }
        else
        {
            Color c = cañonButton.image.color;
            c.a = 1f;
            cañonButton.image.color = c;
        }


    }

    public void playAnimation()
    {
        animation.Play();
    }

    public void Win()
    {
        SceneManager.LoadScene(1);

    }
    public void WaitStart()

    {
        StartCoroutine(WinSound(source.clip.length));
    }

    IEnumerator WinSound(float delay)
    {


        source.PlayOneShot(source.clip);    

        yield return new WaitForSeconds(delay);

        //WaveSpawner.SpawnState = WaveSpawner.SpawnState.waiting;

        Win();
        
    }




    public void AddScore(int points)
    {
        score += points;
        Points.text = score.ToString();
    }
    public void AddMoney(int money)
    {
        gold += money;
        goldtext.text = gold.ToString();
    }

    public void UpdateLives()
    {
        Debug.Log("Updated");
        Debug.Log(lives);
        lives -= 1;

        if (lives == 2)
        {

            Destroy(lives2.gameObject);

        }
        else if (lives == 1)
        {
            Destroy(lives1.gameObject);

        }
        else if (lives == 0)
        {
            loose();
        }
    }

    void loose ()
    {

        SceneManager.LoadScene(0);

    }

}
