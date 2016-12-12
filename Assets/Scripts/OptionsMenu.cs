using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour 
{
	public Text BallCount;
	public GameObject helpMenuPrefab;
	public Vector3 helpMenuLocation;
	 
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

	public void HelpMenuSlideIn()
	{
		// Old way of doing things
		//Debug.Log ("Help prefab is " + helpMenuPrefab);
		//GameObject helpMenu = Instantiate (helpMenuPrefab, helpMenuLocation, Quaternion.identity) as GameObject;
		FindObjectOfType<HelpMenu>().Show();
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
