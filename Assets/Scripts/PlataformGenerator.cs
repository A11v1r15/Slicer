using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlataformGenerator: MonoBehaviour {

	public Transform StartPlataformGenerator;
	public float speed = 50f;
	GameObject NewPlataform;
	GameObject Player;
	GameObject LastMonster;
	System.Random random = new System.Random();

	int ChildCount;
	Vector3 EndPosition;
	Vector3 EndPosAdjust = new Vector3(1f,0,0);

	void Start () 
	{
		NewPlataform = Instantiate(Resources.Load("Prefabs/plataforms/Plat1") as GameObject,StartPlataformGenerator.position,Quaternion.identity) as GameObject;
		Player = Instantiate(Resources.Load("Prefabs/characters/Player1") as GameObject,StartPlataformGenerator.position + new Vector3(0, 3f, 0),Quaternion.identity) as GameObject;
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
				if (EndPosition.x < 100f)
				{
					NewPlataform = Instantiate(newPlataform(),EndPosition,Quaternion.identity) as GameObject;
				}

				foreach (var plataforma in GameObject.FindGameObjectsWithTag("Plataforma"))
				{
					plataforma.transform.Translate(-speed*Time.deltaTime,0,0);

				if ( plataforma.transform.position.x < -100f || plataforma.transform.position.y < -50f )
					{
						Destroy(plataforma);
					}
				} 

			if(Mathf.Sin(Time.time) > 0){
				LastMonster = Instantiate(Resources.Load("Prefabs/characters/Monster1") as GameObject,EndPosition + new Vector3(0, 3f, 0),Quaternion.identity) as GameObject;
			}	

				foreach (var monster in GameObject.FindGameObjectsWithTag("Monster"))
				{
					monster.transform.Translate(-speed*Time.deltaTime,0,0);

					if ( monster.transform.position.x < -100f || monster.transform.position.y < -50f )
					{
						Destroy(monster);
					}
				} 

			}
			catch(MissingReferenceException){}
	}

	GameObject newPlataform()
	{
		return Resources.Load("Prefabs/plataforms/Plat"+random.Next(1,4).ToString()) as GameObject;
	}


}
