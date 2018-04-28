using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelInit : MonoBehaviour
{
	public ColorSet colorSet = GameManager.instance.currentColorSet;
	
	private List<GameObject> solidObjects;
	private List<GameObject> primaryColorObjects;
	private List<GameObject> secondaryColorObjects;
	private List<GameObject> mixedColorObjects;

	// Use this for initialization
	void Start () {
	
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
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
