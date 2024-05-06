using UnityEngine;
using System.Collections;

public class Jem : MonoBehaviour 
{
	public GameObject deadEffect;
	public GameObject glow;
	public Transform mesh;

	void Enable()
	{
		glow.SetActive(true);
	}

	void Update ()
	{
	
	}

	void Dead()
	{
		Instantiate(deadEffect,transform.position,transform.rotation);
		Destroy(gameObject);
	}

}
