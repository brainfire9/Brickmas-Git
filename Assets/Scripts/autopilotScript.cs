using UnityEngine;
using System.Collections;

public class autopilotScript : MonoBehaviour {

	public Sprite[] autopilotSprites;
	
	private SpriteRenderer spriteRenderer;

	private Paddle paddle;
	//private bool autoPilot = false;
	private int spriteIndex;
	
	// Use this for initialization
	void Start () 
	{
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		
		paddle = GameObject.FindObjectOfType<Paddle>();
		if (paddle.autoPlay)
		{
			//autoPilot = true;
			spriteIndex = 1;
		}
		else
			spriteIndex = 0;
			
		spriteRenderer.sprite = autopilotSprites[spriteIndex];
	}
	
	// Update is called once per frame
	void Update () 
	{
		//onmouseover
		if(isTouched())
		{
			Debug.Log ("Touched!");
			ToggleAutopilot();
			
		}
	}
	
	void ToggleAutopilot()
	{
		if (!paddle.autoPlay)
		{
			spriteIndex = 1;
			paddle.autoPlay = true;
		}
		else
		{
			spriteIndex = 0;
			paddle.autoPlay = false;
		}
		
		spriteRenderer.sprite = autopilotSprites[spriteIndex];
	}
	
	public bool isTouched() 
	{
		bool result = false;
		if(Input.touchCount == 1) 
		{
			if(Input.touches[0].phase == TouchPhase.Ended) 
			{
				Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
				Vector2 touchPos = new Vector2(wp.x, wp.y);
				Debug.Log("touchPos: " + touchPos + " Sprite Pos:" + spriteRenderer.transform.position);
				if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos)) 
				{
					result = true;
				}
			}
		}
		if(Input.GetMouseButtonUp(0)) 
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			//Vector2 mousePos = new Vector2(wp.x, wp.y);
			Debug.Log(wp.x + ", " + wp.y);
			/*if (collider2D == Physics2D.OverlapPoint(mousePos)) 
			{
				result = true;
			}*/
			if (wp.x >= 9f && wp.y >= 27f)
				result = true;
			else 
				result = false;
		}
		return result;
	}
}
