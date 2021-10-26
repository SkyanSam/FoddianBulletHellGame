using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorApplier : MonoBehaviour
{
    public ColorApplied type = ColorApplied.None;
    SpriteRenderer sprRenderer;
    public enum ColorApplied
    {
        PlayerColor,
        BulletColor,
        DecorColor,
        WallColor,
        BackgroundColor,
        None
    }
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(type)
        {
            case ColorApplied.BulletColor: sprRenderer.color = ColorManager.Instance.currentColorPalette.bulletColor; break;
            case ColorApplied.PlayerColor: sprRenderer.color = ColorManager.Instance.currentColorPalette.playerColor; break;
            case ColorApplied.DecorColor: sprRenderer.color = ColorManager.Instance.currentColorPalette.decorColor; break;
            case ColorApplied.WallColor: sprRenderer.color = ColorManager.Instance.currentColorPalette.wallColor; break;
            case ColorApplied.BackgroundColor: sprRenderer.color = ColorManager.Instance.currentColorPalette.backgroundColor; break;
            default: print("No Color Applied on GameObject " + gameObject.name); break;
        }
    }
}
