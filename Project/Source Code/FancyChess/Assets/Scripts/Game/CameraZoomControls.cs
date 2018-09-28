using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomControls : MonoBehaviour {

    public float scrollSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(Camera.main.transform.position.y - scrollSpeed < 3)
            {
                return;
            }
            //Camera.main.transform.position -= new Vector3(0, scrollSpeed, 0);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, LayerMask.GetMask("Board")))
            {

                Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, hit.transform.position, scrollSpeed);
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.transform.position.y + scrollSpeed > 3.5f*26)
            {
                return;
            }
            //Camera.main.transform.position += new Vector3(0, scrollSpeed, 0);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, LayerMask.GetMask("Board")))
            {

                Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, hit.transform.position, -scrollSpeed);
            }
        }
    }
}
