using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterGenerator: MonoBehaviour {
	GameObject LastMonster;
	System.Random random = new System.Random();

	void Start()
	{
		StartCoroutine("MyEvent");
	}
	 
	private IEnumerator MyEvent()
	{
		while(true)
		{
			yield return new WaitForSeconds(0.5f); // wait half a second
			if(Mathf.Sin(Time.time) > 0){
				LastMonster = Instantiate(Resources.Load("Prefabs/characters/Monster1") as GameObject, PlataformGenerator.EndPosition + new Vector3(0, 3f, 0),Quaternion.identity) as GameObject;
			}
		}
	}
	
	void Update()
	{
		try{	

			foreach (var monster in GameObject.FindGameObjectsWithTag("Monster"))
			{
				monster.transform.Translate(-PlataformGenerator.speed * Time.deltaTime * 1.25f , 0 , 0);

				if ( monster.transform.position.x < -100f || monster.transform.position.y < -20f )
				{
					Destroy(monster);
				}
			} 

		}
		catch(MissingReferenceException){}
	}

}
