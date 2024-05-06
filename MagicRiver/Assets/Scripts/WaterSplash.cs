using UnityEngine;
using System.Collections;

public class WaterSplash : MonoBehaviour 
{
	public bool forward = false;
	public bool backward = false;
	public RectTransform waterLine;
	public AnimationCurve curve;
	public float speed;
	float time = 0.0f;
	RectTransform rect;


	// Use this for initialization
	void Start () 
	{
		rect = this.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(forward)
		{
			time += Time.deltaTime;
			waterLine.anchoredPosition = new Vector2(Mathf.Lerp(-200,200,time),waterLine.anchoredPosition.y);
			rect.sizeDelta = new Vector2(Screen.width,Mathf.Lerp(-25,Screen.height + 50,curve.Evaluate(time)));
			if(time > 1)
			{
				forward = false;
				time = 0;
			}
		}
		if(backward)
		{
			time += Time.deltaTime;
			waterLine.anchoredPosition = new Vector2(Mathf.Lerp(-200,200,time),waterLine.anchoredPosition.y);
			rect.sizeDelta = new Vector2(Screen.width,Mathf.Lerp(Screen.height + 50,-50,curve.Evaluate(time)));
			if(time > curve.keys[curve.keys.Length-1].time)
			{
				backward = false;
				time = 0;
			}
		}
	
	}
}
