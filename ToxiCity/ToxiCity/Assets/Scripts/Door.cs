using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
	public int LevelToLoad;
	private GameMaster gm;
	public Text Textt;

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			//Debug.Log ("a");
			Textt.text = ("Exit");
			if (Input.GetButtonDown("Interact")) 
			{
				SceneManager.LoadScene (LevelToLoad);
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag ("Player")) 
		{
			if (Input.GetButtonDown ("Interact")) 
			{
				SceneManager.LoadScene (LevelToLoad);
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		Textt.text = ("");
	}


}
