using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject pin;

	private void Update(){
		if(Input.GetButtonDown("Fire1")){
			SpawnPin();
		}
	}

	private void SpawnPin(){
		Instantiate(pin, transform.position, transform.rotation);
	}
		
}
