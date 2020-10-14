using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private Transform target;
	public EnemyStats Estats;
	private int wavepointIndex = 0;
	// Use this for initialization
	void Start () {
		Estats = gameObject.GetComponent<EnemyStats> ();
		target = Waypoints.waypoints[0];
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 dir = target.position - transform.position;
		transform.Translate (dir.normalized * Estats.MoveSpeed * Time.deltaTime, Space.World);

		if (Vector2.Distance (transform.position, target.position) < 0.2f) 
		{
			GetNextWaypoint ();
		}
		Estats.MoveSpeed = Estats.MoveSpeed;
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.waypoints.Length - 1) 
		{
			EndPath ();
			return;
		}
		wavepointIndex++;
		target = Waypoints.waypoints [wavepointIndex];
	}

	void EndPath()
	{
		target = Waypoints.waypoints [0];
		wavepointIndex = 0;
	}
}
