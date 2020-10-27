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
	public GameObject E_Obj;
	public GameObject [] LootTable;
	public int LootTableSize;
	public int LootID;
	public float [] LootChance;
	public float LootRoll;
	public GameObject GameEventMngr;
	public DisplayScore DisplayScr;
	// Use this for initialization
	void Start () {
		GameEventMngr = GameObject.Find ("GameEventManager");
		DisplayScr = GameEventMngr.GetComponent<DisplayScore> ();
		E_spawn = GameObject.Find ("SpawnPoint01");
		E_spawnScript = E_spawn.GetComponent<EnemySpawn> ();
		LootRoll = Random.Range (0, 100);
		LootID = Random.Range (0, LootTableSize);
		Debug.Log("LootID:" + LootID);
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) 
		{
			E_spawnScript.EnemyCount -= 1;
			DisplayScr.ScoreUpdate (ScoreVal);
			E_spawnScript = null;
			E_spawn = null;
			Instantiate (deathFx, this.gameObject.transform.position, this.gameObject.transform.rotation);
			if(LootChance [LootID] >= LootRoll) 
			{
				Instantiate (LootTable[LootID],this.gameObject.transform.position, this.gameObject.transform.rotation);
			}
			DestroyObject (E_Obj);
		}
	}
}
