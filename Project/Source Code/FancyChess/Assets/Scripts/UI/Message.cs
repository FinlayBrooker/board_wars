using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Message : MonoBehaviour {

    public string message;

    public Message Init(string message)
    {
        this.message = message;
        return this;
    }

	// Use this for initialization
	void Start () {
        GetComponentInChildren<Text>().text = message;

        StartCoroutine(destroy());
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<Text>().text = message;
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
