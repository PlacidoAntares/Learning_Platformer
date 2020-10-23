using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public float CamSpeed;
	public Transform Camera;
	public Transform Mech;
	public PlayerMovement PlayerMove;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Mech != null) {
			CamMove ();
		}

	}

	void CamMove()
	{
		float step = CamSpeed * Time.deltaTime;

		if (Camera.position.x != Mech.position.x) 
		{
			Camera.transform.position = Vector3.MoveTowards (transform.position, new Vector3 (Mech.transform.position.x, -0.023f,-15.0f), step);
			Debug.Log ("Moving Cam");
		}

	}
}
