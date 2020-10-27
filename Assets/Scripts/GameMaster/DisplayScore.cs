using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

	public Text ScoreText;
	public int ScoreVal;

	// Use this for initialization
	void Start () {
		ScoreText.text = ScoreVal.ToString ();		
	}
	
	public void ScoreUpdate(int ScoreValue)
	{
		ScoreVal += ScoreValue;
		ScoreText.text = ScoreVal.ToString ();
	}
}
