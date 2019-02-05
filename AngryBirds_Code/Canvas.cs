using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour {

    // Use this for initialization
    public GUIText GameOver;
    public Text points;
    public Text WinText;
    public Text BirdsRemaining;
    public string activestate;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var counter = GameObject.FindGameObjectsWithTag("Brick");
        if (counter.Length <= 0)
        {
            Win();
        }
    }

    void Win()
    {
        WinText.IsActive();
        WinText.text = "GREAT!! PRESS ENTER TO LOAD NEXT LEVEL";
        //StartCoroutine(ExecuteAfterTime(5));
        //activestate = "win";

        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
        activestate = "playing";

    }
    void Over()
    {

    }
}
