using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {


    public KeyCode player2UpCode;
    public KeyCode player2DownCode;

    private bool canMoveUp = true;
    private bool canMoveDown = true;

    public float movSpeed = 1;
    private Vector3 direction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(player2UpCode) && canMoveUp)
        {
            direction = Vector3.up;

            transform.position += Vector3.up * movSpeed * Time.deltaTime;
        }

        if (Input.GetKey(player2DownCode) && canMoveDown)
        {
            direction = Vector3.down;

            transform.position += Vector3.down * movSpeed * Time.deltaTime;

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
