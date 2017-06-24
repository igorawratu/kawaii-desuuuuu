using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GooglyEyes : MonoBehaviour {

	private Vector3 originalPosition;
  	public float radius = 1;
  	public Vector2 pauseTimeRange = new Vector2(0.2f, 1f);
  	public Vector2 moveTimeRange = new Vector2(0.2f, 1f);
	// Use this for initialization
	void Start () {
		originalPosition = transform.localPosition;
		StartCoroutine(MoveCoroutine(originalPosition));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator MoveCoroutine(Vector3 startPosition) {
		Vector3 position = startPosition;
		Vector3 toPosition = originalPosition + new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), 0);
		float time = 0f;
		float totalTime = Random.Range(moveTimeRange.x, moveTimeRange.y);
		float pauseTime = Random.Range(pauseTimeRange.x, pauseTimeRange.y);
		yield return new WaitForSeconds(pauseTime);

		while (time < totalTime) {
			float f = time / totalTime;
			transform.localPosition = Vector3.Lerp(startPosition, toPosition, f);
			yield return new WaitForEndOfFrame();
			time += Time.deltaTime;
		}
		transform.localPosition = toPosition;

		StartCoroutine(MoveCoroutine(toPosition));
	}
}
