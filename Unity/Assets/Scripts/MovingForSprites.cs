using UnityEngine;
using System.Collections;

public class MovingForSprites : MonoBehaviour {
	public Vector2 speed = new Vector2(10, 10);
	
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 direction = new Vector2(-1, 0);
	
	private Vector2 movement;
	
	void Update()
	{	
		transform.localRotation = Quaternion.Euler(0f,0f, Time.realtimeSinceStartup * (1920f/10f));

		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
	}
}
