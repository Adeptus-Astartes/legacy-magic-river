using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour 
{
	public WorldGeneration world;
	public string name = "";
	void Start () 
	{
		if(name == "L")
		{
			MakeLeft();
		}
		if(name == "R")
		{
			MakeRight();
		}
		if(name == "C")
		{
			MakeCental();
		}
	
	}

	void MakeRight()
	{
		Vector3 pos = new Vector3(transform.position.x + 15,transform.position.y ,transform.position.z);
		
		Quaternion angle = Quaternion.identity;
		angle.eulerAngles = new Vector3(-90,0,0);
		
		GameObject shore = Instantiate(world.prefabs.shores[Random.Range(0,world.prefabs.shores.Count - 1)], pos,angle) as GameObject;
		shore.transform.parent = transform;
		
		//Spawn Tree
		int rnd = Random.Range(0,20);
		if(rnd > 0 && rnd < 15)
		{
			Vector3 tree_pos = new Vector3(transform.position.x + Random.Range(7,1),transform.position.y + 3.2f,transform.position.z);
			
			Quaternion tree_angle = Quaternion.identity;
			tree_angle.eulerAngles = new Vector3(-90 + Random.Range(-3,3),Random.Range(-180,180),0);
			
			GameObject tree = Instantiate(world.prefabs.trees[Random.Range(0,world.prefabs.trees.Count - 1)], tree_pos,tree_angle) as GameObject;
			tree.transform.parent = transform;
		}
		
		
		//Spawn Pierce
		
		int rand = Random.Range(0,20);
		if(rand > 0 && rand < 5)
		{
			Vector3 pierce_pos = new Vector3(transform.position.x - 1.5f,1,transform.position.z);
			
			Quaternion pierce_angle = Quaternion.identity;
			pierce_angle.eulerAngles = new Vector3(-90 + Random.Range(-3,3),Random.Range(-10,10),0);
			
			GameObject pierce = Instantiate(world.prefabs.pierce, pierce_pos,pierce_angle) as GameObject;
			pierce.transform.parent = transform;
		}

	}

	void MakeLeft()
	{
		
		//Spawn Shore
		Vector3 pos = new Vector3(transform.position.x - 15,transform.position.y,transform.position.z);
		
		Quaternion angle = Quaternion.identity;
		angle.eulerAngles = new Vector3(-90,180,0);
		
		GameObject shore = Instantiate(world.prefabs.shores[Random.Range(0,world.prefabs.shores.Count - 1)], pos,angle) as GameObject;
		shore.transform.parent = transform;
		//Spawn Tree
		int rnd = Random.Range(0,20);
		if(rnd > 0 && rnd < 15)
		{
			Vector3 tree_pos = new Vector3(transform.position.x + Random.Range(-7,-1),transform.position.y + 3.2f,transform.position.z);
			
			Quaternion tree_angle = Quaternion.identity;
			tree_angle.eulerAngles = new Vector3(-90 + Random.Range(-3,3),Random.Range(-180,180),0);
			
			GameObject tree = Instantiate(world.prefabs.trees[Random.Range(0,world.prefabs.trees.Count - 1)], tree_pos,tree_angle) as GameObject;
			tree.transform.parent = transform;
		}
		
		
		//Spawn Pierce
		
		int rand = Random.Range(0,20);
		if(rand > 0 && rand < 5)
		{
			Vector3 pierce_pos = new Vector3(transform.position.x + 1.5f,1,transform.position.z);
			
			Quaternion pierce_angle = Quaternion.identity;
			pierce_angle.eulerAngles = new Vector3(-90 + Random.Range(-3,3),Random.Range(170,190),0);
			
			GameObject pierce = Instantiate(world.prefabs.pierce, pierce_pos,pierce_angle) as GameObject;
			pierce.transform.parent = transform;
		}

	}

	void MakeCental()
	{
		int rnd = Random.Range(0,30);
		if(rnd > 0 && rnd < 10)
		{
			Vector3 pos = new Vector3(transform.position.x + Random.Range(-10,10),transform.position.y + 0.1f,transform.position.z + Random.Range(-transform.localScale.z/2,transform.localScale.z/2));
			
			Quaternion angle = Quaternion.identity;
			angle.eulerAngles = new Vector3(-90,Random.Range(0,360),0);
			
			GameObject shore = Instantiate(world.prefabs.lily, pos,angle) as GameObject;
			shore.transform.parent = transform;
		}

		int count = Random.Range(1,3);
		for(int i = 0;i<count;i++)
		{
			Vector3 pos = new Vector3(transform.position.x + Random.Range(-10,10),transform.position.y,transform.position.z + Random.Range(-transform.localScale.z/2,transform.localScale.z/2));
			
			Quaternion angle = Quaternion.identity;
			angle.eulerAngles = new Vector3(0,Random.Range(0,360),0);
			
			GameObject shore = Instantiate(world.prefabs.rocks[Random.Range(0,world.prefabs.rocks.Count - 1)], pos,angle) as GameObject;
			shore.transform.parent = transform;
		}
	}
}
