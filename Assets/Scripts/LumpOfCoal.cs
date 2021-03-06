﻿using UnityEngine;
using System.Collections;

public class LumpOfCoal : MonoBehaviour 
{
	public int pointValue = -10;
	public float rotateRange = 0f;
	public AudioClip lumpTrumpet;
	//public float clipVolume = 1f;

	private ScoreText scoreText;
	
	// Use this for initialization
	void Start () 
	{
		
		RandomRotation();
		//GetComponent<Transform>().Rotate(newRotation, Space.World);
		
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
			Debug.Log ("Got coal!");

			// Old way of playing sound
			//AudioSource.PlayClipAtPoint(lumpTrumpet,transform.position,clipVolume);

			scoreText.UpdateScore(pointValue);
			DestroyPresent();
		}
	}
	
	void DestroyPresent()
	{
		GetComponent<AudioSource> ().PlayOneShot (lumpTrumpet);
		GetComponentInChildren<Renderer> ().enabled = false;

		Destroy(gameObject,lumpTrumpet.length);
	}
}
