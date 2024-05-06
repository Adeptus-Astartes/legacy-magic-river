using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Prefabs
{
	public List<GameObject> shores;

	public List<GameObject> trees;

	public List<GameObject> rocks;

	public List<GameObject> cuttedTrees;

	public GameObject pierce;
	public GameObject home;
	public GameObject lily;

}


public class WorldGeneration : MonoBehaviour 
{
	public UIManager manager;
	public Prefabs prefabs;

	public GameObject water;

	public Transform player;
	public GameObject primitiveBase;
	public Transform temp;
	public Vector3 offsetC;
	public Vector3 offsetR;
	public Vector3 offsetL;

	void Start()
	{
		if(!player)
		{
			Debug.Log("CritError: Setup player var!,WorldGeneration.cs cant work");
			this.enabled = false;
		}

		FirstBuild();
	}

	void Update()
	{
		transform.position = player.position;
	}


	public void FirstBuild()
	{
		//SpawnWater
		GameObject _water = Instantiate(water,Vector3.zero,Quaternion.identity) as GameObject;
		_water.GetComponent<FollowCam>().target = Camera.main.transform;

		//BuildCentral
		for(int i = 0; i < 20; i++)
		{
			if(i>5)
                BuildCentral();
			else
				offsetC.z += Random.Range(5,15);
		}
		//Left
		for(int i = 0; i < 20; i++)
		{
			BuildLeft();
		}
		//Right
		for(int i = 0; i < 20; i++)
		{
			BuildRight();
		}

	}

	void BuildCentral()
	{
		float scale = Random.Range(5,15);
		CreatePrimitive(offsetC, new Vector3(20,1,scale), "C");
		offsetC.z += scale;
	}
	void BuildRight()
	{
		float scale = 10;//Random.Range(5,15);
		offsetR.x = -10;
		CreatePrimitive(offsetR, new Vector3(10,1,scale), "L");
		offsetR.z += scale;
	}
	void BuildLeft()
	{
		float scale = 10;//Random.Range(5,15);
		offsetL.x = 10;
		CreatePrimitive(offsetL, new Vector3(10,1,scale), "R");
		offsetL.z += scale;
	}

	void MainBuild()
	{

	}

	void CreatePrimitive(Vector3 position, Vector3 scale,string name)
	{
		GameObject myPrimitive = Instantiate(primitiveBase,position,Quaternion.identity) as GameObject;
		myPrimitive.name = name;
		//myPrimitive.transform.localScale = scale;
		//myPrimitive.transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),Random.Range(0.0F,1.0F),0.01F);
		myPrimitive.transform.parent = temp;

		Platform platform = myPrimitive.AddComponent<Platform>();
		platform.world = this;
		platform.name = name;

	
	}

	void OnTriggerExit(Collider other)
	{
		if(other.name.Contains("R"))
		{
			BuildRight();
		}
		if(other.name.Contains("C"))
		{
			BuildCentral();
		}		
		if(other.name.Contains("L"))
		{
			BuildLeft();
		}
		Destroy(other.gameObject);

	}
}
