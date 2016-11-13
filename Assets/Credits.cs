using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour 
{
	public float speed = 29.0f;
	//public Color color;
	public Material material;
	public Rect viewArea;
	public float secondsUntilReset = 31f;
	public int screenWidth;
	
	private float offset;
	public float secondsPassed;
	public GUIStyle style;
	
	// Use this for initialization
	void Start () 
	{
		this.offset = this.viewArea.height;
		screenWidth = Screen.width;
		//GUI.color = color;
	}
	
	// Update is called once per frame
	void Update () 
	{
		secondsPassed += Time.deltaTime;
		this.offset -= Time.deltaTime * this.speed;
		
		//Debug.Log(Time.time);
		if (secondsPassed > secondsUntilReset)
		{
			secondsPassed = 0f;
			this.offset = this.viewArea.height;
		}
	}
	
	private void OnGUI()
	{
		GUI.BeginGroup(this.viewArea);
		
		var position = new Rect(0, this.offset, this.viewArea.width, this.viewArea.height);
		//var position = new Rect(0, this.offset, screenWidth, this.viewArea.height);
		
		var text = @"Artwork:
Christmas candle snowman with lights by Digidreamgrafix - Own work. Licensed under CC BY-SA 3.0 via Wikimedia Commons - https://commons.wikimedia.org/wiki/File:Christmas_candle_snowman_with_lights.jpg#/media/File:Christmas_candle_snowman_with_lights.jpg

Rockefeller Center christmas tree cropped by Rockefeller_Center_christmas_tree.jpg: User:Urban *derivative work: –Juliancolton | Talk - Rockefeller_Center_christmas_tree.jpg. Licensed under CC BY-SA 3.0 via Commons - https://commons.wikimedia.org/wiki/File:Rockefeller_Center_christmas_tree_cropped.jpg#/media/File:Rockefeller_Center_christmas_tree_cropped.jpg

Michael Melgar LiquidArt resize droplet by Michael Melgar - english wikipedia.. Licensed under CC BY-SA 3.0 via Wikimedia Commons - https://commons.wikimedia.org/wiki/File:Michael_Melgar_LiquidArt_resize_droplet.jpg#/media/File:Michael_Melgar_LiquidArt_resize_droplet.jpg

Holidays Christmas Candle Photo, cropped - http://www.torange.us/Holidays/christmas/Christmas-candle-37924.html, used under Creative Commons Attribution 4.0 International

'Lump of coal' by Duncan Harris - Lump of coal Uploaded by oxyman. Licensed under CC BY-SA 2.0 via Wikimedia Commons - https://commons.wikimedia.org/wiki/File:Lump_of_coal.jpg#/media/File:Lump_of_coal.jpg

Win screen
Background of Christmas Lights - http://www.torange.us/Backgrounds-textures/abstract-backgrounds/Background-of-Christmas-lights-24607.html, used under Creative Commons 4.0 International

Many images used are from the Public Domain
";
	
		
		//GUI.Label(position, text, this.style);
		GUI.Label(position, text, style);
		//GUI.contentColor = color;
		
		GUI.EndGroup();	
		
		
	}
}
