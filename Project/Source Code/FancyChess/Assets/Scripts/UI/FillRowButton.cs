using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillRowButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void fillRow()
    {
        GeneratedTile lc = GenerateGame.instance.selected;
        //Debug.Log(Mathf.FloorToInt(lc.pos.x));
        if (lc != null)
        {
            if (GameObject.Find("Pieces").GetComponent<Dropdown>().options[GameObject.Find("Pieces").GetComponent<Dropdown>().value].text.Contains("King"))
            {
                return;
            }
            for(int i = 0; i < GenerateGame.instance.boardSize; i++)
            {
                GameObject g;
                if (GenerateGame.instance.selected.isWhite)
                {
                    g = GameObject.Find("White Points");
                }
                else
                {
                    g = GameObject.Find("Black Points");
                }
                int v = int.Parse(g.GetComponent<Text>().text);
                int c = GlobalVariables.pieces[GameObject.Find("Pieces").GetComponent<Dropdown>().value].cost;
                if (v - c < 0)
                {
                    return;
                }
                g.GetComponent<Text>().text = (v - c).ToString();
                if (GenerateGame.instance.board[Mathf.FloorToInt(lc.pos.x)][i].occupied)
                {
                    RemovePiece.removePiece(GenerateGame.instance.board[Mathf.FloorToInt(lc.pos.x)][i].occupiedBy);
                }
                //Debug.Log(Mathf.FloorToInt(lc.pos.x));
                int p = Mathf.FloorToInt(lc.pos.x);
                GenerateGame.instance.spawnPiece(GameObject.Find("Pieces").GetComponent<Dropdown>().value, GenerateGame.instance.board[p][i]);
            }
            
        }
        

    }
}
