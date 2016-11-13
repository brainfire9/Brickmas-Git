using UnityEngine;
using System.Collections;

public class SoapScreenFader : MonoBehaviour {

	public GameObject soapScreen;
	public float fadeSeconds = 0.25f;
	
	private float finalColor;
	
	// Use this for initialization
	void Start () 
	{
		// finalColor = new Vector4(1f, 1f, 1f, .87f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	private void SelfDesctruct()
	{
		Destroy(this);
	}
}
