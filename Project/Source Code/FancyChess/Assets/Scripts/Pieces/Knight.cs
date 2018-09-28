using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Piece {

    public override Piece Init()
    {
        worth = 3;
        title = "Knight";
        number = 1;
        return this;
    }

    // Use this for initialization
    new void Start()
    {
        if (base.Start())
        {
            return;
        }
        transform.rotation = transform.rotation * Quaternion.Euler(0, 0, 270);
        setupPiece();
        worth = 3;
        number = 1;
        title = "Knight";
        movement();
        take();
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
}
