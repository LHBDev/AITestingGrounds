using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

    public Transform player;
    public float camHeight = 30;
    public float camBehind = 30;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(player.position.x, camHeight, player.position.z - camBehind);
        transform.position = newPos;
	}
}
