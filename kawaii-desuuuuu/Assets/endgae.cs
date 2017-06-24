using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endgae : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(EndGame());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator EndGame()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("EndScene");
	}
}
