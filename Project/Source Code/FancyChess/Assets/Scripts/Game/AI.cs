using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public int counter = 0;
    public int pieceMod = 1, moveMod = 1, attackMod = 1, rangeMod = 1, threatMod = 1, rangethreatMod = 1, protectMod = 1;
    public List<Piece> pieces;
    public List<Piece> takenPieces;
    //public Dictionary<Piece,int> takenPiecesDict;
    public List<int> numberCaptured;
    public bool isWhite;


    public int evaluateBoard(List<List<Tile>> board)
    {
        // variable for return
        int value = 0;
        int whiteBlack;

        // create list of all pieces on the board
        List<Piece> units = new List<Piece>();
        foreach (List<Tile> row in board)
        {
            foreach (Tile tile in row)
            {
                if (tile.occupied)
                {
                    units.Add(tile.occupiedBy);
                }
            }
        }
        //int k = 0;
        foreach (Piece unit in units)
        {
            unit.updateMoves();
        }
        //debug.log(k);
        //Debug.Log(units.Count);
        //Debug.Log(units[0].isWhite);
        foreach (Piece unit in units)
        {
            if (unit.isWhite) { whiteBlack = 1; }
            else { whiteBlack = -1; }
            // give points for having a piece
            value += whiteBlack * (pieceMod * unit.value);
            // give points for the amount of movement piece has
            value += whiteBlack * (moveMod * unit.movementPattern.Count);

            // give points for how many pieces a piece can attack
            value += whiteBlack * (attackMod * 4 * unit.attackPattern.Count);
            // give points for what pieces can be attacked
            foreach (Vector2 item in unit.attackPattern)
            {
                if (board[Mathf.FloorToInt(item.x)][Mathf.FloorToInt(item.y)].occupied)
                {
                    if (board[Mathf.FloorToInt(item.x)][Mathf.FloorToInt(item.y)].occupiedBy.title.Contains("King"))
                    {
                        Debug.Log("We got to the king bit");
                        value += whiteBlack * attackMod * 1600000 * board[Mathf.FloorToInt(item.x)][Mathf.FloorToInt(item.y)].occupiedBy.value;
                    }
                    else
                    {
                        value += whiteBlack * attackMod * 8 * board[Mathf.FloorToInt(item.x)][Mathf.FloorToInt(item.y)].occupiedBy.value;
                    }
                }
            }
            // give points for how many pieces a piece can range
            value += whiteBlack * (rangeMod * 5 * unit.rangePattern.Count);
            // give points for what pieces can be ranged
            foreach (Vector2 item in unit.rangePattern)
            {
                if (board[Mathf.FloorToInt(item.x)][Mathf.FloorToInt(item.y)].occupied)
                {
                    if (board[Mathf.FloorToInt(item.x)][Mathf.FloorToInt(item.y)].occupiedBy.title.Contains("King"))
                    {
                        value += whiteBlack * rangeMod * 2000000 * board[Mathf.FloorToInt(item.x)][Mathf.FloorToInt(item.y)].occupiedBy.value;
                    }
                    else
                    {
                        value += whiteBlack * rangeMod * 10 * board[Mathf.FloorToInt(item.x)][Mathf.FloorToInt(item.y)].occupiedBy.value;
                    }
                }
            }
            //give points for how many squares a piece threatens
            value += whiteBlack * (threatMod * 4 * unit.attackPath.Count);
            value += whiteBlack * (rangethreatMod * 6 * unit.rangePath.Count);
            // five points for how many pieces a piece is protecting
            value += whiteBlack * (protectMod * 8 * unit.protectPattern.Count);
            // give points for what pieces are protected
            foreach (Vector2 item in unit.protectPattern)
            {
                if (board[Mathf.FloorToInt(item.x)][Mathf.FloorToInt(item.y)].occupied)
                {
                      value += whiteBlack * protectMod * 4 * board[Mathf.FloorToInt(item.x)][Mathf.FloorToInt(item.y)].occupiedBy.value;
                }
            }
        }

        return value;
    }

    public virtual void doMove()
    {
        counter = 0;
        return;
    }

}
