using UnityEngine;
using System;
public class ShooterBaconManager : MonoBehaviour
{
	// The force which is added when the player jumps
	// This can be changed in the Inspector window
	public Vector2 jumpForce = new Vector2(0, 300);
	public Vector2 speed = new Vector2(20,20);
	private Vector2 movement;
	//public Vector2 direction = new Vector2(-1, 0);
	// Update is called once per frame
	void Update ()
	{
		transform.localRotation = Quaternion.Euler(0f,0f, Time.realtimeSinceStartup * - (720f/60f));
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2(speed.x * inputX, speed.y *inputY );

		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (shoot)
		{
			BulletFiring weapon = GetComponent<BulletFiring>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
			}
		}
	}
	void FixedUpdate(){
		// Jump
		if (Input.GetKeyUp("space"))
		{
			//rigidbody2D.velocity = Vector2.zero;
			//rigidbody2D.AddForce(jumpForce);
		}
		else{
			rigidbody2D.velocity = movement;
			 
		}
	}
}
