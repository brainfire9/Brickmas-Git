using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour 
{

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		Debug.Log ("Don't destroy on load: " + name);
	}
	
	// Use this for initialization
	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
		// Keep phone from going to sleep
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		//TODO Remove this debug
		Debug.Log("audiosource: " + audioSource);
	}
	
	// Update is called once per frame
	void OnLevelWasLoaded (int level) 
	{
		Debug.Log ("Level " + level + " was loaded!");
		if (level < levelMusicChangeArray.Length)
		{
			AudioClip thisLevelMusic = levelMusicChangeArray[level];
			Debug.Log ("Playing clip: " + thisLevelMusic);
			
			if (thisLevelMusic) //If there's some music attached
			{
				audioSource.clip = thisLevelMusic;
				audioSource.loop = true;
				audioSource.Play();
			}
		}
	}

	public void SetVolume(float volume)
	{
		audioSource.volume = volume;
	}

}
