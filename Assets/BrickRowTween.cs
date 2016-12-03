using UnityEngine;
using System.Collections;

public class BrickRowTween : MonoBehaviour 
{
	public float delaySeconds = 0f;

	private Animator animator;
	private float timePassed = 0f;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();

		// Old way
		//StartCoroutine (TweenIn());

	}

	void Update()
	{
		timePassed += Time.deltaTime;

		if (timePassed >= delaySeconds) 
		{
			animator.SetTrigger ("tweenInTrigger");
		}
	}

	IEnumerator TweenIn()
	{
		yield return new WaitForSeconds (delaySeconds);
		animator.SetTrigger ("tweenInTrigger");
	}

}
