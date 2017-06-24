using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuteBadThingMovement : MonoBehaviour {
	public float speed_ = 1f;
	public GameObject poop_prefab_;
	public float shitimer_ = 5f;
	public GameObject death_effect_;
	public GameObject player_ = null;

	public List<GameObject> spawn_sounds_;
	public List<GameObject> death_sounds_;

	private float shit_curr_ = 0f;

	// Use this for initialization
	void Start () {
		int idx = Mathf.Min((int)(Random.value * spawn_sounds_.Count), spawn_sounds_.Count - 1);
		Instantiate(spawn_sounds_[idx]);
	}
	
	// Update is called once per frame
	void Update () {
		if(player_ == null)
		{
			return;
		}
		var dir = player_.gameObject.transform.position - gameObject.transform.position;
		dir.z = 0;
		dir.y = 0;

		dir = dir.normalized * speed_ * Time.deltaTime;
		gameObject.transform.position = gameObject.transform.position + dir;

		shit_curr_ += Time.deltaTime;

		if(shit_curr_ > shitimer_)
		{
			var shit = Instantiate(poop_prefab_);
			shit.gameObject.transform.position = gameObject.transform.position;
			shit_curr_ = 0f;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();

		if(health != null)
		{
			health.DecreaseHealth();
		}

		//play sound and explosion here
		var effect = Instantiate(death_effect_);
		effect.transform.position = gameObject.transform.position;

		int idx = Mathf.Min((int)(Random.value * death_sounds_.Count), death_sounds_.Count - 1);
		Instantiate(death_sounds_[idx]);

		Destroy(gameObject);
	}
}
