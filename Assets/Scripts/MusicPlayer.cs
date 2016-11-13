using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour 
{
	public AudioClip level4Music;
	static MusicPlayer instance = null;
	//public 

	// Use this for initialization
	void Start () 
	{
		if (instance != null)
		{
			Destroy (gameObject);
			Debug.Log ("Duplicate music player self destructing!");
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		 
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void SwitchToLevel4()
	{
		
	}
	public void RegularMusic()
	{
	}
}
