using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillMe : MonoBehaviour {
	public float time_ = 2f;

	private float timer_ = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer_ += Time.deltaTime;

		if(timer_ >= time_)
		{
			Destroy(gameObject);
		}
	}
}
