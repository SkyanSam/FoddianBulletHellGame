using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;
    public Camera cam;
    public ColorPalette prevColorPalette;
    public ColorPalette nextColorPalette;
    public ColorPalette currentColorPalette { get; private set; }
    public float transitionTime;
    float t;
    bool isTransitioning;
    public LayerMask wallLayer;
    public LayerMask decorLayer;

    SpriteRenderer[] wallSprites;
    SpriteRenderer[] decorSprites;
    private void Start()
    {
        Instance = this;
        currentColorPalette = nextColorPalette;
        wallSprites = FindGameObjectsInLayer<SpriteRenderer>(8);
        decorSprites = FindGameObjectsInLayer<SpriteRenderer>(10);

    }
    public void TransitionToColor(ColorPalette palette)
    {
        prevColorPalette = nextColorPalette;
        nextColorPalette = palette;
        t = 0;
    }
    private void Update()
    {
        if (isTransitioning)
        {
            if (t < 0) t = 0;
            if (t > 1) t = 1;
            currentColorPalette.backgroundColor = Color.Lerp(prevColorPalette.backgroundColor, nextColorPalette.backgroundColor, t);
            currentColorPalette.bulletColor = Color.Lerp(prevColorPalette.bulletColor, nextColorPalette.bulletColor, t);
            currentColorPalette.decorColor = Color.Lerp(prevColorPalette.decorColor, nextColorPalette.decorColor, t);
            currentColorPalette.playerColor = Color.Lerp(prevColorPalette.playerColor, nextColorPalette.playerColor, t);
            currentColorPalette.wallColor = Color.Lerp(prevColorPalette.wallColor, nextColorPalette.wallColor, t);
            if (t == 1) isTransitioning = false;
            t += Time.deltaTime / transitionTime;
        }

        cam.backgroundColor = currentColorPalette.backgroundColor;
        foreach (var w in wallSprites) if (w != default(SpriteRenderer)) w.color = currentColorPalette.wallColor;
        foreach (var d in decorSprites) if (d != default(SpriteRenderer)) d.color = currentColorPalette.decorColor;
    }
    GameObject[] FindGameObjectsInLayer(int layer)
    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        var goList = new List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
    }
    T[] FindGameObjectsInLayer<T>(int layer)
    {
        var objects = FindGameObjectsInLayer(layer);
        var types = new T[objects.Length];
        for (int i = 0; i < types.Length; i++)
        {
            T component = default(T);
            if (objects[i].TryGetComponent<T>(out component))
                types[i] = component;
            else
                types[i] = default(T);
        }
            //types[i] = objects[i].GetComponent<T>();
        return types;
    }

}
