using UnityEngine;
using System.Collections;

public class Messenger : MonoBehaviour {
	public AnimationCurve curve;
	float time ;

	public bool activate = false;
	// Use this for initialization
	RectTransform rectT;

	void Start () 
	{
		rectT = this.GetComponent<RectTransform>();
	}

	public void Activate()
	{
		activate = true;
	}


	void Update () 
	{
    	if(activate)
		{
			time += Time.deltaTime;
			rectT.anchoredPosition = new Vector2(rectT.anchoredPosition.x,curve.Evaluate(time));
			if(time > curve.keys[curve.keys.Length-1].time)
			{
				activate = false;
			}
		}
	}
}
