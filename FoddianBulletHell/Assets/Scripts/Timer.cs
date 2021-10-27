using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    TMPro.TextMeshProUGUI text;
    public static float time;
    public bool updateTime;
    void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();

        if (updateTime) time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (updateTime) time = Time.timeSinceLevelLoad;

        var t = (Mathf.Round(time * 10) / 10).ToString();
        if (t.Length == 1) t += ".0";
        t += "s";
        text.text = t;
    }
}
