using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutoplayButtonScript : MonoBehaviour 
{
	private bool result;
	private Paddle paddle;
	
	public void ToggleAutoplay()
	{
		Debug.Log ("Running Autoplay toggle!");
		paddle = GameObject.FindObjectOfType<Paddle>();
		result = gameObject.GetComponent<Toggle>().isOn;
		paddle.autoPlay = result;
	}
}