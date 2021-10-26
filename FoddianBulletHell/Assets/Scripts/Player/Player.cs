using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int startHp;
    int hp;
    public float bulletCooldown;
    float bulletTimer;
    public bool blinking;
    public float blinkTime;
    public float blinkCount;
    public Color blinkingColor
    {
        get
        {
            var color = ColorManager.Instance.currentColorPalette.playerColor;
            color.a = 0.5f;
            return color;
        }
    }
    Color normalColor
    {
        get
        {
            return ColorManager.Instance.currentColorPalette.playerColor;
        }
    }
    void Start()
    {
        //normalColor = GetComponent<SpriteRenderer>().color;
        hp = startHp;
    }
    void Update()
    {
        bulletTimer -= Time.deltaTime;
        if (hp != 0)
            GetComponent<SpriteRenderer>().color = normalColor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet" /*&& bulletTimer <= 0*/)
        {
            print("haha dead");
            hp -= 1;
            print(hp);
            bulletTimer = bulletCooldown;
        }
        else if (collision.tag == "Event")
        {
            collision.GetComponent<FoddianEvent>().StartEvent();
        }
        if (hp == 0)
        {
            if (blinking)
            {
                StartCoroutine(Blink());
                /*
                var seq = LeanTween.sequence();
                for (int i = 0; i < blinkCount; i++)
                {
                    seq.append(() => GetComponent<SpriteRenderer>().color = normalColor);
                    seq.append(blinkTime / (blinkCount * 2));
                    seq.append(() => GetComponent<SpriteRenderer>().color = blinkingColor);
                    seq.append(blinkTime / (blinkCount * 2));
                }
                seq.append(() => Time.timeScale = 1);
                seq.append(() => UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name));*/
            }
            else
            {
                print("haha switch");
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
            }
        }
        IEnumerator Blink()
        {
            Time.timeScale = 0;
            for (int i = 0; i < blinkCount; i++)
            {
                GetComponent<SpriteRenderer>().color = normalColor;
                yield return new WaitForSecondsRealtime(blinkTime / (blinkCount * 2));
                GetComponent<SpriteRenderer>().color = blinkingColor;
                yield return new WaitForSecondsRealtime(blinkTime / (blinkCount * 2));
            }
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
