using UnityEngine;
using System.Collections;

public class SoapBar : MonoBehaviour {
	
	public Animator anim;
	private GameManager gameManager;
	
	// Use this for initialization
	void Start () 
	{
		// anim = FindObjectOfType<SoapScreen>().GetComponent<Animator>();
		//gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
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
			MakeSoapAppear();			
		}
	}
	
	void MakeSoapAppear()
	{
		anim.SetTrigger("soapTrigger");
	}
}
