using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour 
{
	public bool original = false;
	public static Vector3 ballRespawnOffset;
	public static int count = 0;
	public Vector2 minimumVelocity;
	
	
	private Paddle paddle;
	
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	private Vector3 ballStartLocation;
	
	// Use this for initialization
	void Start () 
	{
		hasStarted = false;		
		count++;
		
		
		// Only do this if this is the first ball
		if (count < 2)
		{
			paddle = GameObject.FindObjectOfType<Paddle>();
			
			paddleToBallVector = transform.position - paddle.transform.position;
			ballStartLocation = transform.position;		
			
			ballRespawnOffset = paddleToBallVector;
		}
		else
		{
			hasStarted = true;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 10f);
		}
		Debug.Log("Ball count: " + count);
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!this) Debug.Log ("!this");
		if (!hasStarted)
		{
			// If games hasn't actually started, lock the ball to paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			if (Input.GetMouseButtonUp(0))
			{
				Debug.Log("Touch released, launching ball!");
				hasStarted = true;
				
				Rigidbody2D rb = GetComponent<Rigidbody2D>();
				
				Debug.Log ("Initial ball velocity = " + rb.velocity);
				// gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, 15f);
				rb.velocity = new Vector2(4f, 15f);
				Debug.Log ("Current ball velocity = " + rb.velocity);
			}			
		}
	}
	
	public void ResetBall()
	{
		
		hasStarted = false;
		
		transform.position = ballStartLocation;
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		//print (tweak);
		
		if (hasStarted)
		{
			float xDifference, yDifference;
			
			GetComponent<AudioSource>().Play();
			//if (other.gameObject.GetComponent<Paddle>() && 
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			//Debug.Log (rb.velocity);
			
			if (other.gameObject.GetComponent<Paddle>())
			{
				//Vector2 fixMinimumVelocity;
				
				xDifference = minimumVelocity.x - Mathf.Abs(rb.velocity.x);
				yDifference = minimumVelocity.y - Mathf.Abs(rb.velocity.y);
				
				Debug.Log ("Hit paddle! xdiff and ydiff are " + xDifference + " " + yDifference);
				
				// This was the old method, removing because it doesn't work on non-kinematic
				// objects.
				/*
				if (xDifference > 0)
					rb.AddForce(new Vector2(xDifference,0f));
				if (yDifference > 0)
					rb.AddForce(new Vector2(0f, yDifference));
				*/
				
				if (xDifference > 0)
					tweak += new Vector2(xDifference,0f);
				if (yDifference > 0)
					tweak += new Vector2(0f, yDifference);
			}	
			//GetComponent<Rigidbody2D>().velocity += tweak;
			rb.velocity += tweak;
		}
	}
	
	public void Disappear()
	{
		GetComponent<Rigidbody2D>().isKinematic = true;
		GetComponent<SpriteRenderer>().color = new Color(0f,0f,0f,0f);
	}
	
	public void Destroy()
	{
		count--;
		hasStarted = false;
		Destroy(gameObject);
	}
}
