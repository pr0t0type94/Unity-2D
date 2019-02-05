﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {

    // Use this for initialization
    public KeyCode player1UpCode;
    public KeyCode player1DownCode;

    private bool canMoveUp = true;
    private bool canMoveDown = true;

    public float movSpeed = 1;
    private Vector3 direction;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(player1UpCode) && canMoveUp)
        {
            direction = Vector3.up;
            transform.position += direction * movSpeed * Time.deltaTime;
        }

        if (Input.GetKey(player1DownCode) && canMoveDown)
        {
            direction = Vector3.down;
            transform.position += direction * movSpeed * Time.deltaTime;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TopCorner")
        {
            canMoveUp = false;
            canMoveDown = true;
        }

        if (collision.gameObject.tag == "DownCorner")
        {
            canMoveUp = true;
            canMoveDown = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "TopCorner")
        {
            canMoveUp = true;

        }

        if (collision.gameObject.tag == "DownCorner")
        {

            canMoveDown = true;
        }
    }


}
