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
        //foreach (string s in Input.GetJoystickNames())
        //    Debug.Log(s);

        //int i = 0;
        //while (i < 4)
        //{
        //    if (Mathf.Abs(Input.GetAxis("Joy" + (i+1) + "X")) > 0.2F || Mathf.Abs(Input.GetAxis("Joy" + (i + 1) + "Y")) > 0.2F)
        //        Debug.Log(Input.GetJoystickNames()[i] + " is moved");

        //    i++;
        //}

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

    private readonly string _color1_button = "Color1";
    private readonly string _color2_button = "Color2";
    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";
    private readonly string _horizontal_switch = "HorizontalSwitch";
    private readonly string _vertical_switch = "VerticalSwitch";
    private readonly double _treshold = .8;

    private readonly string _switch_gamepad_name = "Wireless Gamepad";

    public float HorizontalVal()
    {
        float horVal = Input.GetAxis(_horizontal);

        foreach (string controller_name in Input.GetJoystickNames())
        {
            if (_switch_gamepad_name.Equals(controller_name) && Input.GetAxis(_horizontal_switch) != 0)
                horVal = Input.GetAxis(_horizontal_switch);
        }

        return horVal;
    }

    public float VerticalVal()
    {
        float vertVal = Input.GetAxis(_vertical);

        foreach (string controller_name in Input.GetJoystickNames())
        {
            if (_switch_gamepad_name.Equals(controller_name) && Input.GetAxis(_vertical_switch) != 0)
            {
                Debug.Log("switch found");
                vertVal = Input.GetAxis(_vertical_switch);
            }
        }

        return vertVal;
    }

    public bool Jump()
    {
        return
            // keyboard 
            Input.GetKeyDown(KeyCode.Space)
            ||
            // switch and xbox controller
            Input.GetKeyDown(KeyCode.JoystickButton0);
    }

    public bool Dash()
    {
        return
            // keyboard
            Input.GetKeyDown(KeyCode.LeftShift)
            ||
            // switch and xbox controller
            Input.GetKeyDown(KeyCode.JoystickButton2);
    }

    public bool Color1()
    {
        return
            Input.GetAxis(_color1_button) > _treshold
                && Input.GetAxis(_color2_button) < _treshold;
    }

    public bool Color2()
    {
        return
            Input.GetAxis(_color1_button) < _treshold
                && Input.GetAxis(_color2_button) > _treshold;
    }

    public bool ColorMixed()
    {
        return
            Input.GetAxis(_color1_button) > _treshold
                && Input.GetAxis(_color2_button) > _treshold;
    }
}
