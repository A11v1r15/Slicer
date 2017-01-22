using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlataformGenerator: MonoBehaviour {

	public Transform StartPlataformGenerator;
	public static float speed = 3f;
	GameObject NewPlataform;
	GameObject Player;
	System.Random random = new System.Random();

	int ChildCount;
	public static Vector3 EndPosition;
	Vector3 EndPosAdjust = new Vector3(1f,0,0);

	void Start () 
	{
		NewPlataform = Instantiate(Resources.Load("Prefabs/plataforms/Plat1") as GameObject,StartPlataformGenerator.position,Quaternion.identity) as GameObject;
		Player = Instantiate(Resources.Load("Prefabs/characters/Player1") as GameObject,StartPlataformGenerator.position + new Vector3(0, 3f, 0),Quaternion.identity) as GameObject;
		GameObject.Find ("Canvas").transform.GetChild (0).GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
		GameObject.Find ("Canvas").transform.GetChild (0).GetComponent<Button>().onClick.AddListener(() => Restart());
	}
	void Update()
	{
			try{
				ChildCount = NewPlataform.transform.childCount;
				for (int i=0; i<ChildCount; i++)
				{
					if (NewPlataform.transform.GetChild(i).name == "End")
					{
						EndPosition = NewPlataform.transform.GetChild(i).position + EndPosAdjust;
						break;
					}
				}
				if (EndPosition.x < 30f)
				{
					NewPlataform = Instantiate(newPlataform(),EndPosition,Quaternion.identity) as GameObject;
				}

				foreach (var plataforma in GameObject.FindGameObjectsWithTag("Plataforma"))
				{
					plataforma.transform.Translate(-speed*Time.deltaTime,0,0);

				if ( plataforma.transform.position.x < -100f || plataforma.transform.position.y < -20f )
					{
						Destroy(plataforma);
					}
				} 

			}
			catch(MissingReferenceException){}
	}

	void Restart(){ //E eu vou te esperar...
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	GameObject newPlataform()
	{
		return Resources.Load("Prefabs/plataforms/Plat"+random.Next(1,5).ToString()) as GameObject;
	}


}
