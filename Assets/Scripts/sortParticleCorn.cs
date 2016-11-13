using UnityEngine;
using System.Collections;

public class sortParticleCorn : MonoBehaviour 
{
	public Renderer[] corn;
	// Use this for initialization
	void Start () 
	{
		foreach (Renderer renderer in corn)
		{
			renderer.sortingOrder = 1;
		}
		
		
	}

}
