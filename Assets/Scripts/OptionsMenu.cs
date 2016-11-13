using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour 
{
	public Text BallCount;
	 
	private Animator anim;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponentInParent<Animator>();
		Debug.Log("Options menu animator: " + anim);
	}
	public int Test()
	{
		return 0;
	}
	
	public void OptionsSlideDown()
	{
		// BallCount.text = FindObjectsOfType<Ball>().Length.ToString();
		BallCount.text = Ball.count.ToString();
		anim.SetBool("SlideInMenu",true);
	}
	
	public void OptionsSlideUp()
	{
		anim.SetBool("SlideInMenu",false);
	}
	
	public void PauseGame()
	{
		Time.timeScale = 0f;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1f;
	}
}
