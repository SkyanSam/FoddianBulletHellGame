using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    SpriteRenderer sprRenderer;
    public Vector2 velocity;
    public float speed;
    public float rotation;
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    void Update()
    {
        sprRenderer.color = ColorManager.Instance.currentColorPalette.bulletColor;
        var hit = Physics2D.Raycast(transform.position, velocity.normalized, speed * Time.deltaTime, PlayerMovement.Instance.walllayerMask);
        if (hit.collider != null) Destroy(gameObject);
        else transform.Translate(velocity * speed * Time.deltaTime);
    }
}
