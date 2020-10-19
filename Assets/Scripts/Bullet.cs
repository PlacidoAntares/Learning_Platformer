using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public bool EnemyBullet;
	public float speed;
	public Rigidbody2D rb;
	public PlayerMovement playerMove;
	public int vectorVal;
	public float BulletDur;
	public int bulletDmg;
	public EnemyStats enemyStats;
	private SpriteRenderer enemySprite;
	// Use this for initialization
	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = (transform.right * speed) * vectorVal;
		Destroy (this.gameObject, BulletDur);
	}

	void Update()
	{
		
	}

	//If your GameObject starts to collide with another GameObject with a Collider
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			Debug.Log ("Enemy hit");
			//enemySprite = coll.gameObject.GetComponent<SpriteRenderer> ();
			//enemySprite.color = Color.red;
			enemyStats = coll.gameObject.GetComponent<EnemyStats> ();
			enemyStats.Health -= bulletDmg;
			enemyStats = null;
			DestroyObject (this.gameObject);
		}
		else if (coll.gameObject.tag == "Boundry") {
			DestroyObject (this.gameObject);
		}
		else if (coll.gameObject.tag == "Player") {
			Debug.Log ("Player hit");
			DestroyObject (this.gameObject);
		}
	}

}
