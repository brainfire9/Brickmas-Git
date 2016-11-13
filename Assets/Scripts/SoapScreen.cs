using UnityEngine;
using System.Collections;

public class SoapScreen : MonoBehaviour 
{
	public SnowParticles snowParticles;
	
	public void StopSnow()
	{
		snowParticles.SnowStop();
	}
	
}
