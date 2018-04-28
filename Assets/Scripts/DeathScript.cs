using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{

	private PolygonCollider2D collider;

	// Use this for initialization
	void Start ()
	{
		collider = GetComponent<PolygonCollider2D>();
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log("Collider!");
		Destroy(other.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
