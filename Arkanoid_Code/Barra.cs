using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Barra : MonoBehaviour
{

    // Use this for initialization
    public Vector3 ForwardVector = new Vector3(1, 0, 0);
    public int speed = 5;
    private string activestate;

    public GameObject myBar;
    public GameObject derbar;
    public GameObject izbar;
    public GameObject wincanvas;

    SpriteRenderer ball1;
    SpriteRenderer parediz;
    SpriteRenderer pareder;
    SpriteRenderer barra;

    public Text WinText;


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }

    void Win()
    {
        wincanvas.SetActive(true);
        WinText.text = "GREAT!! PRESS ENTER TO LOAD NEXT LEVEL";
        //StartCoroutine(ExecuteAfterTime(5));
        //activestate = "win";

        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
        activestate = "playing";
        
    }



    void Start()
    {
        activestate = "idle";
        barra = myBar.GetComponent<SpriteRenderer>();
        parediz = izbar.GetComponent<SpriteRenderer>();
        pareder = derbar.GetComponent<SpriteRenderer>();

        wincanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        var counter = GameObject.FindGameObjectsWithTag("Brick");

        if (counter.Length <= 0)
        {
            Win();
        }

        if (Ball.activestate == "playing")
        {

            if (Input.GetKey(KeyCode.D) && !(barra.bounds.max.x > pareder.bounds.min.x))
            {

                myBar.transform.Translate(Vector3.right * speed * Time.deltaTime);

            }
            if (Input.GetKey(KeyCode.A) && !(barra.bounds.min.x < parediz.bounds.max.x))
            {
                myBar.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

        }



    }
}

