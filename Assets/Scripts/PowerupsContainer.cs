using UnityEngine;
using System.Collections;

public class PowerupsContainer : MonoBehaviour 
{
	public int presents = 0;
	public int lumpsOfCoal = 0;
	public int snowflakes = 0;
	public GameObject[] dropObjectPrefabs;
	
	//public enum DropObject {None, Present, Coal};
	
		
	// Use this for initialization
	void Start () 
	{
		
		Brick[] brickArray;
		GameObject[] brickObjects;
		
		brickArray = FindObjectsOfType<Brick>();
		
		brickObjects = GetBrickGameObjects(brickArray);
		
		if (presents + lumpsOfCoal + snowflakes > brickObjects.Length)
			Debug.LogError("Presents and coal equal more than objects on screen!");
		
		Debug.Log ("Brick objects in scene: " + brickObjects.Length);
		
		ShuffleArray(brickObjects);
		
		LoadDrops(brickObjects);
	}
	
	GameObject[] GetBrickGameObjects(Brick[] brickArray)
	{
		// Brick[] tempArray;
		int count = 0;
		GameObject[] brickObjects;
		
		// tempArray = FindObjectsOfType<Brick>();
		
		foreach (Brick brick in brickArray)
		{
			if (brick.normalBrick)
				count++;
		}
		
		brickObjects = new GameObject[count];
		count = 0;
		
		foreach (Brick brick in brickArray)
		{
			if (brick.normalBrick)
			{	
				brickObjects[count] = brick.gameObject;
				count++;
			}
		}
		
		return brickObjects;
	}
	
	void ShuffleArray(GameObject[] bricks)
	{
		// Knuth shuffle
		
		for (int t = 0; t < bricks.Length; t++)
		{
			GameObject tmp = bricks[t];
			int r = Random.Range(t,bricks.Length);
			bricks[t] = bricks[r];
			bricks[r] = tmp;
		}
	}
	
	void LoadDrops(GameObject[] bricks)
	{
		/*
		int presentCount;
		int coalCount;
		
		for (presentCount = 0; presentCount < presents; presents++)
		{
			bricks[presentCount].GetComponent<Brick>().dropObject = Brick.DropObject.Present;
		}
		
		for (coalCount = 0; coalCount < lumpsOfCoal; coalCount++)
		{
			bricks[presentCount].GetComponent<Brick>().dropObject = Brick.DropObject.Coal;
		}
		*/
		int totalDropItems = presents + lumpsOfCoal + snowflakes;
		
		for (int dropItemCount = 0; dropItemCount < totalDropItems; dropItemCount++)
		{
			Brick brick = bricks[dropItemCount].GetComponent<Brick>();
			
			if (dropItemCount <= presents)
				// bricks[dropItemCount].GetComponent<Brick>().dropObject = Brick.DropObject.Present;
				brick.dropObject = Brick.DropObject.Present;
			else if (dropItemCount <= (presents + lumpsOfCoal))
				//bricks[dropItemCount].GetComponent<Brick>().dropObject = Brick.DropObject.Coal;
				brick.dropObject = Brick.DropObject.Coal;
			else
				brick.dropObject = Brick.DropObject.Snowflake;
			
		}
		
	
	}
	
	public void CreateDropObject(Brick.DropObject dropObject, Vector3 position)
	{
		GameObject newObject;
		int index;
		
		index = (int) dropObject;
		//newObject = Instantiate (prefab, position, Quaternion.identity) as GameObject;
		newObject = Instantiate (dropObjectPrefabs[index], position, Quaternion.identity) as GameObject;
		newObject.transform.SetParent(FindObjectOfType<PowerupsContainer>().transform);
	}
}
