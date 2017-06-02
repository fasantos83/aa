using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pin : MonoBehaviour {

	public float speed = 20f;
	public Rigidbody2D rb;
	public Text numberText;

	private bool pinned = false;

	private void Start(){
		numberText.text = (Score.PinCount + 1).ToString();
	}

	private void Update () {
		if (!pinned) {
			rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
		}
	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Rotator")){
			transform.SetParent(other.transform);
			pinned = true;
			Score.PinCount++;
			if (Score.PinCount == GameController.Target) {
				FindObjectOfType<GameController>().Win();
			}
		}else if(other.CompareTag("Pin")){
			FindObjectOfType<GameController>().EndGame();
		}
			
	}
		
}
