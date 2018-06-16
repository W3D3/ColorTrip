using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Level;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public float Speed;
    public bool Left;

    public Vector3 OriginalPosition;
    public GameObject Target;

	// Use this for initialization
	void Start ()
	{
	    OriginalPosition = Target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnTriggerEnter2D(Component c)
    {
        if (c.tag != "Player") return;

        StartCoroutine(MakeDoorSmaller());
    }

    private void OnTriggerExit2D(Component c)
    {
        if (c.tag != "Player") return;

        StopAllCoroutines();
        StartCoroutine(MakeDoorBigger());
    }

    private IEnumerator MakeDoorSmaller()
    {
        var leftSprite = Target.GetComponent<SpriteRenderer>();
        var leftSize = leftSprite.size;
        var leftPosition = Target.transform.position;

        while (leftSprite.size.x > 0)
        {
            leftSize.x = Mathf.MoveTowards(leftSprite.size.x, -0.1f, Time.deltaTime * Speed);
            leftPosition.x = leftPosition.x + (Left ? -1 : 1) * (leftSprite.size.x - leftSize.x) / 2;
            Target.transform.position = leftPosition;
            leftSprite.size = leftSize;

            yield return null;
        }

        leftSize.x = 0;
        leftSprite.size = leftSize;
    }

    private IEnumerator MakeDoorBigger()
    {
        var leftSprite = Target.GetComponent<SpriteRenderer>();
        var leftSize = leftSprite.size;
        var leftPosition = Target.transform.position;

        while (1 > leftSprite.size.x)
        {
            leftSize.x = Mathf.MoveTowards(leftSprite.size.x, 1f, Time.deltaTime * Speed);
            leftPosition.x = leftPosition.x + (Left ? -1 : 1) * (leftSprite.size.x - leftSize.x) / 2;
            Target.transform.position = leftPosition;
            leftSprite.size = leftSize;

            yield return null;
        }

        leftSize.x = 1f;
        leftSprite.size = leftSize;
        transform.position = OriginalPosition;
    }

}
