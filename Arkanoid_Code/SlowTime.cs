using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlowTime : MonoBehaviour {

    // Use this for initialization
    public GameObject slowcanvas;
    public Text slowtext;
    private float round;

    void Start () {
        DontDestroyOnLoad(slowcanvas);
	}
	
	// Update is called once per frame
	void Update () {
        round = Mathf.Round(Ball.slowtimer);
        
        slowtext.text = round.ToString();

        
	}
}
