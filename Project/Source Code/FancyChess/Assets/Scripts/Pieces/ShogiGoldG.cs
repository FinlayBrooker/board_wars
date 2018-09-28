using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShogiGoldG : Piece {

    public override Piece Init()
    {
        worth = 3;
        title = "S.Gold General";
        number = 12;
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
        worth = 3;
        title = "S.Gold General";
        number = 12;
        movement();
        take();
    }



    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        if (isWhite)
        {
            movementPattern.AddRange(moveF(1, false));
            movementPattern.AddRange(moveDLF(1, false));
            movementPattern.AddRange(moveDRF(1, false));
            movementPattern.AddRange(moveL(1, false));
            movementPattern.AddRange(moveR(1, false));
            movementPattern.AddRange(moveB(1, false));
        }
        else
        {
            movementPattern.AddRange(moveB(1, false));
            movementPattern.AddRange(moveL(1, false));
            movementPattern.AddRange(moveR(1, false));
            movementPattern.AddRange(moveDLB(1, false));
            movementPattern.AddRange(moveDRB(1, false));
            movementPattern.AddRange(moveF(1, false));
        }
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPath.Clear();
        if (isWhite)
        {
            attackPattern.AddRange(moveF(1, true));
            attackPattern.AddRange(moveDLF(1, true));
            attackPattern.AddRange(moveDRF(1, true));
            attackPattern.AddRange(moveL(1, true));
            attackPattern.AddRange(moveR(1, true));
            attackPattern.AddRange(moveB(1, true));

            attackPath.AddRange(moveF(1, false));
            attackPath.AddRange(moveDLF(1, false));
            attackPath.AddRange(moveDRF(1, false));
            attackPath.AddRange(moveL(1, false));
            attackPath.AddRange(moveR(1, false));
            attackPath.AddRange(moveB(1, false));
        }
        else
        {
            attackPattern.AddRange(moveB(1, true));
            attackPattern.AddRange(moveL(1, true));
            attackPattern.AddRange(moveR(1, true));
            attackPattern.AddRange(moveDLB(1, true));
            attackPattern.AddRange(moveDRB(1, true));
            attackPattern.AddRange(moveF(1, true));

            attackPath.AddRange(moveB(1, false));
            attackPath.AddRange(moveL(1, false));
            attackPath.AddRange(moveR(1, false));
            attackPath.AddRange(moveDLB(1, false));
            attackPath.AddRange(moveDRB(1, false));
            attackPath.AddRange(moveF(1, false));
        }
        getProtecteds();
        return attackPattern;
    }
}
