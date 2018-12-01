using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoaim : MonoBehaviour {
	public float speed = 5f;
	// Use this for initialization
	public Transform target;
	// Update is called once per frame
	private void Update () {
		//https://www.youtube.com/watch?v=mKLp-2iseDc
		if (target == null){
			target = GameObject.FindGameObjectWithTag("player").transform;
			Debug.Log ("finding");
		}
		Vector2 direction = target.position - transform.position;
		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg ;
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, speed * Time.deltaTime);
	}
}
