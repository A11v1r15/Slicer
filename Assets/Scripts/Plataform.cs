using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour {
	void OnMouseDown () {
		if(this.gameObject.GetComponent<Rigidbody> () == null)
			this.gameObject.AddComponent<Rigidbody> ();
	}
}
