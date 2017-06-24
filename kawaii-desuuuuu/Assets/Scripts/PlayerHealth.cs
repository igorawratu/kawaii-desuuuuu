using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
	public int max_health_ = 5;
	public int health_;

	public float shake_ = 0f;
	public float shake_amount_ = 0.01f;
	public float decrease_factor_ = 0.05f;

	public GameObject death_effect_;
	public Text health_text_;
	public GameObject player_death_;

	private Vector3 orig_pos_;

	public void ScreenShake()
	{
		shake_ = 0.5f;
	}

	public void DecreaseHealth()
	{
		health_--;
		ScreenShake();
		string ht = "Love: ";
		for(int i = 0; i < max_health_ - health_; ++i)
		{
			ht += "<3 ";
		}

		health_text_.text = ht;
	}
	// Use this for initialization
	void Start () {
		orig_pos_ = Camera.main.transform.localPosition;
		health_ = max_health_;
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
			var effect = Instantiate(death_effect_);
			effect.transform.position = gameObject.transform.position;
			Destroy(gameObject);
			Instantiate(player_death_);
			StartCoroutine(EndGame());
		}
	}

	IEnumerator EndGame()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("EndScene");
	}
}
