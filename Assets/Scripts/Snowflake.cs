using UnityEngine;
using System.Collections;

public class Snowflake : MonoBehaviour {
	
	public Animator anim;
	public float torque;
	public ParticleSystem snow;
	
	public int pointValue = 75;
	public float rotateRange = 5f;
	
	private GameManager gameManager;
	private SoapController frostController;
	
		
	
	
	// Use this for initialization
	void Start () 
	{
		// anim = FindObjectOfType<SoapScreen>().gameObject.GetComponent<Animator>();
		RandomRotation();
		anim = GameObject.FindGameObjectWithTag("Frost").GetComponent<Animator>();
		Debug.Log ("Starting Snowflake, anim = " + anim.name);
		//gameManager = FindObjectOfType<GameManager>();
		
		GetComponent<Rigidbody2D>().AddTorque(torque);
		
		frostController = FindObjectOfType<SoapController>();
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
			//gameManager.UsePumpkin();
			FindObjectOfType<ScoreText>().GetComponent<ScoreText>().UpdateScore(pointValue);
			MakeSoapAppear();			
		}
	}
	
	void MakeSoapAppear()
	{
		snow.GetComponent<SnowParticles>().SnowStart();
		Debug.Log (snow);
		
		// TODO Play Wind sound
		frostController.PlayWind();
		
		Debug.Log ("Make soap appear, anim equals " + anim.name);
		
		anim.SetTrigger("soapTrigger");
		
	}
	
	void RandomRotation()
	{
		Vector3 newRotation = new Vector3(0f, 0f, Random.Range((-1f * rotateRange),rotateRange));
		
		GetComponent<Transform>().Rotate(newRotation,Space.World);
	}
}
