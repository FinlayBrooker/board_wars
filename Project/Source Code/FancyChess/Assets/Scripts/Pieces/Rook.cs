using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Piece {

    public override Piece Init()
    {
        worth = 5;
        title = "Rook";
        number = 3;
        return this;
    }

    // Use this for initialization
    new void Start()
    {
        if (base.Start())
        {
            return;
        }
        setupPiece();
        worth = 5;
        number = 3;
        title = "Rook";
        movement();
        take();
    }
	

    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        movementPattern.AddRange(moveF(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveB(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveL(GameLogic.instance.boardSize, false));
        movementPattern.AddRange(moveR(GameLogic.instance.boardSize, false));
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPattern.AddRange(moveF(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveB(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveL(GameLogic.instance.boardSize, true));
        attackPattern.AddRange(moveR(GameLogic.instance.boardSize, true));

        attackPath.Clear();
        attackPath.AddRange(moveF(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveB(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveL(GameLogic.instance.boardSize, false));
        attackPath.AddRange(moveR(GameLogic.instance.boardSize, false));
        getProtecteds();
        return attackPattern;
    }

    public override bool checkAbility()
    {
        if(noMoves == 0)
        {
            Player p;
            if (isWhite)
            {
                p = GameLogic.instance.one;
            }
            else
            {
                p = GameLogic.instance.two;
            }
            King k = null;
            foreach (Piece item in p.pieces)
            {
                if (item.title == "King" && item.noMoves == 0)
                {
                    k = (King)item;
                }
            }
            RaycastHit hit;
            if (Physics.Raycast(k.transform.position, transform.position, out hit))
            {
                if (hit.transform.gameObject == this)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
