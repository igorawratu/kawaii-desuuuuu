using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shot : MonoBehaviour {
	public Sprite under_one_charging_;
	public Sprite under_one_firing_;
	public Sprite above_one_;
	public Sprite above_two_;
	public Sprite above_three_;

	public float power_decay_multiplier_ = 2f;
	public float force_multiplier_ = 10f;

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
	}

	private void UpdateSprite()
	{
		if(Power < 1f)
		{
			if (Fired)
			{
				sprite_renderer_.sprite = under_one_firing_;
			}
			else
			{
				sprite_renderer_.sprite = under_one_charging_;
			}
		}
		else if(Power >= 1f && Power < 2f)
		{
			sprite_renderer_.sprite = above_one_;
		}
		else if(Power >= 2f && Power < 3f)
		{
			sprite_renderer_.sprite = above_two_;
		}
		else if(Power >= 3f)
		{
			sprite_renderer_.sprite = above_three_;
		}
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
