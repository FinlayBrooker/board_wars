using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialControler : MonoBehaviour {

    public static TutorialControler instance;
    public GameObject messagePrefab;
    public bool messageOpen = false;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void displayMessage(string message)
    {
        GameObject go = Instantiate(messagePrefab, Vector3.zero, Quaternion.identity) as GameObject;
        RectTransform trans = go.GetComponent<RectTransform>();
        trans.SetParent(GameObject.Find("HUD").transform, false);
        go.GetComponent<TutorialMessage>().setup(message);
        messageOpen = true;
    }

    public void handleMessage(string message)
    {
        if (messageOpen)
        {
            return;
        }
        displayMessage(message);
    }
}
