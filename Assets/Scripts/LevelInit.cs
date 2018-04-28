using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelInit : MonoBehaviour
{
	public ColorSet colorSet;
	
	private List<GameObject> solidObjects;
	private List<GameObject> primaryColorObjects;
	private List<GameObject> secondaryColorObjects;
	private List<GameObject> mixedColorObjects;

	// Use this for initialization
	void Start () {
	
		colorSet = GameManager.instance.currentColorSet;
		solidObjects = GameObject.FindGameObjectsWithTag("Solid").ToList();
		primaryColorObjects = GameObject.FindGameObjectsWithTag("Color1").ToList();
		secondaryColorObjects = GameObject.FindGameObjectsWithTag("Color2").ToList();
		mixedColorObjects = GameObject.FindGameObjectsWithTag("ColorMixed").ToList();
		
		foreach (var solidObject in solidObjects)
		{
			solidObject.GetComponent<SpriteRenderer>().color = Color.black;
		}
		foreach (var color1 in primaryColorObjects)
		{
			//color1.GetComponent<SpriteRenderer>().color = colorSet.PrimaryColor;
			color1.GetComponent<SpriteRenderer>().color = colorSet.PrimaryColor;
		}

		foreach (var color2 in secondaryColorObjects)
		{
			color2.GetComponent<SpriteRenderer>().color = colorSet.SecondaryColor;
		}
		
		foreach (var color3 in mixedColorObjects)
		{
			color3.GetComponent<SpriteRenderer>().color = colorSet.MixedColor;
		}
		
		SetColorOfBlocks(0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void SetColorOfBlocks(int color)
	{
		
		foreach (var color1 in primaryColorObjects)
		{
			Color c = color1.GetComponent<SpriteRenderer>().color;
			c.a = color == 1 ? 1f : 0.3f;
			color1.GetComponent<SpriteRenderer>().color = c;
			color1.layer = color == 1 ? 8 : 0;
		}

		foreach (var color2 in secondaryColorObjects)
		{
			Color c = color2.GetComponent<SpriteRenderer>().color;
			c.a = color == 2 ? 1f : 0.3f;
			color2.GetComponent<SpriteRenderer>().color = c;
			color2.layer = color == 2 ? 8 : 0;
		}
		
		foreach (var color3 in mixedColorObjects)
		{
			Color c = color3.GetComponent<SpriteRenderer>().color;
			c.a = color == 3 ? 1f : 0.3f;
			color3.GetComponent<SpriteRenderer>().color = c;
			color3.layer = color == 3 ? 8 : 0;
		}
	} 
}
