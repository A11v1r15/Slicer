using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour {
	void Update (){
		if (this.gameObject.GetComponent<Rigidbody> () != null && Mathf.Abs(this.gameObject.GetComponent <Rigidbody>().velocity.y) < 0.1f) {
			this.gameObject.GetComponent <Rigidbody> ().velocity = Vector3.zero;
		}
	}

	void OnMouseDown () {
		if (this.gameObject.GetComponent<Rigidbody> () == null) {
			this.gameObject.AddComponent<Rigidbody> ();
			this.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
		}
		else
			this.gameObject.GetComponent <Rigidbody>().velocity = Vector3.up*10;
	}
}
