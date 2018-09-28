using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromoPanel : MonoBehaviour {

    public GameObject promoPrefab;
    public List<PromoButton> buttons;
    public List<Piece> promotesTo;

    public void Init(List<Piece> p)
    {
        promotesTo = p;
        createButtons();
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void createButtons()
    {
        buttons.Clear();
        for (int i = 0; i < promotesTo.Count; i++)
        {
            PromoButton pb = Instantiate(promoPrefab, Vector3.zero, Quaternion.identity).GetComponent<PromoButton>();
            RectTransform trans = pb.GetComponent<RectTransform>();
            trans.SetParent(transform, false);
            pb.piece = promotesTo[i];
            pb.Init(promotesTo[i]);
            buttons.Add(pb);
        }
        
    }
}
