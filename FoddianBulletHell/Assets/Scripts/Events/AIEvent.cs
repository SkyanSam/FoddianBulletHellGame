using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEvent : FoddianEvent
{
    public AIPreset preset;
    public override void StartEvent(params System.Type[] parameters)
    {
        if (preset.distance.HasValue) SpawnerAI.Instance.distance = preset.distance.Value;
        if (preset.playerSpeed.HasValue) PlayerMovement.Instance.speed = preset.playerSpeed.Value;
        SpawnerAI.Instance.minCooldown = preset.minCooldown;
        SpawnerAI.Instance.maxCooldown = preset.maxCooldown;
        SpawnerAI.Instance.enabled = preset.enabled;
    }
}
