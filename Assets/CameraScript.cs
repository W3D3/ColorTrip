using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    private float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        else if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        else if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        else if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));

        else if (ColorMixed())
        {
            Console.Out.WriteLine("joystick pressed");
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
    }

    public bool Jump ()
    {
        return Input.GetKey(KeyCode.Joystick1Button0);
    }

    public bool Color1()
    {
        return Input.GetKey(KeyCode.Joystick1Button6)
            && !Input.GetKey(KeyCode.Joystick1Button7);
    }

    public bool Color2()
    {
        return !Input.GetKey(KeyCode.Joystick1Button6)
            && Input.GetKey(KeyCode.Joystick1Button7);
    }

    public bool ColorMixed()
    {
        return Input.GetKey(KeyCode.Joystick1Button6)
            && Input.GetKey(KeyCode.Joystick1Button7);
    }
}
