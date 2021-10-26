using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingArrow : MonoBehaviour
{
    public Vector2 direction = Vector2.left;
    public float speed;
    LineRenderer lineRen;
    EdgeCollider2D edge;
    bool hit
    {
        get
        {
            return _hit;
        }
        set
        {
            _hit = value;
            if (value == true)
                Destroy(gameObject);
        }
    }
    bool _hit = true;
    void Start()
    {
        lineRen = GetComponent<LineRenderer>();
        edge = GetComponent<EdgeCollider2D>();

        var positions = new Vector2[lineRen.positionCount];
        for (int i = 0; i < lineRen.positionCount; i++)
            positions[i] = lineRen.GetPosition(i);
        edge.points = positions;
    }
    void Update()
    {
        var hitRay = Physics2D.Raycast(transform.position, direction.normalized, speed * Time.deltaTime, PlayerMovement.Instance.walllayerMask);

        if (hitRay && !hit) hit = true;
        else if (!hitRay && hit) hit = false;

        transform.position += (Vector3)direction * speed * Time.deltaTime;
        //if (hit.collider != null) 
        //else 
    }
}
