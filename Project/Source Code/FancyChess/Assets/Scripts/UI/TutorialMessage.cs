using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TutorialMessage : MonoBehaviour {

    string message;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setup(string message)
    {
        this.message = message;
        GetComponentInChildren<Text>().text = message;
    }

    public void button()
    {
        TutorialControler.instance.messageOpen = false;
        Destroy(transform.parent.gameObject);
    }
}
