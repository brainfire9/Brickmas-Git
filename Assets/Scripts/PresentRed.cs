using UnityEngine;
using System.Collections;

public class PresentRed : MonoBehaviour 
{
	public int pointValue = 10;
	public float rotateRange = 0f;
	
	private GameManager gameManager;
	private ScoreText scoreText;
	
	// Use this for initialization
	void Start () 
	{
			
		RandomRotation();
		//GetComponent<Transform>().Rotate(newRotation, Space.World);
		//transform.Rotate(	
		scoreText = FindObjectOfType<ScoreText>().GetComponent<ScoreText>();
	}
	
	void RandomRotation()
	{
		Vector3 newRotation = new Vector3(0f, 0f, Random.Range((-1f * rotateRange),rotateRange));
		
		GetComponent<Transform>().Rotate(newRotation,Space.World);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<Paddle>())
		{
			Debug.Log ("Got present!");
			scoreText.UpdateScore(pointValue);
			DestroyPresent();
		}
	}
	
	void DestroyPresent()
	{
		Destroy(gameObject);
	}
}
