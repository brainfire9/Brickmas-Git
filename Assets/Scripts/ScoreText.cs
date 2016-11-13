using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour 
{
	public GameObject scoreChangePrefab;
	public bool enableScoreChangeEffect = false;
	public float positionOffset = -1.5f;
	
	private Text scoreText;
	private GameManager gameManager;
	private GameObject newScoreChangeObject;
	
	
	
	
	
	// Use this for initialization
	void Start () 
	{
		gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
		
		scoreText = GetComponent<Text>();
		UpdateScore(0);
	}
	
	// Update is called once per frame
	public void UpdateScore (int scoreChange) 
	{
		Vector3 objectPosition;
		ScoreChangeText scText;
		
		gameManager.pointsEarned += scoreChange;
		scoreText.text = gameManager.pointsEarned.ToString();
		if (scoreChange == 0)
			return;
			
		//if (scoreChange == null)
		//	Debug.Log ("ScoreChange is null!");
		
		if (!enableScoreChangeEffect)
			return;
		objectPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
		// Create the UI text for fading score change, reparent, and send it the score change
		newScoreChangeObject = Instantiate (scoreChangePrefab, objectPosition, Quaternion.identity) as GameObject;
		newScoreChangeObject.transform.SetParent(transform.parent);
		Debug.Log ("Sending scoreChange of " + scoreChange);
		//newScoreChangeObject.GetComponent<ScoreChangeText>().UpdateScoreText(scoreChange);
		scText = newScoreChangeObject.GetComponent<ScoreChangeText>();
		scText.ChangeInt(scoreChange);
		scText.UpdateScoreText(scoreChange);
		Debug.Log ("Created new object for score thing: " + newScoreChangeObject);
	}
}
