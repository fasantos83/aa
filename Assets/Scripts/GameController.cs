using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Rotator rotator;
	public Spawner spawner;
	public Animator animator;
	public Text targetText;
	public static int Target = 0;
	public static int Level  = 0;

	private bool endGame = false;

	private void Start(){
		Level = 1;
		Target = 0;
		SetNewParams();
	}

	private void enableInput(bool enable){
		rotator.enabled = enable;
		spawner.enabled = enable;
	}

	public void EndGame(){
		if (endGame) {
			return;
		}
		enableInput(false);
		endGame = true;
		animator.SetTrigger("EndGame");
	}

	public void RestartLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Win(){
		enableInput(false);
		animator.SetTrigger("Win");
	}

	public void NextLevel(){
		int pinCount = rotator.transform.childCount;
		for (int i = 0; i < pinCount; i++) {
			GameObject.Destroy(rotator.transform.GetChild(i).gameObject);
		}			
		Level++;
		SetNewParams();
		enableInput(true);
		animator.SetTrigger("Start");
	}
	
	private void SetNewParams(){
		Score.PinCount = 0;
		Target = Target + 2;
		targetText.text = "Target: " + Target.ToString();
	}

}
