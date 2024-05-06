using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Lily : MonoBehaviour 
{
	public Transform target;
	public List<Transform> diamonds;
	public GameObject collectEffect;
	void UpdateTarget(Transform newTarget)
	{
		target = newTarget;
	}

	void Update()
	{
		if(target)
		{
			//collectEffect.SetActive(true);
			foreach(Transform diam in diamonds)
			{
				diam.gameObject.SetActive(false);
			}
		
		}
	}
	
}
