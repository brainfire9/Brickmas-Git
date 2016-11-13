using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public void LoadLevel (string Name)
	{
		
		Debug.Log ("Loading Level: " + Name);
		Brick.brickCount = 0;
		Ball.count = 0;
		
		if (Application.loadedLevel > 2 && Application.loadedLevel < 7)
		{
			TimeControl timeControl;
			timeControl = FindObjectOfType<TimeControl>();
			timeControl.ResumeGame();
		}
		//*/
		Application.LoadLevel(Name);
	}
	
	public void QuitGame()
	{
		Debug.Log ("Quitting game!");
#if UNITY_EDITOR 
		if (UnityEditor.EditorApplication.isPlaying)
			UnityEditor.EditorApplication.isPlaying = false;
		else
#endif
			Application.Quit();

	}
	
	public void LoadNextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
		Brick.brickCount = 0;
		Ball.count = 0;
	}
	
	public void BrickDestroyed()
	{
		if (Brick.brickCount <= 0)
		{
			Ball[] balls = FindObjectsOfType<Ball>();
			
			if (balls.Length > 0)
			{
				foreach (Ball ball in balls)
				{
					ball.GetComponent<Ball>().Disappear();
				}
			}
			
			FindObjectOfType<ContinueButton>().GetComponent<ContinueButton>().ShowContinueButton();
		}
	}
}
