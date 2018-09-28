using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtboxTraits : MonoBehaviour {
	
	public float xscale;
	public float yscale;
	public float damage;
	public float knockback;
	public string effect; 
	public float time;
	public Vector3 originPos;
	public Vector3 displacePos;
	public Vector3 scale;
	public GameObject player;
	public float combo = 0;
	public float comboTime;

	// Use this for initialization
	void Start () {
		originPos = this.transform.position;
		player = GameObject.FindGameObjectWithTag("Player");
		displacePos = originPos - player.transform.position;
		scale.Set(xscale,yscale,1);

	}
	
	// Update is called once per frame
	void Update () {

		this.transform.position = displacePos + player.transform.position;
		this.transform.localScale = scale;

		if (time <= 0) {
			Destroy(this.gameObject);
		}
		var trait = player.gameObject.GetComponent <PlayerTraits> ();
		trait.combo += combo;
		trait.comboTime = comboTime;
	}

	void FixedUpdate(){
		time--;

	}
}
