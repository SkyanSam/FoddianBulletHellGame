using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ColorPalette", order = 2)]
public class AIPreset : ScriptableObject
{
    public float minCooldown;
    public float maxCooldown;
    public float? distance;
    public float? playerSpeed;
    public bool enabled;
}
