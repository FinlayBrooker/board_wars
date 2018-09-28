using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CapturedButton : MonoBehaviour {

    public Piece caputred;
    public int counter = 0;
    public int number = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setup()
    {
        GetComponentInChildren<Text>().text = caputred.title + "\n" + number;
        //Debug.Log(number);
    }

    public void add()
    {
        number++;
        //Debug.Log(number);
        setup();
    }
    public void remove()
    {
        number--;
        GameLogic.instance.turnPlayer.numberCaptured[counter]--;
        //GameLogic.instance.turnPlayer.takenPiecesDict[caputred]--;
        setup();
    }

    public void spawn()
    {
        if(number > 0)
        {
            GameLogic.instance.selectedCB = this;
        }
    }
}
