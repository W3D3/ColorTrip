using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorHandler : MonoBehaviour
{

    public GameObject Left_Large;
    public GameObject Left_Small;
    public GameObject Right_Large;
    public GameObject Right_Small;

    private Image img_left_large;
    private Image img_left_small;
    private Image img_right_large;
    private Image img_right_small;

    private ColorSet colors = GameManager.instance.currentColorSet;

    void Start()
    {
        //retrieve components of the UI stuff
        img_left_large = Left_Large.GetComponent<Image>();
        img_left_small = Left_Small.GetComponent<Image>();
        img_right_large = Right_Large.GetComponent<Image>();
        img_right_small = Right_Small.GetComponent<Image>();

        //set colors
        img_left_large.color = colors.PrimaryColor;
        img_left_small.color = colors.PrimaryColor;
        img_right_large.color = colors.SecondaryColor;
        img_right_small.color = colors.SecondaryColor;

        //disable large ones for now ... 
        img_left_large.enabled = false;
        img_right_large.enabled = false;

        updateColor(colors.SecondaryColor);
    }

    public void updateColor(Color color_new)
    {
        if(color_new == colors.PrimaryColor)
        {
            //change left
            img_left_large.enabled = true;
            img_left_small.enabled = false;
            img_right_large.enabled = false;
            img_right_small.enabled = true;
        }
        else if (color_new == colors.SecondaryColor)
        {
            //change right
            img_left_large.enabled = false;
            img_left_small.enabled = true;
            img_right_large.enabled = true;
            img_right_small.enabled = false;
        }
        else
        {
            //change ... sth other dunno
        }
    }

    void Update()
    {
        if (Input.GetAxis("Color1") == 1 && Input.GetAxis("Color2") == 0)
            updateColor(colors.PrimaryColor);
        else if (Input.GetAxis("Color1") == 0 && Input.GetAxis("Color2") == 1)
            updateColor(colors.SecondaryColor);

    }
}
