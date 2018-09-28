using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillPieceList : MonoBehaviour {

    List<Piece> pieces;

	// Use this for initialization
	void Start () {
        pieces = GlobalVariables.pieces;
        fillList();
	}

    public void fillList()
    {
        //Debug.Log(pieces.Count);
        
        GetComponent<Dropdown>().options.Clear();
        for (int i = 0; i < pieces.Count; i++)
        {
            
            GetComponent<Dropdown>().options.Add(new Dropdown.OptionData() { text = pieces[i].title + ": " + pieces[i].cost });
            
        }
       
    }
}
