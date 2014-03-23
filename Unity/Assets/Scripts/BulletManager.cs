using UnityEngine;
using System.Collections;

public class BulletManager : MonoBehaviour {
	public int damage = 1;
	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5); //Destroy it after 20sec to avoid leak 
	}
	
	// Update is called once per frame

}
