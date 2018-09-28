using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public List<Piece> pieces;
    public List<Piece> takenPieces;
    //public Dictionary<Piece, int> takenPiecesDict;
    public Piece king;
    public List<Vector2> controlZones;
    public List<Vector2> moveZones;
    public int points;
    public bool isWhite;
    public Vector3 cam = new Vector3();
    public Quaternion camQ = new Quaternion();
    public List<int> numberCaptured;
    public bool user = true;
    public AI ai;
    public int counter = 0;
    

    // Use this for initialization
    void Start () {
        cam = GameLogic.instance.centerPoint;
        if (isWhite)
        {
            camQ = Quaternion.Euler(90, 0, 0);
        }
        else
        {
            camQ = Quaternion.Euler(90, 0, 180);
        }
        foreach (Piece item in pieces)
        {
            if(item.title.Contains("King"))
            {
                king = item;
            }
        }
	}
	
    public void setup()
    {
        foreach (Piece item in pieces)
        {
            if (item.title.Contains("King"))
            {
                king = item;
            }
            else
            { 
                moveZones.AddRange(item.movement());
            }
            controlZones.AddRange(item.take());
            controlZones.AddRange(item.range());
            controlZones.AddRange(item.attackPath);
            controlZones.AddRange(item.rangePath);
        }
    }

    public List<Vector2> updateControlZones()
    {
        controlZones.Clear();
        foreach (Piece item in pieces)
        { 
            controlZones.AddRange(item.take());
            controlZones.AddRange(item.range());
            controlZones.AddRange(item.attackPath);
            controlZones.AddRange(item.rangePath);
        }
        return controlZones;
    }

	// Update is called once per frame
	void Update () {
		
	}

    //randomness
    public void takeTurn()
    {
        setupAI();
        ai.doMove();
        foreach (Piece item in pieces)
        {
            item.setBoard(GameLogic.instance.board);
        }
        foreach (Piece item in pieces)
        {
            item.setBoard(GameLogic.instance.board);
            item.movement();
            item.take();
            item.range();
        }
    }

    public void refreshPieces()
    {
        foreach (Piece item in pieces)
        {
            item.setBoard(GameLogic.instance.board);
            item.movement();
            item.take();
            item.range();
        }
    }

    public void setupAI()
    {
        ai.isWhite = isWhite;
        ai.pieces = pieces;
        ai.takenPieces = removeDupes(takenPieces);
        //ai.takenPiecesDict = takenPiecesDict;
        ai.numberCaptured = numberCaptured;
    }

    private List<Piece> removeDupes(List<Piece> orignial)
    {
        List<Piece> newList = new List<Piece>();
        bool add = true;
        foreach (Piece item in orignial)
        {
            foreach(Piece i in newList)
            {
                if(i.GetType() == item.GetType())
                {
                    add = false;
                    break;
                }
                else
                {
                    add = true;
                }
            }
            if (add)
            {
                newList.Add(item);
                add = false;
            }
        }
        return newList;
    }
}
