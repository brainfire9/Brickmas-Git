using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{
	private LevelManager levelManager;
	private GameManager gameManager;
	
	private GameManager.Action endGame = GameManager.Action.EndGame;
	//private GameManager.Action 
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		//levelManager = GameObject.FindObjectOfType<LevelManager>();
		//gameManager = GameObject.FindObjectOfType<GameManager>();
		
		if (other.tag == "Powerup")
		{
			Destroy(other.gameObject);
			return;
		}
		Debug.Log ("Ball count " + Ball.count);
		if (other.tag == "Ball" && Ball.count > 1)
		{
			//Ball ball = other.GetComponent<Ball>();
			//GameObject ball = other.gameObject;
			
			other.GetComponent<Ball>().Destroy();	
		}
		else if (other.tag == "Ball" && Ball.count == 1)
		{
			gameManager = GameObject.FindObjectOfType<GameManager>();
			
			if (gameManager.LostLife() == endGame)
			{
				GameObject.FindObjectOfType<LevelManager>().LoadLevel("LoseScreen");
				//levelManager.LoadLevel("LoseScreen");
			}
			else
			{
				//GameObject.FindObjectOfType<GameManager>().NextLife();
				other.GetComponent<Ball>().Destroy();
				gameManager.NextLife ();
			}
		}
	}
}
