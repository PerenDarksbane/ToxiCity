using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = Vector3.zero;
		offset.z = transform.position.z - player.transform.position.z;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + new Vector3 (0, 0, offset.z);
	}
}
