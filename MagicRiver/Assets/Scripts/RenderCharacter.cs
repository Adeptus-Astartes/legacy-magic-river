using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
public class RenderCharacter : MonoBehaviour 
{
	public Camera virtuCamera;
	public List<GameObject> characters;
	public int size = 1024;

	string path = "";

	void Awake()
	{
		foreach(Transform obj in transform)
		{
			obj.gameObject.SetActive(false);
			characters.Add(obj.gameObject);
		}
	}


	void Start()
	{
		/*
		path = EditorUtility.OpenFolderPanel("Select Folder","","");
		for(int i = 0;i<characters.Count;i++)
		{
			MakeSquarePngFromOurVirtualThingy(characters[i]);
		}
*/

	}

	public void MakeSquarePngFromOurVirtualThingy(GameObject currentObject)
	{
		// capture the virtuCam and save it as a square PNG.
		currentObject.SetActive(true);
		int sqr = size;
		
		//virtuCamera.aspect = 1.0f;
		// recall that the height is now the "actual" size from now on
		// the .aspect property is very tricky in Unity, and bizarrely is NOT shown in the editor
		// the editor will still incorrectly show the frustrum being screen-shaped
		
		RenderTexture tempRT = new RenderTexture(sqr,sqr, 24 );
		// the "24" can be 0,16,24 or formats like RenderTextureFormat.Default, ARGB32 etc.
		
		virtuCamera.targetTexture = tempRT;
		virtuCamera.Render();
		
		RenderTexture.active = tempRT;
		Texture2D virtualPhoto = new Texture2D(sqr,sqr, TextureFormat.ARGB32, false);
		// false, meaning no need for mipmaps
		virtualPhoto.ReadPixels( new Rect(0, 0, sqr,sqr), 0, 0); // you get the center section
		
		RenderTexture.active = null; // "just in case" 
		virtuCamera.targetTexture = null;
		//////Destroy(tempRT); - tricky on android and other platforms, take care
		
		byte[] bytes;
		bytes = virtualPhoto.EncodeToPNG();
		
		System.IO.File.WriteAllBytes( OurTempSquareImageLocation(currentObject.name), bytes );
		// virtualCam.SetActive(false); ... not necesssary but take care
		
		// now use the image somehow...
		//YourOngoingRoutine( OurTempSquareImageLocation() );
		currentObject.SetActive(false);
	}
	private string OurTempSquareImageLocation(string name)
	{
	
		string r = path + "/" + name + ".png";
		return r;
	}
}
