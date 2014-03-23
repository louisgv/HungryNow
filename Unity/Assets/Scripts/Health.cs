using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	private SpriteRenderer myRenderer;
	public Sprite cooked;
	public int hp = 3;
	public bool isEnemy = true;
	// Use this for initialization
	void Start () {
		myRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	public void CheckDamage(int damage){
		hp -= damage;
		if (hp <= 0)
		{
			myRenderer.sprite = cooked;
		}
	}

	void OnTriggerEnter2D (Collider2D otherCollider)
	{
		BulletManager bullet = otherCollider.gameObject.GetComponent<BulletManager>();
		if (bullet != null)
		{
			CheckDamage(bullet.damage);
			Destroy (bullet.gameObject);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
