using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverworld : MonoBehaviour {
	Rigidbody2D rb;
	public float speed = 10f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*speed, Input.GetAxisRaw("Vertical")*speed);
	}
}
