using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PromoButton : MonoBehaviour {

    public Piece piece;

    public void Init(Piece p)
    {
        piece = p;
        GetComponentInChildren<Text>().text = piece.title;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<Text>().text = piece.title;
	}

    public void onClick()
    {
        GameLogic.instance.promoTo = piece;
        GameLogic.instance.cont = true;
        Destroy(transform.parent.gameObject);
    }
}
