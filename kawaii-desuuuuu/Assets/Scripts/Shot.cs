using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shot : MonoBehaviour {
	public float power_decay_multiplier_ = 2f;
	public float force_multiplier_ = 10f;

	private TrailRenderer tr_;

	public float Power
	{
		get; set;
	}

	public bool Fired
	{
		get; set;
	}

	private Rigidbody2D rb_;
	private SpriteRenderer sprite_renderer_;

	// Use this for initialization
	void Start () {
		rb_ = GetComponent<Rigidbody2D>();
		sprite_renderer_ = GetComponent<SpriteRenderer>();
		tr_ = GetComponent<TrailRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateShotState();
		UpdateSprite();
	}

	void UpdateShotState()
	{
		if (Fired)
		{
			Power -= power_decay_multiplier_ * Time.deltaTime;

			if(Power < 0f)
			{
				//play fizzle animation
				Destroy(gameObject);
			}
		}

		tr_.startWidth = 0.2f * Power;
	}

	private void UpdateSprite()
	{
		gameObject.transform.localScale = Vector3.one * Power;
	}

	public void Fire(Vector2 target)
	{
		if(Power > 1f)
		{
			Fired = true;

			Vector2 curr_pos = new Vector2(transform.position.x, transform.position.y);
			Vector2 force_dir_ = (target - curr_pos).normalized * Power * force_multiplier_;

			rb_.AddForce(force_dir_, ForceMode2D.Force);
		}
		else
		{
			//play fizzle animation
			Destroy(gameObject);
		}
	}
}
