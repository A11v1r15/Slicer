using UnityEngine;
using System.Collections;

public class Cam : MonoBehaviour {
	public Color color1 = Color.red;
	public Color color2 = Color.cyan;

	Camera camera;

	void Start() {
		camera = GetComponent<Camera>();
		camera.clearFlags = CameraClearFlags.SolidColor;
	}

	void Update() {
		int time = System.DateTime.Now.Millisecond + System.DateTime.Now.Second * 1000 + System.DateTime.Now.Minute * 60000 + System.DateTime.Now.Hour * 3600000;
		float t = Mathf.PingPong(Time.time, time) / time;
		camera.backgroundColor = Color.Lerp(color1, color2, t);
	}
}