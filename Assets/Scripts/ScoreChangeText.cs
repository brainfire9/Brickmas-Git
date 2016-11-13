using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreChangeText : MonoBehaviour 
{
	private Text scoreChangeText;
	private int change = 0;
//	private GameManager gameManager;
	
	// Use this for initialization
	void Start () 
	{
		scoreChangeText = GetComponent<Text>();
		UpdateScore(0);
	}
	
	public void ChangeInt(int changeInt)
	{
		change = changeInt;
	}
	// Update is called once per frame
	public void UpdateScore (int scoreChange) 
	{
		string scoreString;
		Debug.Log ("Scorechnage is " + scoreChange);
		Debug.Log("ChangeInt = " + change);
		
		if (scoreChangeText == null)
		{
			Debug.LogWarning("scoreChange instance is null!");
			scoreChangeText = GetComponent<Text>();
			Debug.Log("scoreChange now " + scoreChangeText);
		}
		Debug.Log ("scoreChange = " + scoreChange);
		
		// scoreChange keeps coming through 0	
		/*
		if (scoreChange < 0)
		{
			scoreChangeText.color = new Color(1f,0,0,113.0f/255.0f);
			scoreString = "-";
		}
		else 
			scoreString = "+";
		*/
		
		if (change < 0)
		{
			scoreChangeText.color = new Color(1f,0,0,113.0f/255.0f);
			// don't need next line, already has a negative
			scoreString = "";
		}
		else 
			scoreString = "+";
			
		if (scoreChangeText.text == null)
			Debug.Log("It was scoreText.text");
		else if (scoreString == null)
			Debug.Log("It was scoreString");
		//else if (scoreChange == null)
		Debug.Log("scoreChange " + scoreChange);
		
		scoreChangeText.text = scoreString + change.ToString();
	}
	
	public void UpdateScoreText(int scoreChange)
	{
		Debug.Log ("MAde it to UpdateScoreText!");
		if (scoreChangeText == null)
		{
			Debug.LogWarning("scoreChange instance is null!");
			scoreChangeText = GetComponent<Text>();
			Debug.Log("scoreChange now " + scoreChangeText);
		}
	}
	
	public void Cleanup()
	{
		Debug.Log ("ScoreChangeText has been destroyed!");
		Destroy(gameObject);
	}
	
	
}