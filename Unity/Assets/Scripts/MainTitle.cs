using UnityEngine;
using System.Collections;

public class MainTitle : MonoBehaviour {

	private bool clicked = false;
	public float timer = 2;
	void Update(){
		if (clicked){
			timer -= Time.deltaTime;
			if (timer <= 0){
				Application.LoadLevel("BaconShooter");
				Debug.Log("Loaded!");
			}

		}
	}

	void OnMouseDown() {
		//Application.LoadLevel("BaconShooter");
		Debug.Log("Clicked!");
		if (rigidbody2D.isKinematic){
			rigidbody2D.isKinematic = false;
		}
		clicked = true;
	}
}
