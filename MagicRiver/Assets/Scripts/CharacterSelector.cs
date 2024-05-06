using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MyCharacter
{
	public string name;
	public bool unclocked = true;
	public string secretKey = "EnterSecretKey";
	public UIChar button;
	public GameObject mesh;
}

public class CharacterSelector : MonoBehaviour 
{
	public UIManager manager;
	public PlayerShip character;
	public Transform root;
	public GameObject uiBase;
	public int unclockedPremChars = 0;
	public List<MyCharacter> characters;
	public List<MyCharacter> premiumCharacters;

	public bool resetProgress = false;

	void Awake()
	{
		if(resetProgress)
		{
			SPlayerPrefs.DeleteAll();
		}
		Spawn(PlayerPrefs.GetInt("SavedCharId"));
		LoadCharacters();
	}

	//MERCENARY

	void LoadCharacters()
	{
		for(int i = 0; i<characters.Count; i++)
		{
			if(i == 0)
			{
				SPlayerPrefs.SetString(characters[i].secretKey,"+");
			}
			else
			{
				if(SPlayerPrefs.GetString(characters[i].secretKey) == "+")
				{
					characters[i].unclocked = true;
				}
			    else
				{
					characters[i].unclocked = false;
				}

			}
			LockUnlock(characters[i].unclocked, characters[i].button);
		}
		for(int i = 0; i<premiumCharacters.Count; i++)
		{
			if(SPlayerPrefs.GetString(premiumCharacters[i].secretKey) == "+")
			{
				premiumCharacters[i].unclocked = true;
				unclockedPremChars ++;
			}
			else
			{
				premiumCharacters[i].unclocked = false;
			}
		}
	}

	void LockUnlock(bool status,UIChar _character)
	{
		if(!status)
		{
			_character.name.gameObject.SetActive(false);
			_character.spr.gameObject.SetActive(false);
			_character.locked.SetActive(true);
		}
		else
		{
			_character.name.gameObject.SetActive(true);
			_character.spr.gameObject.SetActive(true);
			_character.locked.SetActive(false);
		}
	}

	bool repeat = false;

	void Buy()
	{
		int rnd = Random.Range(0,characters.Count);
		if(characters[rnd].unclocked)
		{
			repeat = true;
		}
		else
		{
			repeat = false;
			SPlayerPrefs.SetString(characters[rnd].secretKey,"+");
			LoadCharacters();
			manager.CharacterBuyed(rnd,characters[rnd].button.spr.sprite);
			PlayerPrefs.SetInt("SavedCharId",rnd);
		}
	}

	void Update()
	{
		if(repeat)
		{
			Buy ();
		}
	}

	public void SelectCharacter(int id)
	{
		if(characters[id].unclocked)
		{
	    	manager.clips[0].Play();
	    	Spawn(id);
		}
		else
		{

		}
	}

	public void Spawn (int i)
	{
		int rnd = -1; 
		if(i == -1)
		    rnd = Random.Range(0,characters.Count);
		else
			rnd = i;
		GameObject spawned_character = Instantiate(characters[rnd].mesh,character.transform.position,Quaternion.identity) as GameObject;
		spawned_character.transform.parent = character.transform;
		if(character.mesh)
			Destroy(character.mesh.gameObject);
		character.mesh = spawned_character.transform;
		character.animator = spawned_character.GetComponent<Animator>();
		character.enabled = false;
	}

}
