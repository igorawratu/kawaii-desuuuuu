using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
	public int health_ = 3;

	public float shake_ = 0f;
	public float shake_amount_ = 0.01f;
	public float decrease_factor_ = 0.05f;

	private Vector3 orig_pos_;

	public void ScreenShake()
	{
		shake_ = 0.5f;
	}

	public void DecreaseHealth()
	{
		health_--;
		ScreenShake();
	}
	// Use this for initialization
	void Start () {
		orig_pos_ = Camera.main.transform.localPosition;
	}

	private void UpdateShake()
	{
		if (shake_ > 0)
		{
			var offset = Random.insideUnitCircle * shake_amount_;
			Camera.main.transform.localPosition = orig_pos_ + new Vector3(offset.x, offset.y, -10f);
			shake_ -= Time.deltaTime * decrease_factor_;
		}
		else
		{
			shake_ = 0f;
			Camera.main.transform.localPosition = orig_pos_;
		}
	}

	// Update is called once per frame
	void Update () {
		UpdateShake();

		if(health_ <= 0)
		{
			//end game here
		}
	}
}
