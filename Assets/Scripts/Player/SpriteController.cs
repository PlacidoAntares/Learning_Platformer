using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER_ANIM_STATES
{
	idle,
	walk,
	jumping_takeoff,
	jumping_MidAir,
	jumping_land,

}
public class SpriteController : MonoBehaviour {

	public Animator Player_Anim;
	public Animator PlayerG_Anim;
	//
	public PLAYER_ANIM_STATES anim_states;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Movement ();
		Shoot ();
	}

	void Shoot()
	{
		if (Input.GetMouseButtonDown (0)) {
			PlayerG_Anim.SetBool ("IsShooting", true);
		}
		else if (Input.GetMouseButtonUp (0)) 
		{
			PlayerG_Anim.SetBool ("IsShooting",false);
		}
	}
	void Movement()
	{
		if (Input.GetKeyDown (KeyCode.D)) {
			anim_states = PLAYER_ANIM_STATES.walk;
			Player_Anim.SetBool ("IsWalking", true);
			Debug.Log ("Walking to the right");
		} 
		else if (Input.GetKeyDown (KeyCode.A)) {
			//rotate to face to the left
			//move to the left
			anim_states = PLAYER_ANIM_STATES.walk;
			Player_Anim.SetBool ("IsWalking", true);
		} 
		else if (Input.GetKey (KeyCode.Space)) {
			anim_states = PLAYER_ANIM_STATES.jumping_takeoff;
			Debug.Log ("Jumping");
		} 
		else if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D)) 
		{
			anim_states = PLAYER_ANIM_STATES.idle;
			Player_Anim.SetBool ("IsWalking", false);
			Debug.Log ("idling");

		}
	}


}
