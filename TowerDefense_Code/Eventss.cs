using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Eventss : MonoBehaviour {

    Event UnityEvent;
    // Use this for initialization

    public class myEventControlParameters : UnityEvent<int>
    {

    }

    private int Manel ()
    {
        return 1;
    }

    private int numero;
    private myEventControlParameters myEvent;

    void Start() {
        myEvent = new myEventControlParameters();
        //PlayerPrefs.SetInt("score",score);
        //PlayerPrefs.GetInt("score", score);
        //myEvent.AddListener(Manel);
    }

    // Update is called once per frame
    void Update() {

    }

    
}
