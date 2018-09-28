using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Piece {

    public override Piece Init()
    {
        worth = 1;
        title = "Archer";
        number = 14;
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
        worth = 1;
        number = 14;
        title = "Archer";
        movement();
        take();
        range();
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -90);
     }

    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        if (isWhite)
        {
            movementPattern.AddRange(moveF(1, false));
        }
        else
        {
            movementPattern.AddRange(moveB(1, false));
        }

        return movementPattern;
    }

    public override List<Vector2> range()
    {
        rangePattern.Clear();
        rangePath.Clear();
        if (isWhite)
        {
            rangePattern.AddRange(jump(0, 2, true));
            rangePath.AddRange(jump(0, 2, false));
        }
        else
        {
            rangePattern.AddRange(jump(0, -2, true));
            rangePath.AddRange(jump(0, 2, false));
        }
        getRangeProtecteds();
        return rangePattern;
    }
}
