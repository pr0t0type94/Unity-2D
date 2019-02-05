using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    Vector2 iniposition;
    float speed = 2.0f;
    float maxdist = 0.2f;
    // Use this for initialization
    void Start()
    {
        Vector2 iniposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
        //Debug.Log("finalpos"+this.transform.position.y);
      //  Debug.Log("original"+iniposition.y);

        if (this.transform.position.y > iniposition.y + maxdist)
        {
            Destroy(this.gameObject);
        }
    }
}
