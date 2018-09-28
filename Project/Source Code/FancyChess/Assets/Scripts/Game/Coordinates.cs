using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates {

    // Use this for initialization

    public int x { get; set; }
    public char y { get; set; }
    public Coordinates(int x, char y)
    {
        this.x = x;
        this.y = y;
    }
    public Coordinates(int x, int y)
    {
        this.x = x;
        this.y = (char)(65+y);
    }

}
