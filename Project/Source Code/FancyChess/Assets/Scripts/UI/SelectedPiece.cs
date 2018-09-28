using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SelectedPiece : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        string name = "None";
        if(GameLogic.instance.selectedPiece != null)
        {
            name = GameLogic.instance.selectedPiece.title;
        }
        GetComponent<Text>().text = "Currently Selected Piece \n" + name;
	}
}
