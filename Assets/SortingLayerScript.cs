using UnityEngine;
using System.Collections;

public class SortingLayerScript : MonoBehaviour 
{
	private SpriteRenderer spriteRenderer;
	public int sortingLayer = 0;
	
	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (spriteRenderer)
		{
			spriteRenderer.sortingOrder = sortingLayer;
		} 
	}

}
