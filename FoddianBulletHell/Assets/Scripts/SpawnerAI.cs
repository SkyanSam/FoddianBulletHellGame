using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAI : MonoBehaviour
{
    public static SpawnerAI Instance;
    public LayerMask layerMask;
    public GameObject bulletSpawner;
    Vector3 velocity;
    public float distance = 1;
    public float minCooldown = 0.5f;
    public float maxCooldown = 2;
    float timer;
    void Start()
    {
        Instance = this;
        timer = Random.Range(minCooldown, maxCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (velocity == Vector3.zero) velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 0.5f;
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            var appearPos = PlayerMovement.Instance.transform.position + (velocity * distance);
            if (Physics2D.OverlapCircle(appearPos, 0.5f, layerMask) == null)
            {
                Instantiate(bulletSpawner, PlayerMovement.Instance.transform.position + (velocity * distance), Quaternion.identity);
                timer = Random.Range(minCooldown, maxCooldown);
            }
        }

    }
}
