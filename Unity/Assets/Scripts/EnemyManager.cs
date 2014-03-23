using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	// Use this for initialization
	private BulletFiring weapon;

	void Awake()
	{
		// Retrieve the weapon only once
		weapon = GetComponent<BulletFiring>();
	}
	
	void Update()
	{
		// Auto-fire
		if (weapon != null && weapon.CanAttack)
		{
			weapon.Attack(true);
		}
	}
	void Destroy()
	{

	}
}
