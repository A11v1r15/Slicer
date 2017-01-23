using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlataformGenerator: MonoBehaviour {

	public Transform StartPlataformGenerator;
	public static float speed = 3f;
	public static GameObject GameOver;
	GameObject NewPlataform;
	GameObject Player;
	System.Random random = new System.Random();

	int ChildCount;
	public static Vector3 EndPosition;
	Vector3 EndPosAdjust = new Vector3(1f,0,0);

	void Start () 
	{
		NewPlataform = Instantiate(Resources.Load("Prefabs/plataforms/Plat1") as GameObject,StartPlataformGenerator.position,Quaternion.identity) as GameObject;
		Player = Instantiate(Resources.Load("Prefabs/characters/Player1") as GameObject,StartPlataformGenerator.position + new Vector3(0, 5f, 0.5f),Quaternion.identity) as GameObject;
		GameOver = GameObject.Find ("GameOver");
		GameOver.SetActive (false);
	}
	void Update()
	{
		if (!PlataformGenerator.GameOver.activeSelf) {
			try {
				ChildCount = NewPlataform.transform.childCount;
				for (int i = 0; i < ChildCount; i++) {
					if (NewPlataform.transform.GetChild (i).name == "End") {
						EndPosition = NewPlataform.transform.GetChild (i).position + EndPosAdjust;
						break;
					}
				}
				if (EndPosition.x < 30f) {
					NewPlataform = Instantiate (newPlataform (), EndPosition, Quaternion.identity) as GameObject;
				}

				foreach (var plataforma in GameObject.FindGameObjectsWithTag("Plataforma")) {
					plataforma.transform.Translate (-speed * Time.deltaTime, 0, 0);

					if (plataforma.transform.position.x < -35f || plataforma.transform.position.y < -20f) {
						Destroy (plataforma);
					}
				} 

			} catch (MissingReferenceException) {
			}
		} else
		foreach (var plataforma in GameObject.FindGameObjectsWithTag("Plataforma")) {
					if (this.gameObject.GetComponent<Rigidbody> () == null) {
						plataforma.gameObject.AddComponent<Rigidbody> ();
						plataforma.gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
					}
				}
	}

	void Restart(){ //E eu vou te esperar...
		SceneManager.LoadScene ("menu");
	}

	GameObject newPlataform()
	{
		return Resources.Load("Prefabs/plataforms/Plat"+random.Next(1,5).ToString()) as GameObject;
	}


}
