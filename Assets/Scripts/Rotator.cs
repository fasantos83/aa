using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float speed = 100f;

	private	void Update () {
		float multiplier = GameController.Level * 0.5f;
		if (GameController.Level % 2 == 0) {
			multiplier = multiplier * -1;
		}
		transform.Rotate(0f, 0f, speed * multiplier * Time.deltaTime);
	}
}
