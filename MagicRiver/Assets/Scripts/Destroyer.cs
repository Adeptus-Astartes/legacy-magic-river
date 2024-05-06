using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
	public float lifeTime = 2;

	void Update () 
	{
		lifeTime -= Time.deltaTime;
		if(lifeTime < 0)
		{
			Destroy(gameObject);
		}
	}
}
