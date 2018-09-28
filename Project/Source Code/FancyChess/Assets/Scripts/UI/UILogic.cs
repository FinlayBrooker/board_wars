using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UILogic : MonoBehaviour {

    public List<Piece> inPlay;
    public List<string> needed;
    public List<Piece> forUI;
    public GameObject cbPrefab;
    public List<CapturedButton> cbs;
    public static UILogic instance;
	// Use this for initialization
    void Awake()
    {
        instance = this;
    }

	void Start () {
        instance = this;
        inPlay.AddRange(GameLogic.instance.one.pieces);
        inPlay.AddRange(GameLogic.instance.two.pieces);
        foreach (Piece item in inPlay)
        {
            if (!needed.Contains(item.title))
            {
                needed.Add(item.title);
                forUI.Add(item);
            }
        }
        generateCaptureButtons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setup()
    {
        inPlay.AddRange(GameLogic.instance.one.pieces);
        inPlay.AddRange(GameLogic.instance.two.pieces);
        foreach (Piece item in inPlay)
        {
            if (!needed.Contains(item.title))
            {
                needed.Add(item.title);
                forUI.Add(item);
            }
        }
        generateCaptureButtons();
        for(int i = 0; i < needed.Count; i++)
        {
            GameLogic.instance.one.numberCaptured.Add(0);
            GameLogic.instance.two.numberCaptured.Add(0);
        }

    }

    public void generateCaptureButtons()
    {
        for(int i = 0; i < needed.Count; i++)
        {
            GameObject cb = Instantiate(cbPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            RectTransform rect = cb.GetComponent<RectTransform>();
            rect.SetParent(GameObject.Find("Buttons").transform);
            //cb.AddComponent<CapturedButton>();
            cb.GetComponent<CapturedButton>().caputred = forUI[i];
            cb.GetComponent<CapturedButton>().counter = i;
            cb.GetComponent<CapturedButton>().setup();
            cbs.Add(cb.GetComponent<CapturedButton>());

        }
    }

    public void addNewButton(Piece p)
    {
        GameObject cb = Instantiate(cbPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        RectTransform rect = cb.GetComponent<RectTransform>();
        rect.SetParent(GameObject.Find("Buttons").transform);
        //cb.AddComponent<CapturedButton>();
        cb.GetComponent<CapturedButton>().caputred = p;
        cb.GetComponent<CapturedButton>().setup();
        cbs.Add(cb.GetComponent<CapturedButton>());
        needed.Add(p.title);
        forUI.Add(p);
    }

    public void changeButtons(List<int> captured)
    {
        int counter = 0;
        foreach (Transform item in GameObject.Find("Buttons").transform)
        {
            item.GetComponent<CapturedButton>().number = captured[counter];
            counter++;
            item.GetComponent<CapturedButton>().setup();
        }
    }

    public void saveValues(List<int> captured)
    {
        int counter = 0;
        foreach (CapturedButton item in cbs)
        {
            captured[counter] = item.number;
            counter++;
        }
    }

    public void addToButton(string title)
    {
        int index = needed.IndexOf(title);
        
        cbs[index].add();
        //Debug.Log(cbs[index].number);
    }

    public void removeFromButton(string title)
    {
        int index = needed.IndexOf(title);
        cbs[index].remove();
    }

    public void changePoints(int value)
    {
        GameObject.Find("Score").GetComponent<Text>().text = value.ToString();
    }

    public void savePoints(int value)
    {
        value = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);
    }
}
