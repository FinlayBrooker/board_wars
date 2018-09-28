using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surrender : MonoBehaviour {

    public void surrender()
    {
        GameLogic.instance.surrender();
    }
}
