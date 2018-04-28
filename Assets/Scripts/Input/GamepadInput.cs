using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadInput : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0));

        transform.Translate(new Vector3(0, Input.GetAxis("Vertical"), 0));

        if (Jump())
            Debug.Log("jump pressed");

        if (Dash())
            Debug.Log("dash pressed");

        if (Color1())
            Debug.Log("left trigger pressed");

        if (Color2())
            Debug.Log("right trigger pressed");

        if (ColorMixed())
            Debug.Log("both trigger pressed");

    }

    private readonly string _jump_button_name = "JumpButton";
    private readonly string _dash_button_name = "DashButton";
    private readonly string _color1_button = "Color1";
    private readonly string _color2_button = "Color2";

    public bool Jump()
    {
        // switch and xbox controller
        return Input.GetAxis(_jump_button_name) == 1;
    }

    public bool Dash()
    {
        // switch and xbox controller
        return Input.GetAxis(_dash_button_name) == 1;
    }

    public bool Color1()
    {
        return
            // switch controller
            Input.GetKey(KeyCode.Joystick1Button6)
                && !Input.GetKey(KeyCode.Joystick1Button7)
            ||
            // xbox controller
            Input.GetAxis(_color1_button) > .5
                && Input.GetAxis(_color2_button) < .5;
    }

    public bool Color2()
    {
        return
            // switch controller
            !Input.GetKey(KeyCode.Joystick1Button6)
                && Input.GetKey(KeyCode.Joystick1Button7)
            ||
            // xbox controller
            Input.GetAxis(_color1_button) < .5
                && Input.GetAxis(_color2_button) > .5;
    }

    public bool ColorMixed()
    {
        return
            // switch controller
            Input.GetKey(KeyCode.Joystick1Button6)
                && Input.GetKey(KeyCode.Joystick1Button7)
            ||
            // xbox controller
            Input.GetAxis(_color1_button) > .5
                && Input.GetAxis(_color2_button) > .5;
        ;
    }
}
