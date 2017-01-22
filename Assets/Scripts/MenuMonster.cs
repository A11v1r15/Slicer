using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMonster : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.transform.localScale = new Vector3(0.5f, 0.35f + Mathf.Sin (Time.time + this.transform.position.x) * 0.075f, 0.5f);
		this.GetComponent<SphereCollider> ().radius = this.transform.localScale.y * 1.56f;
	}
}
