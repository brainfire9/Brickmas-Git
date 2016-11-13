using UnityEngine;
using System.Collections;

public class BallBrick : MonoBehaviour {

	public Sprite[] ballAnim;
	public float framerate = 1;
	
	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () 
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		
		StartCoroutine (animateBall());
	}
	
	IEnumerator animateBall()
	{
		while (gameObject)
		{
			for (int frame = 0; frame < ballAnim.Length; frame++)
			{
				spriteRenderer.sprite = ballAnim[frame];
				yield return new WaitForSeconds(framerate);	
			}
			
			spriteRenderer.sprite = ballAnim[1];
			yield return new WaitForSeconds(framerate);	
		}
	}
}
