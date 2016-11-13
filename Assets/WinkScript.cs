using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class WinkScript : MonoBehaviour 
{
	public float winkRate = 5f;
	public float winkDuration = 1f;
	
	private Image sprite;
	private float timer;
	// Use this for initialization
	void Start () 
	{
		sprite = GetComponent<Image>();
		sprite.enabled = false;
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		
		if (timer >= winkRate)
		{
			Debug.Log ("Timer >= winkrate!");
			if (!sprite.enabled)
				sprite.enabled = true;
			
			if (timer >= winkRate + winkDuration)
			{
				sprite.enabled = false;
				timer = 0;
			}
			
			
		}
	}
}
