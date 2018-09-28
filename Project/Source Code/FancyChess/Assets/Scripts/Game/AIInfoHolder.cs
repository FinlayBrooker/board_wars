using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInfoHolder {

    public AIInfoHolder(int value, Vector2 target, System.Guid idOfPiece, char moveType)
    {
        this.value = value;
        this.target = target;
        this.idOfPiece = idOfPiece;
        this.moveType = moveType;

    }
	public int value = 0;
    public Vector2 target = new Vector2();
    public System.Guid idOfPiece;
    public char moveType = ' ';

}
