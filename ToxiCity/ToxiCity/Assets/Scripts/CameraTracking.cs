using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;
    private int yupbuf = 10;
    private int xribuf = 15;
    private int ydobuf = -5;
    private int xlebuf = -15;

    // Use this for initialization
    void Start () {
        offset = Vector3.zero;
		offset.z = transform.position.z - player.transform.position.z;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, offset.z);
	}
	
	// Update is called once per frame
	void LateUpdate () {
        offset.y = player.transform.position.y - transform.position.y;
        offset.x = player.transform.position.x - transform.position.x;
        if (offset.y > yupbuf)
        {   
            transform.position = new Vector3(transform.position.x, transform.position.y + offset.y - yupbuf, offset.z);
        }
        if (offset.x > xribuf)
        {
            transform.position = new Vector3(transform.position.x + offset.x - xribuf, transform.position.y, offset.z);
        }
        if (offset.y < ydobuf)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + offset.y - ydobuf, offset.z);
        }
        if (offset.x < xlebuf)
        {
            transform.position = new Vector3(transform.position.x + offset.x - xlebuf, transform.position.y, offset.z);
        }


    }
}
