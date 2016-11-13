using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour 
{
	private Animator anim;
	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		
	}
	
	public void OpenPresent()
	{
		anim.SetTrigger("OpenPresentTrigger");
		audioSource.Play();
	}
	
	public void Destroy()
	{
		Destroy(gameObject);
	}
	

}
