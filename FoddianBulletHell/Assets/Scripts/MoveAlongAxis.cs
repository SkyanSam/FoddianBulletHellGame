using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongAxis : MonoBehaviour
{
    public AnimationCurve tween;
    public Vector2 axis = Vector2.right;
    public float speed;
    public float multiplier;
    float timePassed = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = axis * tween.Evaluate(GetTime()) * multiplier;
        timePassed += Time.deltaTime * speed;
    }
    float GetTime(bool usingVariable = false, float variable = 0)
    {
        if (!usingVariable) variable = timePassed;
        if (variable < 0) return GetTime(usingVariable: true, variable: variable + 1);
        else if (variable > 1) return GetTime(usingVariable: true, variable: variable - 1);
        else return variable;
    }
    
}
