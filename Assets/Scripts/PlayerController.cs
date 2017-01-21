using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float JumpSpeed = 10;
	public float rayDistance = 1f; // distance center to ground

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown () {
		if (Physics.Raycast(transform.position, -Vector3.up, 1.1f))
		{
			this.gameObject.GetComponent <Rigidbody>().velocity = Vector3.up*JumpSpeed;
			//this.transform.Translate(0,JumpSpeed*Time.deltaTime,0,0);
		}
	}
}