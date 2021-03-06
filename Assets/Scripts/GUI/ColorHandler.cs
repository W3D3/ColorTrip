﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHandler : MonoBehaviour
{

    public GameObject Left_Large;
    public GameObject Left_Small;
    public GameObject Right_Large;
    public GameObject Right_Small;
    public GameObject Full;

    private Image img_left_large;
    private Image img_left_small;
    private Image img_right_large;
    private Image img_right_small;
    private Image img_full;

    private ColorSet colors;

    void Start()
    {
        //retrieve components of the UI stuff
        img_left_large = Left_Large.GetComponent<Image>();
        img_left_small = Left_Small.GetComponent<Image>();
        img_right_large = Right_Large.GetComponent<Image>();
        img_right_small = Right_Small.GetComponent<Image>();
        img_full = Full.GetComponent<Image>();

        if (GameManager.instance != null)
        {
            colors = GameManager.instance.currentColorSet;

            // set colors
            img_left_large.color = colors.PrimaryColor;
            img_left_small.color = colors.PrimaryColor;
            img_right_large.color = colors.SecondaryColor;
            img_right_small.color = colors.SecondaryColor;
            img_full.color = colors.MixedColor;
        }
        else
        {
            colors = Colors.COLORSET_1;
        }

        //disable large ones for now ... 
        img_left_large.enabled = false;
        img_right_large.enabled = false;
        img_full.enabled = false;
    }

    public void updateColor(Color color_new)
    {
        if (colors == null) return;

        if(color_new == colors.PrimaryColor)
        {
            //change left
            img_left_large.enabled = true;
            img_left_small.enabled = false;
            img_right_large.enabled = false;
            img_right_small.enabled = true;
            img_full.enabled = false;
        }
        else if (color_new == colors.SecondaryColor)
        {
            //change right
            img_left_large.enabled = false;
            img_left_small.enabled = true;
            img_right_large.enabled = true;
            img_right_small.enabled = false;
            img_full.enabled = false;
        }
        else if (color_new == colors.MixedColor)
        {
            //change ... sth other dunno
            img_left_large.enabled = false;
            img_left_small.enabled = false;
            img_right_large.enabled = false;
            img_right_small.enabled = false;
            img_full.enabled = true;
        }
        else
        {
            //no color
            img_left_large.enabled = false;
            img_left_small.enabled = true;
            img_right_large.enabled = false;
            img_right_small.enabled = true;
            img_full.enabled = false;
        }
    }

    void Update()
    {
        if (GamepadInput.Color1())
            updateColor(colors.PrimaryColor);
        else if (GamepadInput.Color2())
            updateColor(colors.SecondaryColor);
        else if (GamepadInput.ColorMixed())
            updateColor(colors.MixedColor);
        else
            updateColor(new Color(0, 0, 0, 0));
    }
}
