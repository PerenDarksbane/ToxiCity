using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraits : MonoBehaviour {
	public float health = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag("EnemyHurt")) {
			var trait = other.gameObject.GetComponent<PlayerHurtboxTraits>();
			trait.combo += 0.1f;
			trait.comboTime = 25f;
			health -= trait.damage;

		}
	}
}
