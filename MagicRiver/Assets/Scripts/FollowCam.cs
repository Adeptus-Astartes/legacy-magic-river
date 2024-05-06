using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public Transform target;
	public float offset;
	void Update () 
	{
		transform.position = new Vector3(0,0,target.position.z + offset);
	}
}
