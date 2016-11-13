using UnityEngine;
using System.Collections;

public class ContinueButton : MonoBehaviour 
{
	public float yPos = 10f;
	
	private Vector3 startPos;
	
	// Use this for initialization
	void Start () 
	{
		startPos = transform.position;
	}
	
	public void LoadNextLevel()
	{
		HideContinueButton();
		FindObjectOfType<LevelManager>().LoadNextLevel();
	}
	public void ShowContinueButton()
	{
		GetComponent<Transform>().position = new Vector3(transform.position.x, yPos, transform.position.z);
	}
	
	public void HideContinueButton()
	{
		GetComponent<Transform>().position = new Vector3(transform.position.x, 34f, transform.position.z);
	}
}
