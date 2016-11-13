using UnityEngine;
using System.Collections;

public class SoapController : MonoBehaviour {
	
	public ParticleSystem snow;
	
	private AudioSource wind;
	
	// Use this for initialization
	void Start () 
	{
		wind = GetComponent<AudioSource>();
	}
	
	public void StopSnow()
	{
		//GetComponent<ParticleSystem>().Stop();
		Debug.Log ("Stopping snow");
		snow.Stop();
		//FindObjectOfType<SnowParticles>().SnowStop();
	}
	
	public void PlayWind()
	{
		wind.Play();
	}
}
