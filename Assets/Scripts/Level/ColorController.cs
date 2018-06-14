using System;
using System.Collections.Generic;
using Assets.Scripts.Level;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public LevelTheme Theme;
    public ColorInput CurrentColorInput;
    public LevelColor LevelColors;

    public float AlphaDisabled = 0.3f;

    private GameObject _player;
    private IEnumerable<GameObject> _color1Blocks;
    private IEnumerable<GameObject> _color2Blocks;
    private IEnumerable<GameObject> _colorMixedBlocks;
    private IEnumerable<GameObject> _antiColor1Blocks;
    private IEnumerable<GameObject> _antiColor2Blocks;
    private IEnumerable<GameObject> _antiColorMixedBlocks;

    void Start()
    {
        LevelColors = ColorFactory.FromTheme(Theme);

        var solidBlocks = GameObject.FindGameObjectsWithTag("Solid");
        Colorize(solidBlocks, ColorFactory.Black);

        _player = GameObject.FindGameObjectWithTag("Player");
        _color1Blocks = GameObject.FindGameObjectsWithTag("Color1");
        _color2Blocks = GameObject.FindGameObjectsWithTag("Color2");
        _colorMixedBlocks = GameObject.FindGameObjectsWithTag("ColorMixed");
        _antiColor1Blocks = GameObject.FindGameObjectsWithTag("AntiColor1");
        _antiColor2Blocks = GameObject.FindGameObjectsWithTag("AntiColor2");
        _antiColorMixedBlocks = GameObject.FindGameObjectsWithTag("AntiColorMixed");

        Colorize(_color1Blocks, LevelColors.Color1);
        Colorize(_color2Blocks, LevelColors.Color2);
        Colorize(_colorMixedBlocks, LevelColors.ColorMixed);
        Colorize(_antiColor1Blocks, LevelColors.Color1);
        Colorize(_antiColor2Blocks, LevelColors.Color2);
        Colorize(_antiColorMixedBlocks, LevelColors.ColorMixed);

        UpdateColors(ColorInput.None);
    }

    void Update()
    {
        if (GamepadInput.ColorMixed())
        {
            if (CurrentColorInput != ColorInput.ColorMixed)
            {
                UpdateColors(ColorInput.ColorMixed);
            }
        }
        else if (GamepadInput.Color2())
        {
            if (CurrentColorInput != ColorInput.Color2)
            {
                UpdateColors(ColorInput.Color2);
            }
        }
        else if (GamepadInput.Color1())
        {
            if (CurrentColorInput != ColorInput.Color1)
            {
                UpdateColors(ColorInput.Color1);
            }
        }
        else
        {
            if (CurrentColorInput != ColorInput.None)
            {
                UpdateColors(ColorInput.None);
            }
        }
    }

    private void UpdateColors(ColorInput input)
    {
        CurrentColorInput = input;

        switch (input)
        {
            case ColorInput.None:
                Colorize(_player, LevelColors.Player);
                break;
            case ColorInput.Color1:
                Colorize(_player, LevelColors.Color1);
                break;
            case ColorInput.Color2:
                Colorize(_player, LevelColors.Color2);
                break;
            case ColorInput.ColorMixed:
                Colorize(_player, LevelColors.ColorMixed);
                break;
            default:
                throw new ArgumentOutOfRangeException("input", input, null);
        }

        SetState(_color1Blocks, input == ColorInput.Color1);
        SetState(_color2Blocks, input == ColorInput.Color2);
        SetState(_colorMixedBlocks, input == ColorInput.ColorMixed);
        SetState(_antiColor1Blocks, input != ColorInput.Color1);
        SetState(_antiColor2Blocks, input != ColorInput.Color2);
        SetState(_antiColorMixedBlocks, input != ColorInput.ColorMixed);
    }

    private void SetState(IEnumerable<GameObject> gameObjects, bool enable)
    {
        foreach (var go in gameObjects)
        {
            var sRenderer = go.GetComponent<SpriteRenderer>();
            var color = sRenderer.color;
            color.a = enable ? 1f : AlphaDisabled;
            sRenderer.color = color;

            go.layer = enable ? 8 : 0; // collision : default
        }
    }

    private static void Colorize(IEnumerable<GameObject> gameObjects, Color32 color)
    {
        foreach (var gameObject in gameObjects)
        {
            Colorize(gameObject, color);
        }
    }

    private static void Colorize(GameObject gameObject, Color32 color)
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }
}