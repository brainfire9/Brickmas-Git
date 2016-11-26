using UnityEngine;
using System.Collections;

public class OrnamentBomb : MonoBehaviour 
{
	public float speed = 1f;
	public int pointValue = 50;
	public float rotateRange = 5f;
	public AudioClip pickupSound;
	
	private GameManager gameManager;
	private bool paused = false;
	
	// Use this for initialization
	void Start () 
	{
		gameManager = FindObjectOfType<GameManager>();
		
		RandomRotation();
		
	}
	
	/*
	void Update()
	{
		if (!paused)
		{
			transform.position = new Vector2(transform.position.x, transform.position.y + speed * -1 * Time.deltaTime);
		}
	}*/
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
			// This was prior to having a sound
			//Destroy(gameObject);
			TimedDestroy();
			FindObjectOfType<ScoreText>().GetComponent<ScoreText>().UpdateScore(pointValue);
			Debug.Log(name + " hit the trigger " + other.name);
			gameManager.UseOrnamentBomb();
		}
	}
	
	void RandomRotation()
	{
		Vector3 newRotation = new Vector3(0f, 0f, Random.Range((-1f * rotateRange),rotateRange));
		
		GetComponent<Transform>().Rotate(newRotation,Space.World);
	}

	void TimedDestroy()
	{
		GetComponent<AudioSource> ().PlayOneShot (pickupSound);
		GetComponentInChildren<Renderer> ().enabled = false;
		Destroy (gameObject, pickupSound.length);
	}
}
