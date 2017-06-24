using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float ground_speed_ = 1f;
	public float jump_force_ = 5f;

	private bool movement_frozen_ = false;
	private Rigidbody2D rb_;
	// Use this for initialization
	void Start () {
		rb_ = GetComponent<Rigidbody2D>();
	}

	private bool OnGround()
	{
		Vector2 origin = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

		int mask = LayerMask.NameToLayer("Environment");
		RaycastHit2D hit1 = Physics2D.Raycast(origin, Vector2.down, 50f, 1 << mask);
		RaycastHit2D hit2 = Physics2D.Raycast(origin, Vector2.up, 50f, 1 << mask);
		RaycastHit2D hit3 = Physics2D.Raycast(origin, Vector2.left, 50f, 1 << mask);
		RaycastHit2D hit4 = Physics2D.Raycast(origin, Vector2.right, 50f, 1 << mask);

		float d = Mathf.Min(hit1.distance, Mathf.Min(hit2.distance, Mathf.Min(hit3.distance, hit4.distance)));
		
		return d < 1f;
	}
	
	private void FreezePlayerMovement()
	{
		if (movement_frozen_)
		{
			return;
		}

		rb_.gravityScale = 0f;
		rb_.constraints = RigidbodyConstraints2D.FreezeAll;
		movement_frozen_ = true;
	}

	private void UnfreezePlayerMovement()
	{
		if (!movement_frozen_)
		{
			return;
		}

		rb_.gravityScale = 5f;
		rb_.constraints = RigidbodyConstraints2D.None;
		movement_frozen_ = false;
	}

	private void UpdatePlayerMovement()
	{
		if (movement_frozen_)
		{
			return;
		}

		Vector2 dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
		Vector2 walk_dir = new Vector2(Input.GetAxis("Horizontal"), 0f).normalized;

		bool on_ground = OnGround();
		if (on_ground)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				rb_.velocity = Vector2.zero;
				rb_.AddForce(dir * jump_force_);
			}
			else
			{
				Vector2 newPos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) +
					walk_dir * ground_speed_ * Time.deltaTime;
				gameObject.transform.position = new Vector3(newPos.x, newPos.y, 0f);
			}
		}

		
		
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Powerup") > 0.5f)
		{
			FreezePlayerMovement();
		}
		else
		{
			UnfreezePlayerMovement();
		}

		UpdatePlayerMovement();
	}
}
