using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour 
{
	public bool autoPlay;
	public float minX, maxX;
	
	private Ball ball;
	// Use this for initialization
	void Start () 
	{
		// ball = GameObject.FindObjectOfType<Ball>();
		ball = FindBall();
	}
	
	private Ball FindBall()
	{
		return GameObject.FindObjectsOfType<Ball>()[0];
	}
	// Update is called once per frame
	void Update () 
	{
		if (!autoPlay)
			MoveWithTouch();
		else 
		{
			if (ball == null)
				ball = FindBall();
			AutoPlay();	
		}
	}
	
	void AutoPlay()
	{
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x,minX,maxX);		
		this.transform.position = paddlePos;
	}
	
	void MoveWithTouch()
	{
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		float MousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp (MousePosInBlocks,minX,maxX);
		
		this.transform.position = paddlePos;
	}
}
