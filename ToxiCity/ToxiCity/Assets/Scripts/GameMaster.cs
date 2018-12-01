using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour {
	public Text InputText;
	public static GameMaster Instance;
	// Use this for initialization
	void Awake()  {
		if(Instance == null){
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this){
			Destroy (gameObject);
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
