using UnityEngine;
using System.Collections;

public class BrickRowTween : MonoBehaviour 
{
	public float delaySeconds = 0f;

	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator> ();

		StartCoroutine (TweenIn());
	}

	IEnumerator TweenIn()
	{
		yield return new WaitForSeconds (delaySeconds);
		animator.SetTrigger ("tweenInTrigger");
	}
}
