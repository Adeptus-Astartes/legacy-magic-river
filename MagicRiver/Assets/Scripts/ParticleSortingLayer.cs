using UnityEngine;
using System.Collections;

public class ParticleSortingLayer : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerID = spriteRenderer.sortingLayerID;
		GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = spriteRenderer.sortingOrder;
	}
	/*
	void Start ()
	{

		//Change Foreground to the layer you want it to display on 
		//You could prob. make a public variable for this
		//GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "2DPARTICLE";
	}*/
}
