using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public int PowerUpID;
	public int PowerUPVal;
	public float  PowerUpDur;
	public GameObject PowerUpParent;
	public GameObject Player;
	public PlayerStats P_Stats;
	public GameObject GameMngr;
	public DisplayScore ScoreDisplay;
	// Use this for initialization
	void Start () {
		GameMngr = GameObject.Find ("GameEventManager");
		ScoreDisplay = GameMngr.gameObject.GetComponent<DisplayScore> ();
		Player = GameObject.FindGameObjectWithTag("Player");
		P_Stats = Player.gameObject.GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") 
			{
			Debug.Log ("Picked Up PowerUp");
			switch (PowerUpID) 
				{
			case 0:
				if (P_Stats.P_Health < P_Stats.P_MaxHealth) {
					P_Stats.P_Health += 500;
					ScoreDisplay.ScoreUpdate (PowerUPVal);
					Debug.Log ("Healed 500 HP");
					if (P_Stats.P_Health >= P_Stats.P_MaxHealth) 
					{
						P_Stats.P_Health = P_Stats.P_MaxHealth;
					}
				}
				else if (P_Stats.P_Health >= P_Stats.P_MaxHealth) 
				{
					Debug.Log ("Full HP");
				}
				break;

			case 1:
				ScoreDisplay.ScoreUpdate(PowerUPVal);
				break;
				}
			Destroy (PowerUpParent);
			}
		}
}
