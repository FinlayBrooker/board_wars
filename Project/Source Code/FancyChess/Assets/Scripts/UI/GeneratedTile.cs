using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratedTile : MonoBehaviour {

    public Color baseColor;
    public bool occupied;
    public Piece occupiedBy;
    public Vector2 pos = new Vector2();
    public bool isWhite;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        getAbove();
	}

    void OnMouseEnter()
    {
        if (GenerateGame.instance.selected != this)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    void OnMouseExit()
    {
        if (GenerateGame.instance.selected != this)
        {
            GetComponent<Renderer>().material.color = baseColor;
        }
    }

    void getAbove()
    {
        RaycastHit hit;
        Vector3 above = transform.TransformDirection(Vector3.up);
        //Debug.DrawRay(transform.position,above);
        if (Physics.Raycast(transform.position, above, out hit, 10.0f))
        {
            occupied = true;
            occupiedBy = hit.transform.gameObject.GetComponent<Piece>();
            occupiedBy.position = pos;
            //occupiedBy.on = this;
            //Debug.Log("Hello");
        }
        else
        {
            occupied = false;
            occupiedBy = null;
            //Debug.Log("Nope");
        }
    }

    void OnMouseDown()
    {
        GenerateGame.instance.handleTileClick(this);
    }
}
