using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poop : MonoBehaviour {
	public float lifetime_ = 10f;
	public GameObject effect_;

	private float curr_life_ = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		curr_life_ += Time.deltaTime;
		if(curr_life_ > lifetime_)
		{
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
		health.DecreaseHealth();
		var e = Instantiate(effect_);
		e.transform.position = gameObject.transform.position;
		Destroy(gameObject);
		
	}
}
