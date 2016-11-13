using UnityEngine;
using System.Collections;

public class SpecialBrickGlow : MonoBehaviour 
{
	public float glowTime;
	
	private SpriteRenderer spriteRenderer;
	private Color originalColor;
	
	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		originalColor = spriteRenderer.color;
	}
	
	// Update is called once per frame
	void Update () 
	{
		spriteRenderer.color = Color.Lerp(originalColor, Color.yellow, Mathf.PingPong(Time.time * glowTime, 1.0f));
	}
}
