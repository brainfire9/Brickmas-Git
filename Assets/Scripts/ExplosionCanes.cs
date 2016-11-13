using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionCanes : MonoBehaviour 
{
	public float blastRadius;
	public ParticleSystem[] canePS;
	public static bool exploding = false;
	
	private Collider2D[] blastArray;
	
	void Update()
	{
	
	}
	
	// Use this for initialization
	void Start () 
	{
		blastRadius = GetComponent<CircleCollider2D>().radius * 2;
		blastArray = Physics2D.OverlapCircleAll(transform.position, blastRadius, 1);
		// Brick[] bricks;
		//int brickIndex = 0;
		// List<int> blastList = new List<int>();
		
		foreach (Collider2D other in blastArray)
		{
			if (other && other.tag == "Breakable")
			{
				other.GetComponent<Brick>().explodeDamage();
			}
		}
	}
	
	
	// Tidy up, get rid of both particle systems then destroy this gameObject
	public void EndExplosion()
	{
		foreach (ParticleSystem ps in canePS)
		{
			ps.Stop();
		}
		
		Destroy(gameObject);	
	}
}
