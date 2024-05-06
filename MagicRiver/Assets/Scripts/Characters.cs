using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Character
{
	public GameObject parent;
	public Sprite spr;
	public string key;
}


public class Characters : MonoBehaviour 
{
	public List<Character> characters;

	void Awake () 
	{
		foreach(Character _char in characters)
		{

		}
	}

}
