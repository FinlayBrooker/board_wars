using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShogiKnight : Piece {

    public override Piece Init()
    {
        worth = 2;
        title = "S.Knight";
        number = 8;
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
        worth = 2;
        title = "S.Knight";
        number = 8;
        movement();
        take();
    }



    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        if (isWhite)
        {
            movementPattern.AddRange(jump(1, 2,false));
            movementPattern.AddRange(jump(-1, 2, false));
        }
        else
        {
            movementPattern.AddRange(jump(1, -2, false));
            movementPattern.AddRange(jump(-1, -2, false));
        }
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPath.Clear();
        if (isWhite)
        {
            attackPattern.AddRange(jump(2, 1, true));
            attackPattern.AddRange(jump(2, -1, true));

            attackPath.AddRange(jump(2, 1, false));
            attackPath.AddRange(jump(2, -1, false));
        }
        else
        {
            attackPattern.AddRange(jump(2, 1, true));
            attackPattern.AddRange(jump(2, -1, true));

            attackPath.AddRange(jump(2, 1, false));
            attackPath.AddRange(jump(2, -1, false));
        }
        getProtecteds();
        return attackPattern;
    }
}
