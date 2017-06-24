using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var pt = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		gameObject.transform.position = new Vector3(pt.x, pt.y, 0f);
	}
}
