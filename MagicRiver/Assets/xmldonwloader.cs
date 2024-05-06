using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
public class xmldonwloader : MonoBehaviour {
	public string url;
	public string data;
	public List<string> ccy;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(donwload());

	}
	public IEnumerator donwload()
	{
		WWW www = new WWW(url);
	
		while(!www.isDone)
			yield return null;

		data = www.text;
		Read();

	}

	void Read()
	{
	    XmlTextReader	reader = new XmlTextReader(new StringReader(data));
		while(reader.Read())
		{
			if(reader.Name == "exchangerate")
			{
				ccy.Add(reader.GetAttribute("ccy") + " <-> " + reader.GetAttribute("base_ccy") + " BUY " + reader.GetAttribute("buy") + " SALE " + reader.GetAttribute("sale"));	
			}
		}
	}

	void OnGUI()
	{
		foreach(string value in ccy)
		{
			GUILayout.Label(value);
		}
	}

}
