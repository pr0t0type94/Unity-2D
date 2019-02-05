using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour {


    // Use this for initialization
    public GameObject selection;
    public Collider coll;
    public Grid grid;
    void Start () {
        coll = GetComponent<Collider>();
        grid = GetComponentInParent<Grid>();
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (coll.Raycast(ray, out hitInfo, Mathf.Infinity))
        {
            int x = Mathf.FloorToInt(hitInfo.point.x / grid.node_size);
            int y = Mathf.FloorToInt(hitInfo.point.y / grid.node_size);

            selection.transform.position = new Vector2(x, y);
        }
    }
}
