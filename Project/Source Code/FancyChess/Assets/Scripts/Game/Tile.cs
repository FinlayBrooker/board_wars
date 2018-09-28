using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public Vector2 position = new Vector2();
    public bool occupied = false;
    public Piece occupiedBy;
    //public char[] coords = new char[2];
    public Coordinates coords;
    public bool selected = false;
    public bool promotionTile = false;
    public bool whiteProTile = false;
    public bool threatened;
    public bool canMove;
    public bool canTake;
    public bool canRange;
    public Color baseColour;
    public Color colour;
    public Color moveColour = Color.green;
    public Color takeColour = Color.red;
    public Color rangeColour = Color.red;
    public Color selectColour = Color.yellow;
    public Color hoverColour = Color.blue;

    public Tile() { }
    
    //deep copy
    public Tile(Tile copy)
    {
        position = copy.position;
        occupied = copy.occupied;
        if (copy.occupied)
        {
            occupiedBy = new Piece(copy.occupiedBy);
        }
        else
        {
            occupiedBy = null;
        }
        //public char[] coords = new char[2];
        coords = copy.coords;
        selected = copy.selected;
        promotionTile = copy.promotionTile;
        whiteProTile = copy.whiteProTile;
        threatened = copy.threatened;
        canMove = copy.canMove;
        canTake = copy.canTake;
        canRange = copy.canRange;
        baseColour = copy.baseColour;
        colour = copy.colour;
}

	// Use this for initialization
	void Start () {
        colour = baseColour;
        GetComponent<Renderer>().material.color = colour;
        
    }
	
	// Update is called once per frame
	void Update () {
        //getAbove();
	}

    public void getAbove()
    {
        RaycastHit hit;
        Vector3 above = transform.TransformDirection(Vector3.up);
        //Debug.DrawRay(transform.position,above);
        if (Physics.Raycast(transform.position, above, out hit,10.0f))
        {
            occupied = true;
            occupiedBy = hit.transform.gameObject.GetComponent<Piece>();
            occupiedBy.on = this;
            occupiedBy.position = position;
            //Debug.Log("Hello");
        }
        else
        {
            occupied = false;
            occupiedBy = null;
            //Debug.Log("Nope");
        }
    }

    void changeColour(Color c)
    {
        GetComponent<Renderer>().material.color = Color.Lerp(baseColour, c, 0.5f);
    }

    

    public void select()
    {
        if(selected)
        {
            changeColour(selectColour);
        }
        else if (canMove)
        {
            changeColour(moveColour);
        }
        else if (canTake)
        {
            changeColour(takeColour);
        }
        else if (canRange)
        {
            changeColour(rangeColour);
        }
        else
        {
            changeColour(colour);
        }
    }

    void OnMouseEnter()
    {
        colour = hoverColour;
        //Debug.Log("My coords are " + coords.x + " " + coords.y);
        select();
    }
    void OnMouseExit()
    {
        if(colour == hoverColour)
        {
            colour = baseColour;
            select();
        }
        
    }

    void OnMouseDown()
    {
        /*GameLogic.instance.handleTileClick(this);
        Debug.Log("Clicked");
        Debug.Log("Tile" + this);
        Debug.Log("Piece" + occupiedBy);
        if (canTake)
        {
            GameLogic.instance.takePiece(occupiedBy);
        }
        else if (canMove)
        {
            
        }
        else if (selected)
        {
            selected = false;
            occupiedBy.selected = false;
            select();
        }
        else if(occupied == true)
        {
            GameLogic.instance.changeSelected(this, occupiedBy);
            select();
        }*/
        GameLogic.instance.handleTileClick(this);
    }

    void OnMouseOff() { }
}
