using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody rBody;
    float speed = 2;

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement.Normalize();

        rBody.AddForce(movement * speed / Time.deltaTime);
	}
}
