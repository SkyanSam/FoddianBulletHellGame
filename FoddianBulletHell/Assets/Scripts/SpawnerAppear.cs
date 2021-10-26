using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAppear : MonoBehaviour
{
    public Color appearColor {
        get
        {
            var color = ColorManager.Instance.nextColorPalette.bulletColor;
            color.a = 0.5f;
            return color;
        }
    }
    public Color dissappearColor
    {
        get
        {
            return ColorManager.Instance.nextColorPalette.bulletColor;
        }
    }
    public float appearTime = 0.2f;
    public float dissapearTime = 0.5f;
    public float normalSize = 1;
    public float halfSize = 0.5f;
    void Start()
    {
        //sprRenderer = GetComponent<SpriteRenderer>();
        transform.localScale = Vector2.zero;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().color = appearColor;
        var sequence = LeanTween.sequence();
        sequence.append(LeanTween.scale(gameObject, Vector2.one * halfSize, appearTime).setEaseOutSine());
        //sequence.append(LeanTween.scale(gameObject, Vector2.one * normalSize, 0));
        sequence.append(() => SecondPart());
        
    }
    public void SecondPart()
    {
        LeanTween.cancel(gameObject);
        var sequence = LeanTween.sequence();
        GetComponent<CircleCollider2D>().enabled = true;
        sequence.append(() => transform.localScale = Vector2.one * normalSize);
        sequence.append(() => GetComponent<BulletSpawner>().SpawnBullets());
        sequence.append(() => GetComponent<SpriteRenderer>().color = dissappearColor);
        sequence.append(LeanTween.scale(gameObject, Vector2.zero, appearTime).setEaseInCubic());
        sequence.append(() => Destroy(gameObject));
    }
}
