using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paladin : Piece {

    public override Piece Init()
    {
        worth = 8;
        title = "Paladin";
        number = 17;
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
        worth = 8;
        number = 17;
        title = "Paladin";
        movement();
        take();
        range();
    }


    public override List<Vector2> movement()
    {
        movementPattern.Clear();
        movementPattern.AddRange(jump(-1, 2, false));
        movementPattern.AddRange(jump(-2, 1, false));
        movementPattern.AddRange(jump(-2, -1, false));
        movementPattern.AddRange(jump(-1, -2, false));
        movementPattern.AddRange(jump(1, 2, false));
        movementPattern.AddRange(jump(2, 1, false));
        movementPattern.AddRange(jump(2, -1, false));
        movementPattern.AddRange(jump(1, -2, false));
        return movementPattern;
    }

    public override List<Vector2> take()
    {
        attackPattern.Clear();
        attackPattern.AddRange(jump(-1, 2, true));
        attackPattern.AddRange(jump(-2, 1, true));
        attackPattern.AddRange(jump(-2, -1, true));
        attackPattern.AddRange(jump(-1, -2, true));
        attackPattern.AddRange(jump(1, 2, true));
        attackPattern.AddRange(jump(2, 1, true));
        attackPattern.AddRange(jump(2, -1, true));
        attackPattern.AddRange(jump(1, -2, true));
        attackPath.Clear();
        attackPath.AddRange(jump(-1, 2, false));
        attackPath.AddRange(jump(-2, 1, false));
        attackPath.AddRange(jump(-2, -1, false));
        attackPath.AddRange(jump(-1, -2, false));
        attackPath.AddRange(jump(1, 2, false));
        attackPath.AddRange(jump(2, 1, false));
        attackPath.AddRange(jump(2, -1, false));
        attackPath.AddRange(jump(1, -2, false));
        getProtecteds();
        return attackPattern;
    }

    public override List<Vector2> range()
    {
        rangePattern.Clear();
        rangePattern.AddRange(jump(0, 2, true));
        rangePattern.AddRange(jump(2, 2, true));
        rangePattern.AddRange(jump(2, 0, true));
        rangePattern.AddRange(jump(2, -2, true));
        rangePattern.AddRange(jump(0, -2, true));
        rangePattern.AddRange(jump(-2, -2, true));
        rangePattern.AddRange(jump(-2, 0, true));
        rangePattern.AddRange(jump(-2, 2, true));
        rangePath.Clear();
        rangePath.AddRange(jump(0, 2, false));
        rangePath.AddRange(jump(2, 2, false));
        rangePath.AddRange(jump(2, 0, false));
        rangePath.AddRange(jump(2, -2, false));
        rangePath.AddRange(jump(0, -2, false));
        rangePath.AddRange(jump(-2, -2, false));
        rangePath.AddRange(jump(-2, 0, false));
        rangePath.AddRange(jump(-2, 2, false));
        getRangeProtecteds();
        return rangePattern;
    }

}
