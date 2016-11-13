using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour 
{
	private Vector2 velocity;
	private float angularVelocity;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	public void PauseGame()
	{
		/*Ball[] balls;
		
		GameObject[] objects;
		
		balls = FindObjectsOfType<Ball>();
		objects = GameObject.FindGameObjectsWithTag("Freezeable");
		*/
		// TODO pause all non ball objects
		/*
		foreach (GameObject obj in objects)
		{
			obj.
		}
		*/
		// FindObjectOfType<Ball>().gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		/*
		foreach (Ball ball in balls)
		{
			Rigidbody2D rb = ball.gameObject.GetComponent<Rigidbody2D>();
			
			// ball.gameObject.GetComponent<Rigidbody2D>().velocity =  Vector2.zero;
			// ball.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
			velocity = rb.velocity;
			angularVelocity = rb.angularVelocity;
			rb.isKinematic = true;
			
			// ball.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		}
		*/
		
		Debug.Log ("Pausing Game");
		
		Time.timeScale = 0f;
		
	}
	
	public void ResumeGame()
	{
		/*Ball[] balls;
		
		balls = FindObjectsOfType<Ball>();
		
		// FindObjectOfType<Ball>().gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		foreach (Ball ball in balls)
		{
			Rigidbody2D rb = ball.gameObject.GetComponent<Rigidbody2D>();
			
			//  ball.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			rb.isKinematic = false;
			rb.velocity = velocity;
			rb.angularVelocity = angularVelocity;
		}
		*/
		Debug.Log ("Resuming Game");
		Time.timeScale = 1f;
	}
}
