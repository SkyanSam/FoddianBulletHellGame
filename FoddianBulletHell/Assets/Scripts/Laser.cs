using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float delay;
    public float waitTime;
    public float attTime;
    public bool repeat;
    public float intermissionTime;
    void Start()
    {
        Invoke(nameof(LaserRun), intermissionTime);
    }
    void LaserRun()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        if (repeat) Invoke(nameof(LaserRun), waitTime + attTime + intermissionTime);


        var color = ColorManager.Instance.nextColorPalette.bulletColor;
        color.a = 0.5f;
        GetComponent<SpriteRenderer>().color = color;

        tag = "Untagged";
        transform.localScale = Vector3.right;
        var seq = LeanTween.sequence();
        seq.append(LeanTween.scale(gameObject, Vector3.right + Vector3.up * 0.87f, waitTime).setEaseOutCubic());
        seq.append(() => LaserRun2());
    }
    void LaserRun2()
    {
        tag = "Bullet";
        GetComponent<BoxCollider2D>().enabled = true;
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;
        GetComponent<SpriteRenderer>().color = ColorManager.Instance.nextColorPalette.bulletColor;
        
        var seq = LeanTween.sequence();
        seq.append(LeanTween.scale(gameObject, Vector3.right, attTime).setEaseInCubic());
        seq.append(() => tag = "Untagged");
        seq.append(() => GetComponent<BoxCollider2D>().enabled = false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
