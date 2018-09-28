using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Description : MonoBehaviour {

    public string description;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeDescription(int p)
    {
        switch (p)
        {
            case 0:
                description = "The Pawn is a piece from the game of Chess. It can move one square forwards or 2 on its first move, it can take a piece diagonally forwards to the left or right. The Pawn can promote to a Knight, Bishop, Rook or Queen";
                break;
            case 1:
                description = "The Knight is a piece from the game of Chess. It moves by jumping meaning it doesn't need a clear path to its destination it can jump 2 x 1 squares in any direction. The Knight cannot promote";
                break;
            case 2:
                description = "The Bishop is a piece from the game of Chess. It can move diagonally in any direction as far as possible. The Bishop cannot promote";
                break;
            case 3:
                description = "The Rook is a piece from the game of Chess. It can move orthoganally in any direction as far as possible. The Rook cannot promote";
                break;
            case 4:
                description = "The Queen is a piece from the game of Chess. It can move orthogonally and diagonally in any direction as far as possible. The Queen cannot promote";
                break;
            case 5:
                description = "The King is a piece from the game of Chess. It can move orthogonally and diagonally one square in any direction. The King is the most important piece in the game if it is captured by your opponent the game is over. The King cannot promote";
                break;
            case 6:
                description = "The Shogi Pawn is a piece from the game of Shogi. It can move forwards one square at a time. The Shogi Pawn can promote to a Shogi Gold General";
                break;
            case 7:
                description = "The Shogi Lancer is a piece from the game of Shogi. It can move forwards as far as possible. The Shogi Lancer can promote to a Shogi Gold General";
                break;
            case 8:
                description = "The Shogi Knight is a piece from the game of Shogi. It moves by jumping it can jump to a square 2 squares forward and 1 square to the left and right. The Shogi Knight can promote to a Shogi Gold General";
                break;
            case 9:
                description = "The Shogi Bishop is a piece from the game of Shogi. It can move diagonally in any direction as far as possible. The Shogi Bishop can promote to a Shogi Dragon Bishop";
                break;
            case 10:
                description = "The Shogi Rook is a piece from the game of Shogi. It can move orthogonally in any direction as far as possible. The Shogi Rook can promote to a Shogi Dragon Rook";
                break;
            case 11:
                description = "The Shogi Silver General is a piece from the game of Shogi. It can move one square forward or diagonally in any direction. The Shogi Silver General can promote to a Shogi Gold General or not promote";
                break;
            case 12:
                description = "The Shogi Gold General is a piece from the game of Shogi. It can move one square orthogonally in any direction or diagonally forward left or right. The Shogi Gold General cannot promote";
                break;
            case 13:
                description = "The Shogi King is a piece from the game of Shogi. It can move orthogonally and diagonally one square in any direction. The Shogi King is equivalent to a Chess King. The Shogi King cannot promote";
                break;
            case 14:
                description = "The Archer is a piece from this game. It can move one square forwards. It cannot take by moving it can take a piece 2 squares infront of it without moving this is known as a ranged take. The Archer can promote to a CrossBowMan, Ninja or Paladin";
                break;
            case 15:
                description = "The CrossBowMan is a piece from this game. It can move orthogonally and diagonally one square in any direction. It cannot take by moving it can range take a piece any distance away orthogonally in any direction. The CrossBowMan cannot promote";
                break;
            case 16:
                description = "The Ninja is a piece from this game. It can jump 2 squares orthogonally and diagonally in any direction. It can range take a piece 2 x 1 squares in any direction. The Ninja cannot promote";
                break;
            case 17:
                description = "The Paladin is a piece from this game. It can jump 2 x 1 squares in any direction. It can range take a piece 2 squares orthogonally and diagonally in any direction. The Paladin cannot promote";
                break;
            case 18:
                description = "The Wizard is a piece from this game. It can move orthogonally and diagonally one square in any direction. It cannot take by moving it can range take a piece any distance away orthogonally or diagonally in any direction. The Wizard cannot promote";
                break;
            case 19:
                description = "The Shogi Dragon Bishop is a piece from the game of Shogi. It can move diagonally in any direction as far as possible or 1 square orthogonally in any direction. The Shogi Dragon Bishop cannot promote";
                break;
            case 20:
                description = "The Shogi Dragon Rook is a piece from the game of Shogi. It can move orthogonally in any direction as far as possible or 1 square diagonally in any direction. The Shogi Dragon Rook cannot promote";
                break;
            default:
                break;
        }

        GetComponent<Text>().text = description;
    }
}
