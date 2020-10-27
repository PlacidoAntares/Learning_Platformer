using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFx : MonoBehaviour {

	public float FXduration;
	// Use this for initialization
	void Start () {
		DestroyObject (this.gameObject, FXduration);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
