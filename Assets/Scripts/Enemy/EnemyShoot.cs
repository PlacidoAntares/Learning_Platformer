using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

	public GameObject PlayerTarget;
	public Transform PlayerTransform;
	public GameObject BulletPrefab;

	// Use this for initialization
	void Start () {
		
		PlayerTarget = GameObject.FindGameObjectWithTag("Player");
		PlayerTransform = PlayerTarget.GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {


	}

	void LookAtTarget()
	{
		transform.LookAt(PlayerTransform);
	}
}
