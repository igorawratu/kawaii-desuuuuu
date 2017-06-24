using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject creep_prefab_;
	public GameObject player;

	public float spawn_timer_ = 5f;
	public float min_spawn_timer_ = 1f;
	public float speedup_ = 0.01f;
	public float displacement_ = 10f;

	private float current_spawn_timer_ = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		current_spawn_timer_ += Time.deltaTime;

		if(current_spawn_timer_ > spawn_timer_)
		{
			current_spawn_timer_ = 0f;
			var creep = Instantiate(creep_prefab_);
			creep.transform.position = (Random.value > 0.5 ? Vector3.left : Vector3.right) * displacement_;

			CuteBadThingMovement mov = creep.GetComponent<CuteBadThingMovement>();
			mov.player_ = player;
		}

		spawn_timer_ -= speedup_ * Time.deltaTime;
		spawn_timer_ = Mathf.Max(min_spawn_timer_, spawn_timer_);
	}
}
