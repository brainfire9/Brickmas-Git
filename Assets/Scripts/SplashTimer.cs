using UnityEngine;
using System.Collections;

public class SplashTimer : MonoBehaviour 
{
	public float seconds = 0.0f;
	
	private LevelManager levelManager;
	
	// Use this for initialization
	void Start () 
	{
		levelManager = FindObjectOfType<LevelManager>().GetComponent<LevelManager>();
		
		StartCoroutine("Pause");	
	}
	
	IEnumerator Pause()
	{
		Debug.Log("Waiting for " + seconds + "seconds at " + Time.time);
		yield return new WaitForSeconds(seconds);
		Debug.Log("Time is now " + Time.time);
		levelManager.LoadNextLevel();
	}
}
