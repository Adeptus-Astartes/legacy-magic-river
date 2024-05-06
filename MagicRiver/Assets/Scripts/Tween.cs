using UnityEngine;
using System.Collections;
public enum TweenType {Moving, Rotating};
public class Tween : MonoBehaviour {

	public TweenType type;
	public AnimationCurve curve;
	public float speed;
	private float currentTime = 0;
	private float maxTime = 0;
	private bool tweenStart = false;

	void Start()
	{
		maxTime = curve.keys[curve.keys.Length - 1].time;
		StartTween(false);
	}

	public void StartTween(bool inverse)
	{
		tweenStart = true;	
		currentTime = 0;
	}

	private void Update()
	{
		if(tweenStart)
		{
			currentTime += Time.deltaTime/speed;
			if(currentTime > maxTime)
			{	   
		        tweenStart = false;

			}

			if(type == TweenType.Moving)
			{
				transform.position = new Vector3(transform.position.x,curve.Evaluate(currentTime),transform.position.z);
			}
			if(type == TweenType.Rotating)
			{
				transform.eulerAngles = new Vector3(transform.position.x,transform.position.y,curve.Evaluate(currentTime));
			}

		}

	}

	public void EndTween()
	{

	}
}
