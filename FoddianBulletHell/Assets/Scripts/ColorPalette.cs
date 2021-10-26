using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ColorPalette", order = 1)]
public class ColorPalette : ScriptableObject
{
    public Color playerColor;
    public Color bulletColor;
    public Color decorColor;
    public Color wallColor;
    public Color backgroundColor;
}
