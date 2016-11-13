using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WelcomeTextScript : MonoBehaviour 
{
	public Color[] textColors;
	public float colorChangeTime;
	public int currentIndex = 0;
	
	private Text welcomeText;
	private Color thisColor;
	private SpriteRenderer spriteRenderer;
	//TODO Remeber to make this private again!
	public float timer = 0f;
	
	private int nextIndex;
	
	
	// Use this for initialization
	void Start () 
	{
		welcomeText = gameObject.GetComponent<Text>();	
		Debug.Log (welcomeText.text);
		thisColor = welcomeText.color;
		if (textColors == null || textColors.Length < 2)
			Debug.LogWarning("Need to setup colors in title text");
			
		nextIndex = 1;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// example using Sin function 
		// Set the x position to loop between -3 and 3 
		//transform.position.x = Mathf.Sin(Time.time) * 3;
		
		//thisColor.a -= 0.1f;
		//thisColor.a = Mathf.Sin(Time.time);
		
		//thisColor.a = Mathf.PingPong(Time.time, 0.7f) + 0.3f;
		//thisColor.a = Mathf.Abs(Mathf.Sin(Time.time));
		
		/** This was the most recent way of changing color
		thisColor.r = Mathf.Abs(Mathf.Sin(Time.time));
		welcomeText.color = thisColor;
		**/
		
		// New way of changing between array of colors
		timer += Time.deltaTime;
		
		if (timer > colorChangeTime)
		{
			// Deal with the index
			if (currentIndex < (textColors.Length - 1)) 
				currentIndex++;
			else 
				currentIndex = 0;
			
			
			// Reset the timer so we can lerp back
			//Debug.Log (timer);
			timer = 0f;
		}
		// original
		// welcomeText.color = Color.Lerp (welcomeText.color, textColors[currentIndex], timer  /  colorChangeTime);
		
		// welcomeText.color = Color.Lerp (welcomeText.color, textColors[currentIndex], colorChangeTime * 3.0f * Time.deltaTime);
		welcomeText.color = Color.Lerp (welcomeText.color, textColors[currentIndex], timer / colorChangeTime);
		
		
		// print (welcomeText.color);
	}
}
