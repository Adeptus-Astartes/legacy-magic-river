using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour 
{
	bool live = true;
	public UIManager manager;
	public Transform mesh;
	public Animator animator;
	public float maxAngle;
	float currentAngle;
	public float turnSpeed = 1f;
    float turnTime;
	bool forward = true;
	bool direction = false; //if false - left | true - right

	public float forwardSpeed;
	public float sideSpeed;
	float currentSteer;
	float steerTime = 0;

	[Header("Particles")]
	[HideInInspector]
	public GameObject fullSplash;
	[HideInInspector]
	public Transform spawnPoint;
	public GameObject selfSplash;

	bool enableDelay = false;
	float delay;

	void Start()
	{
		live = true;
		if(mesh)
		{
		    if(!fullSplash)
			{
				fullSplash = mesh.Find("Armature/Bone_007/SplashFull").gameObject;
			}
			if(!spawnPoint)
			{
				spawnPoint = mesh.Find("Armature/Bone_006/Bone_004/Bone_005/SpawnPoint");
			}

		}
	}

	void Update () 
	{

	   	//Control
     	 if(Input.GetMouseButtonDown(0))
		 {
			//Enable Delayed Spawn
			if(!enableDelay)
			{
			enableDelay = true;
			delay = 0;
			}

			if(forward)
				forward = false;

			if(direction)
			{
				if(manager.gameStart)
				manager.clips[2].PlayDelayed(0.1f);
				animator.SetTrigger("Right");
				direction = false;
			}
			else
			{
				if(manager.gameStart)
				manager.clips[3].PlayDelayed(0.1f);
				animator.SetTrigger("Left");
				direction = true;
			}
			steerTime = 0;
			turnTime = 0;
    	}
		//Do Delay Spawn
		if(enableDelay)
		{
			delay += Time.deltaTime;
			if(delay > 0.3f)
			{
				Instantiate(selfSplash,spawnPoint.position,Quaternion.identity);
				enableDelay = false;
			}
		}

		if(forward)
		{

		}
		else
		{
			if(direction)
			{
				if(steerTime < 1)
					steerTime += Time.deltaTime * turnSpeed;

				currentSteer = Mathf.Lerp(currentSteer,1,steerTime);
				if(mesh.localEulerAngles.y != maxAngle)
				{
			    	currentAngle = Mathf.LerpAngle(mesh.localEulerAngles.y,maxAngle,turnTime);
					turnTime += Time.deltaTime * turnSpeed;
				}
			}
			else
			{
				if(steerTime < 1)
					steerTime += Time.deltaTime * turnSpeed;
				
				currentSteer = Mathf.Lerp(currentSteer,-1,steerTime);
				if(mesh.localEulerAngles.y != - maxAngle)
				{
					currentAngle = Mathf.LerpAngle(mesh.localEulerAngles.y,-maxAngle,turnTime);
					turnTime += Time.deltaTime * turnSpeed;
				}
			}
		}
		//Move character if they live
		if(live)
		{
		    mesh.localEulerAngles = new Vector3(mesh.localEulerAngles.x, currentAngle, mesh.localEulerAngles.z);
			transform.Translate(transform.right * sideSpeed * currentSteer * Time.deltaTime);
			transform.Translate(transform.forward * forwardSpeed * Time.deltaTime);
		}

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Block")
		{
			print("DEAD!");
			live = false;
			manager.dead = true;
			animator.SetTrigger("Dead");
			fullSplash.SetActive(true);
		}
		if(other.tag == "Lily")
		{

			other.SendMessage("UpdateTarget",transform);
			manager.clips[1].Play();

			int coins = SPlayerPrefs.GetInt("gdfhkqiitizn@5i8gdf8sjHHBBMASklkfsh");
			SPlayerPrefs.SetInt("gdfhkqiitizn@5i8gdf8sjHHBBMASklkfsh",coins + 3);
		}
		if(other.tag == "Jem")
		{
			other.SendMessage("Dead");
		}
	}
}
