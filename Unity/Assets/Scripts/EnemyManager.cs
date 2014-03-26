using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	// Use this for initialization
	private BulletFiring[] weapons;
	private MovingForSprites moving;
	private bool hasSpawn;

	void Awake()
	{
		// Retrieve the weapon only once
		weapons = GetComponentsInChildren<BulletFiring>();
		moving = GetComponent<MovingForSprites>();
	}

	void Start(){
		hasSpawn = false;
		renderer.enabled = false;
		collider2D.enabled = false;

		moving.enabled = true;


		foreach (BulletFiring weapon in weapons){
			weapon.enabled = false;
		}
	}
	void Update()
	{
		// Auto-fire
		if (hasSpawn == false){
			if (renderer.IsVisibleFrom(Camera.main)){
				Spawn();
			}
		}
		else{
			//foreach (BulletFiring weapon in weapons){
			//	if (weapon != null && weapon.CanAttack)
			//	{
			//		weapon.Attack(true);
			//	}
				if (renderer.IsVisibleFrom(Camera.main) == false){
					Destroy (gameObject);
			}
		}
	}
	private void Spawn(){
		 
		hasSpawn = true;
		renderer.enabled = true;
		collider2D.enabled = true;
		//moving.enabled = true;
		foreach( BulletFiring weapon in weapons){
			weapon.enabled = true;
		}
	}
}
