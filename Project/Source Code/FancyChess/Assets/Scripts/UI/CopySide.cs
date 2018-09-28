using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopySide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void copySide(bool white)
    {
        List<GeneratedTile> toCopy = new List<GeneratedTile>();
        foreach (List<GeneratedTile> item in GenerateGame.instance.board)
        {

            if(item.Count != 0 && item[0].isWhite == white)
            {
                toCopy.AddRange(item);
            }
        }
        
        int row = 0;
        foreach (GeneratedTile item in toCopy)
        {
            if (white)
            {
                row = GenerateGame.instance.boardSize - (int)item.pos.x -1;
            }
            else
            {
                row = Mathf.Abs((int)item.pos.x - GenerateGame.instance.boardSize) -1;
            }
            //Debug.Log(row);
            if (GenerateGame.instance.board[row][Mathf.FloorToInt(item.pos.y)].occupied)
            {
                RemovePiece.removePiece(GenerateGame.instance.board[row][Mathf.FloorToInt(item.pos.y)].occupiedBy);
            }
            if (item.occupied)
            {
                PlacePiece.placePiece(item.occupiedBy, GenerateGame.instance.board[row][Mathf.FloorToInt(item.pos.y)]);
            }

        }
    }
}
