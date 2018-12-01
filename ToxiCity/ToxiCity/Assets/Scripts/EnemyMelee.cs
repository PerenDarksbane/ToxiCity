using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour {
	public LayerMask enemyMask;
	public float speed = 10;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth, myHeight;
	public bool isGrounded;
	public bool isBlocked;
	// Use this for initialization
	void Start () {
		myTrans = this.transform;
		myBody = this.GetComponent<Rigidbody2D> ();
		BoxCollider2D mySprite = this.GetComponent<BoxCollider2D> ();
		myWidth = mySprite.bounds.extents.x;
		myHeight = mySprite.bounds.extents.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 myPosition = myTrans.position;
		Vector2 myRight = myTrans.right;
		Vector2 lineCastPos = myPosition - myRight * myWidth - Vector2.up*myHeight;
		Debug.DrawLine (lineCastPos+ Vector2.down*0.1f, lineCastPos + Vector2.down);
		isGrounded = Physics2D.Linecast (lineCastPos+ Vector2.down*0.1f, lineCastPos + Vector2.down, enemyMask);
		isBlocked = Physics2D.Linecast (lineCastPos + Vector2.up*myHeight*0.1f - myRight, lineCastPos - myRight*1.4f + Vector2.up*myHeight*0.1f, enemyMask);
		Debug.DrawLine (lineCastPos + Vector2.up*myHeight*0.1f - myRight, lineCastPos - myRight*1.4f + Vector2.up*myHeight*0.1f);


		if (!isGrounded && myBody.velocity.y == 0||isBlocked) {
			Vector3 currRot = myTrans.eulerAngles;
			currRot.y += 180;
			myTrans.eulerAngles = currRot;
		}

		Vector2 myVel = myBody.velocity;

		myVel.x = -myTrans.right.x * speed;
		if (!isGrounded && myBody.velocity.y != 0) {
			myVel.x = 0;
		}
		myBody.velocity = myVel;
	}
}
