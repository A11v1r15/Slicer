using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localScale = new Vector3(1f, 0.85f + Mathf.Sin (Time.time + this.transform.position.x) * 0.075f, 1f);
	}
}
