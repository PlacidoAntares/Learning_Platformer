using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public GameObject EnemyPrefab;
	public float SpawnRate;
	float SpawnTimer;
	public int MaxEnemyCount;
	public int EnemyCount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (EnemyCount < MaxEnemyCount) {
			if (SpawnTimer <= 0f) {
				Spawn ();
				SpawnTimer = 1f / SpawnRate;
			}
			SpawnTimer -= Time.deltaTime;
		}

		else if (EnemyCount >= MaxEnemyCount) 
		{
			Debug.Log ("Max Enemies");
		}

	}

	void Spawn()
	{
		Instantiate(EnemyPrefab,this.gameObject.transform.position,this.gameObject.transform.rotation);
		EnemyCount++;
	}
}
