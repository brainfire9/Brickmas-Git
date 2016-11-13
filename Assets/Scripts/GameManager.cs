using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public int lives = 3;
	public float brickGlowTime = .3f;
	public bool LostLastLife = false;
	public enum Action {NextLife, EndGame};
	public GameObject[] lifeSprites;
	public GameObject pumpkinBomb;
	public GameObject ornamentBomb;
	public GameObject ball;
	public GameObject ballContainer;
	
	// For points
	public int pointsEarned = 0;
	//public GameObject pumpkinBomb;

	
	
	// Use this for initialization
	void Start () 
	{
		// Make Game Manager persistant
		// DontDestroyOnLoad(transform.gameObject);
		
		
		// Check to see if there is a PlayerPrefs file
		/*if (PlayerPrefs.HasKey("currentLevel"))
		{
			lives = PlayerPrefs.GetInt("lives");
			GameObject.FindObjectOfType<LevelManager>().LoadLevel(PlayerPrefs.GetString("currentLevel"));
		}*/
		// If no prefs, new game
		
		// Prevent Android from sleeping
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	public Action LostLife()
	{
		if (lives > 0)
		{
			lives--;
			lifeSprites[lives].SetActive(false);
			
			return Action.NextLife;
		}
		else
			return Action.EndGame;
	}

	public void NextLife()
	{
		//GameObject.FindObjectOfType<Ball>().GetComponent<Ball>().ResetBall();
		//GameObject paddle = 
			GameObject newBall = Instantiate (ball, FindObjectOfType<Paddle>().GetComponent<Transform>().position + Ball.ballRespawnOffset, Quaternion.identity)as GameObject;
		//newBall.transform.SetParent(
	}	
	
	public void NextLevel()
	{
		//PlayerPrefs.SetInt("lives", lives);
		//PlayerPrefs.SetString("currentLevel",Application.loadedLevel+1.ToString());
		
		GameObject.FindObjectOfType<LevelManager>().LoadNextLevel();
	}

	
	public void UsePumpkin()
	{
		Debug.Log ("UsePumpkin() starting up!");
		Explosion.exploding = true;
		StartCoroutine( ChooseBrick() );
	}
	
	public void UseOrnamentBomb()
	{
		Debug.Log ("UseOrnamentBomb() starting up!");
		Explosion.exploding = true;
		StartCoroutine( ChooseBrick() );
	}
	
	IEnumerator ChooseBrick()
	{
		GameObject[] bricks = GameObject.FindGameObjectsWithTag("Breakable");
		Color glow = new Color32(255,255,255,255);
		Color original;
		bool exploded = false;
		for (int brickrange = 0; brickrange < bricks.Length; brickrange++)
		{
			Debug.Log ("Choosebrick run " + brickrange);
			if (bricks[brickrange] == null)
				break;
			SpriteRenderer spriteRenderer = bricks[brickrange].gameObject.GetComponent<SpriteRenderer>();
			// Brick is chosen and may explode
			// Deal with ball hitting glowing brick here
			original = spriteRenderer.color;
			Debug.Log ("Original color = " + original);
			spriteRenderer.color = glow;
								
			if (Random.value > .8)
			{
				bricks[brickrange].GetComponent<Brick>().Explode();
				exploded = true;
				
				
			}
			if (exploded) break;
			
			// This is where brick could be hit by ball
			if (bricks[brickrange] == null)
			{
				Debug.Log("This brick was hit by a ball while glowing");
				UsePumpkin();
				break;
			}
			
			yield return new WaitForSeconds(brickGlowTime/2);
			spriteRenderer.color = original;
			yield return new WaitForSeconds(brickGlowTime/2);
			
		}
		if (!exploded)
		{
			bricks[0].GetComponent<Brick>().Explode();
		}
		Explosion.exploding = false;
	}


}