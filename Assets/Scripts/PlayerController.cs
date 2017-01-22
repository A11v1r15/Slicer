using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float JumpSpeed = 10;
	public float rayDistance = 2f; // distance center to ground

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x < -30f ||  this.transform.position.y < -20f )
		{
			GameObject.Find ("Canvas").transform.GetChild (0).gameObject.SetActive (true);
		}
	}

	void OnMouseDown () {
		//Debug.Log ("Click!");
		if (Physics.Raycast(transform.position, -Vector3.up, rayDistance))
		{
			this.gameObject.GetComponent <Rigidbody>().velocity = Vector3.up*JumpSpeed;
		}
	}
	
//	void OnCollisionEnter(Collision collision) {
//	     if( collision.gameObject.tag == "Monster" )
//	     {
//	         GameObject.Find ("Canvas").transform.GetChild (0).gameObject.SetActive (true);
//	     }
// 	}
}