using UnityEngine;
using System.Collections;

public class PumpkinBomb : MonoBehaviour 
{
	private GameManager gameManager;
	// Use this for initialization
	void Start () 
	{
		gameManager = FindObjectOfType<GameManager>();
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		/*
		if (other.tag == "BumperPaddle");
		{
			Destroy(gameObject);
			Debug.Log(name + " hit the trigger " + other.name);
			gameManager.UsePumpkin();
		}
		*/
		if (other.GetComponent<LoseCollider>())
			Destroy(gameObject);
		else if (other.GetComponent<Paddle>())
		{
			Destroy(gameObject);
			Debug.Log(name + " hit the trigger " + other.name);
			gameManager.UsePumpkin();
		}
	}
}
