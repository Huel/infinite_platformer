using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public int health = 1;
	Rigidbody2D rb;
	SpriteRenderer spriteRenderer;
	CircleCollider2D circleColider;

	private void Awake() 
	{
		rb = this.GetComponent<Rigidbody2D>();
	}

	private void Update() 
	{
		
	}
	private void OnCollisionEnter2D(Collision2D other) 
	{
		if(other.gameObject.tag == GameplayConstants.TAG_Player)
		{
			Debug.Log("Enemy --> Player Collision");
			--health;

			if(health<0)
				killEnemy();		
		}	
	}

	private void killEnemy()
	{
		Destroy(this.gameObject);
	}
}
