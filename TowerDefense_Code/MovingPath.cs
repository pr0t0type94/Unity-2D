using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPath : MonoBehaviour {

    public Color rayColor = Color.black;
    public List<Transform> path = new List<Transform>();
    Transform[] theArray;
    public float radius;

    private void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        path.Clear();

        foreach(Transform _path in theArray)
        {
            if(_path != this.transform)
            {
                path.Add(_path);
            }
        }

        for (int i= 0; i<path.Count; i++)
        {
            Vector3 pos = path[i].position;

            if (i > 0)
            {
                Vector3 prev = path[i - 1].position;
                Gizmos.DrawLine(prev, pos);
                Gizmos.DrawSphere(pos,radius);
            }
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
