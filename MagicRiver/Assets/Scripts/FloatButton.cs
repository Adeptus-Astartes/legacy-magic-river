using UnityEngine;
using System.Collections;

public class FloatButton : MonoBehaviour 
{
	public AnimationCurve forward;
	public AnimationCurve backward;

	public bool rotate = true;
	float speed = 1;
	AnimationCurve curve;

	bool move = false;
	RectTransform rectT;

	float originalHeight;
	float originalRot;

	float aHeight;

	float targetHeight;
	float aRot;
	float targetRot;


	float time;

	void OnEnable () 
	{
		rectT = this.GetComponent<RectTransform>();
		originalHeight = rectT.anchoredPosition.y;
		originalRot = rectT.eulerAngles.z;
	}

	public void DoTween(bool direction)
	{
		if(direction)
		{
			curve = forward;
			speed = 0.5f;
			aHeight = originalHeight + Screen.height + Random.Range(0,300);
			targetHeight = originalHeight;
			aRot = Random.Range(-180,180);
			targetRot = originalRot;
			move = true;
		}
		else
		{   
			curve = backward;
			aHeight = originalHeight;
			targetHeight = originalHeight- Screen.height - Random.Range(0,300);;
			aRot = originalRot;
			targetRot = originalRot + Random.Range(-180,180);
			move = true;
		}
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			DoTween(true);
		}
		if(move)
		{
			time += Time.deltaTime * speed;
			rectT.anchoredPosition = new Vector2(rectT.anchoredPosition.x,Mathf.Lerp(aHeight,targetHeight,curve.Evaluate(time)));
			if(rotate)
			rectT.rotation = Quaternion.Euler(0,0,Mathf.LerpAngle(aRot,targetRot,time));
			if(time > forward.keys[forward.keys.Length-1].time)
			{
				move = false;
				time = 0;
			}
		}
	

	}
}
