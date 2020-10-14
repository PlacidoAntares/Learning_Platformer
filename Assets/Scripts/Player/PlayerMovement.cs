using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float walkSpeed = 40f;
	float horizontalMove = 0f;
	bool jump = false;
	public CharacterController2D controller;
	public ArmController ArmControl;
	public bool IsFacingRight;
	public Animator animator;
	public Transform player_transform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		horizontalMove = Input.GetAxisRaw ("Horizontal") * walkSpeed;
	
		if (horizontalMove < -1) {
			ArmControl.isFacingRight = false;
			IsFacingRight = false;
		} 
		else if (horizontalMove > 1) 
		{
			ArmControl.isFacingRight = true;
			IsFacingRight = true;
		}
		animator.SetFloat ("Speed",Mathf.Abs(horizontalMove));
		if (Input.GetButtonDown("Jump")) 
		{
			jump = true;
			animator.SetBool("isJumping",true);
		}

	}

	public void OnLanding()
	{
		animator.SetBool("isJumping", false);
	}
	void FixedUpdate()
	{
		//Character Movement
		controller.Move(horizontalMove *Time.fixedDeltaTime,false,jump);
		jump = false;
	}
}
