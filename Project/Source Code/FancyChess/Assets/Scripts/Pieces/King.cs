using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece {

    public override Piece Init()
    {
        worth = 10;
        title = "King";
        number = 5;
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
        worth = 10;
        number = 5;
        title = "King";
        movement();
        take();
    }
	

    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        movementPattern.AddRange(moveF(1, false));
        movementPattern.AddRange(moveB(1, false));
        movementPattern.AddRange(moveL(1, false));
        movementPattern.AddRange(moveR(1, false));
        movementPattern.AddRange(moveDLF(1, false));
        movementPattern.AddRange(moveDLB(1, false));
        movementPattern.AddRange(moveDRF(1, false));
        movementPattern.AddRange(moveDRB(1, false));
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPattern.AddRange(moveF(1, true));
        attackPattern.AddRange(moveB(1, true));
        attackPattern.AddRange(moveL(1, true));
        attackPattern.AddRange(moveR(1, true));
        attackPattern.AddRange(moveDLF(1, true));
        attackPattern.AddRange(moveDLB(1, true));
        attackPattern.AddRange(moveDRF(1, true));
        attackPattern.AddRange(moveDRB(1, true));
        attackPath.Clear();
        attackPath.AddRange(moveF(1, false));
        attackPath.AddRange(moveB(1, false));
        attackPath.AddRange(moveL(1, false));
        attackPath.AddRange(moveR(1, false));
        attackPath.AddRange(moveDLF(1, false));
        attackPath.AddRange(moveDLB(1, false));
        attackPath.AddRange(moveDRF(1, false));
        attackPath.AddRange(moveDRB(1, false));
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
            List<Rook> rs = new List<Rook>();
            foreach (Piece item in p.pieces)
            {
                if(item.title == "Rook" && item.noMoves == 0)
                {
                    rs.Add((Rook)item);
                }
            }
            if (rs.Count != 0)
            {
                foreach (Rook item in rs)
                {
                    
                }
                
            }
        }
        return false;
    }
}
