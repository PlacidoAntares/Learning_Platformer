using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	public int Health;
	public float MoveSpeed;
	public int ScoreVal;
	public GameObject deathFx;
	public GameObject E_spawn;
	public EnemySpawn E_spawnScript;
	// Use this for initialization
	void Start () {
		E_spawn = GameObject.Find ("SpawnPoint01");
		E_spawnScript = E_spawn.GetComponent<EnemySpawn> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) 
		{
			E_spawnScript.EnemyCount -= 1;
			E_spawnScript = null;
			E_spawn = null;
			Instantiate (deathFx, this.gameObject.transform.position, this.gameObject.transform.rotation);
			DestroyObject (this.gameObject);
		}
	}
}
