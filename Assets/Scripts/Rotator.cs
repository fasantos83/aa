using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	public float speed = 100f;

	private GameController gameController;

	private void Start(){
		gameController = FindObjectOfType<GameController>();
	}

	private	void Update () {
		float multiplier = gameController.GetLevel() * 0.5f;
		if (gameController.GetLevel() % 2 == 0) {
			multiplier = multiplier * -1;
		}
		float newSpeed = speed * multiplier * Time.deltaTime;
		newSpeed = Mathf.Clamp(newSpeed, -4, 4);
		Debug.Log("Speed:" + newSpeed.ToString());
		transform.Rotate(0f, 0f, newSpeed);
	}
}
