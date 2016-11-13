using UnityEngine;
using System.Collections;

public class testBomb : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			FindObjectOfType<GameManager>().GetComponent<GameManager>().UsePumpkin();
		}
	
	}
}
