using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	public GameObject PlayerTarget;
	private Transform PlayerTransform;
	private Vector3 thisPos;
	private Vector3 targetPos;
	private float angle;
	public float offset;
	public GameObject ThisTurret;
	public GameObject BulletPrefab;
	public float fireRate = 1f;
	public float fireCountdown = 0f;
	public GameObject spawnedBullet;
	Rigidbody2D BulletRigidBody;
	Transform turretTransform;

	// Use this for initialization
	void Start () {

		ThisTurret = this.gameObject;
		turretTransform = ThisTurret.gameObject.GetComponent<Transform> ();
		PlayerTarget = GameObject.FindGameObjectWithTag("Player");
		PlayerTransform = PlayerTarget.GetComponent<Transform> ();

	}

	// Update is called once per frame
	void Update () {
		
		if (fireCountdown <= 0f) {
			Shoot_E ();
			fireCountdown = 1f / fireRate;
		}
		fireCountdown -= Time.deltaTime;
	}


	void RotateTurret()
	{
		targetPos = PlayerTransform.position;
		thisPos = turretTransform.position;
		targetPos.x = targetPos.x - thisPos.x;
		targetPos.y = targetPos.y - thisPos.y;
		angle = Mathf.Atan2(targetPos.y,targetPos.x) *  Mathf.Rad2Deg;
		turretTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));

	}
	void Shoot_E()
	{
		Debug.Log ("Enemy Shooting");
		RotateTurret ();
		spawnedBullet = Instantiate(BulletPrefab,this.gameObject.transform.position,this.gameObject.transform.rotation);
		BulletRigidBody = spawnedBullet.GetComponent<Rigidbody2D> ();


	}

}