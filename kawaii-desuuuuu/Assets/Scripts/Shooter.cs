using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
	public float max_power_ = 3.5f;
	public float power_gain_multiplier_ = 2f;
	public GameObject shot_prefab_;
	public GameObject mouse_cursor_;

	private Shot current_shot_= null;

	public bool Charging
	{
		get { return current_shot_ == null;}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckPowerup();
	}

	private void CheckPowerup()
	{
		if (Input.GetAxis("Powerup") > 0.5f)
		{
			if (current_shot_ == null)
			{
				var shot = Instantiate(shot_prefab_);
				//shot.transform.parent = gameObject.transform;
				shot.transform.position = gameObject.transform.position;
				current_shot_ = shot.GetComponent<Shot>();
			}
			else
			{
				current_shot_.Power = Mathf.Min(current_shot_.Power + Time.deltaTime * power_gain_multiplier_, max_power_);
			}
		}
		else
		{
			if (current_shot_ != null)
			{
				current_shot_.Fire(new Vector2(mouse_cursor_.transform.position.x, 
					mouse_cursor_.transform.position.y));
				current_shot_ = null;
			}
		}
	}
}
