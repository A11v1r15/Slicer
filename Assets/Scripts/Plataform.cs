using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour {
	void Update (){
		if (gameObject.GetComponent<Rigidbody> () != null && gameObject.GetComponent <Rigidbody>().velocity.y == 0) {
			gameObject.GetComponent <Rigidbody> ().velocity = Vector3.zero;
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.transform.tag.Equals("Player") && gameObject.GetComponent<Rigidbody> () == null) {
			gameObject.AddComponent<Rigidbody> ();
			gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
		}
	}
}
