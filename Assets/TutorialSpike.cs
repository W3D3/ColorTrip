using UnityEngine;

public class TutorialSpike : MonoBehaviour
{


    public GameObject targetObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            targetObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        Debug.Log("Collision");
    }
}
