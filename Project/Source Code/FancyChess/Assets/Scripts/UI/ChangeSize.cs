using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeSize(int value)
    {
        GenerateGame.instance.clear();
        GenerateGame.instance.createBoard(value+3);
        GameObject g = GameObject.Find("White Points");
        g.GetComponent<PointsValue>().resetValue(value + 3);
        GameObject g2 = GameObject.Find("Black Points");
        g2.GetComponent<PointsValue>().resetValue(value + 3);
        GameObject.Find("PromoRows").GetComponent<PromotionRowList>().changeData(GenerateGame.instance.rows);
    }
}
