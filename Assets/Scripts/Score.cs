using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public int score = 0;
	private System.DateTime initial;
	private System.TimeSpan delta;
	private UnityEngine.UI.Text canvas;
	public static int died;

	// Use this for initialization
	void Start () {
		initial = System.DateTime.Now;
		canvas = GameObject.Find ("Canvas").GetComponentInChildren<Text> ();
		died = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!PlataformGenerator.GameOver.activeSelf) {
			delta = initial - System.DateTime.Now;
			canvas.text = ((int)delta.Duration ().TotalSeconds).ToString () + "s\n" + died.ToString() + "p";
		}
	}
}
