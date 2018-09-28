using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReCenterCamera : MonoBehaviour {

    public void reCenter()
    {
        Camera.main.transform.position = GameLogic.instance.centerPoint;
    }
}
