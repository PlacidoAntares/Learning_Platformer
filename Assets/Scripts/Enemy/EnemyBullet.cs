using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

	public float EB_speed;
	public Rigidbody2D rb;
	public float EB_BulletDur;
	public int EB_BulletDmg;
	public PlayerStats P_Stats;

	// Use this for initialization
	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody2D> ();
		rb.velocity = (transform.right * EB_speed) ;
		Destroy (this.gameObject, EB_BulletDur);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
<<<<<<< Updated upstream
=======

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Debug.Log ("Player hit");
			P_Stats = coll.gameObject.GetComponentInChildren<PlayerStats>();
			P_Stats.TakeDamage (EB_BulletDmg);
			DestroyObject (this.gameObject);
		}
	}
>>>>>>> Stashed changes
}
