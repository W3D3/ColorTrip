using UnityEngine;

public class ColorSet
{
    private Color primaryColor;
    private Color secondaryColor;
    private Color mixedColor;

    public ColorSet()
    {
    }

    public ColorSet(Color primaryColor, Color secondaryColor, Color mixedColor)
    {
        this.primaryColor = primaryColor;
        this.secondaryColor = secondaryColor;
        this.mixedColor = mixedColor;
    }

    public Color PrimaryColor
    {
        get { return primaryColor; }
        set { primaryColor = value; }
    }

    public Color SecondaryColor
    {
        get { return secondaryColor; }
        set { secondaryColor = value; }
    }

    public Color MixedColor
    {
        get { return mixedColor; }
        set { mixedColor = value; }
    }
}