using UnityEngine;
using System.Collections;

public class SnowParticles : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	// Set the sorting layer of the particle system.
		//ParticleSystem ps = GetComponent<ParticleSystem>();
		Renderer renderer = GetComponent<Renderer>();
		
		renderer.sortingLayerName = "Top";
		renderer.sortingOrder = 2;
		
	
	}
	
	public void SnowStart()
	{
		Debug.Log ("Playing particlesystem");
		GetComponent<ParticleSystem>().Play();
	}
	
	public void SnowStop()
	{
		GetComponent<ParticleSystem>().Stop();
	}
}
