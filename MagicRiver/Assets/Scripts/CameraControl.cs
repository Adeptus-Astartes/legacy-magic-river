using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public Transform target;
	public float height;
	public float offsetZ;


	void LateUpdate () 
	{
		if(target)
		transform.position = new Vector3(target.position.x,target.position.y + height, target.position.z + offsetZ);
	
	}
}
