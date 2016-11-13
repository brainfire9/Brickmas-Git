using UnityEngine;
using System.Collections;

public class BrickCount : MonoBehaviour {
	public int brickCount;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		brickCount = Brick.brickCount;
	}
}
