using UnityEngine;
using System.Collections;

public class HelpMenu : MonoBehaviour 
{
	private Animator animator;
	private GameObject[] helpMenuPrefabs;
	private CanvasGroup canvasGroup;

	// Use this for initialization
	void Start () 
	{
		// Build a connection to Animator so we can trigger the slide in/out animations
		animator = GetComponent<Animator> ();
		canvasGroup = GameObject.FindGameObjectWithTag ("OptionsMenu").GetComponent<CanvasGroup> ();

		// Build an array of the objects that 
		// TODO Add prefabs for motion
		//helpMenuPrefabs = GameObject.FindGameObjectsWithTag("HelpMenuItem");

	}
	void Update()
	{
		if (Input.touchCount > 0)
			animator.SetBool ("isVisibile", false);
	}
	
	public void Hide()
	{
		//animator.SetTrigger ("closeTrigger");
		//animator.ResetTrigger ("closeTrigger");
		canvasGroup.interactable = true;

		Debug.Log("Hiding help menu!");
		animator.SetBool("isVisible",false);

	}

	public void Show()
	{
		//animator.SetTrigger ("helpTrigger");
		canvasGroup.interactable = false;
		animator.SetBool("isVisible",true);
	}
}
