using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public Transform firePoint;
	public GameObject bulletPrefab;
	public int bulletDir;
	public Bullet bullet;
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	bool Isfiring;
//	public int ClipSize;
//	public int firedBullets;
	public GameObject spawnedBullet;
	public PlayerMovement playerMove;
	public Animator GunAnim;

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Isfiring = true;

		}
		else if (Input.GetMouseButtonUp (0)) {
			Isfiring = false;
		}

		if (Isfiring) {
			GunAnim.SetBool ("IsShooting", true);
			if (fireCountdown <= 0f) {
				Shoot ();
				fireCountdown = 1f / fireRate;
			}
			fireCountdown -= Time.deltaTime;
		}
		else if (!Isfiring) 
		{
			GunAnim.SetBool ("IsShooting", false);
		}
	}

	void Shoot()
	{
		//shooting Logic
		spawnedBullet = Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
		bullet = spawnedBullet.GetComponent<Bullet>();
		if (playerMove.IsFacingRight) {
			bullet.vectorVal = 1;
		}
		else if (!playerMove.IsFacingRight) 
		{
			bullet.vectorVal = -1;
		}
		bullet = null;
	}
}
