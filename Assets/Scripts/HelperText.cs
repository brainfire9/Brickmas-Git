using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelperText : MonoBehaviour 
{
	public float fadeSpeed = 1.0f;
	
	private Text helperText;
	private float timer;
	private Color newColor;
	private float alpha = 0.0f;
	
	// Use this for initialization
	void Start () 
	{
		helperText = GetComponent<Text>();
		timer = 0.0f;
		newColor = helperText.color;
		newColor.a = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		LerpAlpha();		
	}

	void LerpAlpha()
	{
		float lerp = Mathf.PingPong(Time.time, fadeSpeed) / fadeSpeed;
		// float lerp = Mathf.Lerp(0.0f, 1.0f, fadeSpeed * 3.0f * Time.deltaTime);
		
		/*alpha = Mathf.Lerp(0.0f, 1.0f, lerp);
		newColor = helperText.color;
		newColor.a = alpha;
		helperText.color = newColor;
		Color test = new Color(1.0f,1.0f,1.0f,1.0f);
		*/
		
		// This is my constant lerp
		 helperText.color = new Color (helperText.color.r,helperText.color.g,helperText.color.b,Mathf.Lerp (0.0f,1.0f, lerp));
		
		// This is my smoothed lerp
		// helperText.color = new Color (helperText.color.r,helperText.color.g,helperText.color.b,Mathf.Lerp (0.0f,1.0f, lerp));
		
		
	}

}
