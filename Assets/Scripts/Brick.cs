using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour 
{
	
	public bool normalBrick = true;
	public AudioClip crack;
	public float clipVolume;
	public Sprite[] hitSprites;
	public GameObject smoke;
	public static int brickCount = 0;
	public bool isBreakable;
	public GameObject explosion;
	// public  GameObject dropObjectPrefab;
	//public enum DropObject {None, Present, Coal, Powerup, Powerdown};
	//public DropObject dropObject = DropObject.None;
	public enum DropObject {None, Present, Coal, Snowflake};
	public DropObject dropObject = DropObject.None;
	public int pointsPerBrick = 5;
	
	
	private int timesHit;
	private LevelManager levelManager;
	public bool exploding = false;
	public bool isPumpkin = false;
	public bool dropsOrnament = false;
	private bool isBallBrick = false;
//	private PowerupsContainer powerups;
	private ScoreText scoreText;
	
	
	// Use this for initialization
	void Start () 
	{
		//dropObject = DropObject.None;
		
		isBreakable = (this.tag == "Breakable");
		if (isBreakable)
		{
			brickCount++;
			//print (this.gameObject + " " + brickCount);
			
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		isBallBrick = GetComponent<BallBrick>();
//		powerups = FindObjectOfType<PowerupsContainer>().GetComponent<PowerupsContainer>();
		scoreText = FindObjectOfType<ScoreText>();
		//GameObject textObj = FindObjectOfType<ScoreText>();
		//scoreText = textObj.GetComponent<ScoreText>();
		
		//brickcounttemp = Brick.brickCount
	}
	

	
	void OnCollisionEnter2D (Collision2D other)
	{
		//bool isBreakable = (this.tag == "Breakable");
		if (other.gameObject.GetComponent<Ball>())
		{
			AudioSource.PlayClipAtPoint(crack,transform.position,clipVolume);
			if (isBreakable)
				HandleHits(1);
		}
		
	}
	
	// Public hook for the explosion, not sure if this is better or worse than
	// exposing the HandleHits function.
	public void explodeDamage()
	{
		HandleHits(3);
	}
	
	public void Explode()
	{
		
		
		Instantiate(explosion, transform.position, Quaternion.identity);
		
	}
	
	// TODO delete this, clean up code
	/*void randomDrop(float chance, GameObject drop)
	{
		if (Random.value <= chance)
		{
			GameObject thisDrop = Instantiate(drop,transform.position,Quaternion.identity) as GameObject;
			thisDrop.transform.SetParent(FindObjectOfType<GameManager>().transform);
		}
	}*/
	
	void HandleHits(int damage)
	{
		// timesHit++;
		timesHit += damage;
		
		
		
		int maxHits = hitSprites.Length + 1;
		
		//TODO remove debug info
		Debug.Log ("Damage = " + damage + ", timesHit = " + timesHit + " maxHits = " + maxHits);
		
		//Either destroy the brick, or change to more damaged sprite
		if (timesHit >= maxHits)
		{
			ScoreText scoreText;
			
			brickCount--;
			//print (brickCount);
			levelManager.BrickDestroyed();
			PuffSmoke();
			// TODO Do we want randow or not?
			// randomDrop(0.1f,FindObjectOfType<GameManager>().pumpkinBomb);
			if (isPumpkin)
			{
				GameObject thisBomb = Instantiate(FindObjectOfType<GameManager>().pumpkinBomb, transform.position, Quaternion.identity) as GameObject;
				thisBomb.transform.SetParent(FindObjectOfType<GameManager>().transform);
			}
			else if (dropsOrnament)
			{
				GameObject thisBomb = Instantiate(FindObjectOfType<GameManager>().ornamentBomb, transform.position, Quaternion.identity) as GameObject;
				thisBomb.transform.SetParent(FindObjectOfType<GameManager>().transform);
			}
			if (isBallBrick)
			{
				GameObject newBall = Instantiate(FindObjectOfType<GameManager>().ball, transform.position, Quaternion.identity) as GameObject;
				newBall.transform.SetParent(FindObjectOfType<GameManager>().transform);
			}
			if (dropObject != DropObject.None)
			{
							
				FindObjectOfType<PowerupsContainer>().CreateDropObject(dropObject, gameObject.transform.position);
			}
			// Add points for brick being destroyed

			scoreText = FindObjectOfType<ScoreText>().GetComponent<ScoreText>();
				
			scoreText.UpdateScore(pointsPerBrick);
			
			Debug.Log("About to destroy brick!");
			
			Destroy(gameObject);
			
			Debug.Log ("I shouldn't be here");
		}
		else
			LoadSprites();
	}
	
	void PuffSmoke()
	{
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position ,Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	void LoadSprites()
	{
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex])
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];	
		
	}
	
	//TODO Remove this method once we actually win
	void SimulateWin()
	{
		levelManager.LoadNextLevel();
	}

}
