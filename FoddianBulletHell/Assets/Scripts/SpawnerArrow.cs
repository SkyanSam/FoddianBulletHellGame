using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerArrow : MonoBehaviour
{
    //public Vector2 direction;
    public GameObject arrow;
    public float delayTime;
    public float waitTime;
    public float attTime;
    public int spawnCount;
    public float spawnRate
    {
        get
        {
            return attTime / (float)spawnCount;
        }
    }
    public float range = 5;
    void Start()
    {
        if (delayTime == 0) Wait();
        else Delay();
    }
    public void Delay()
    {
        Invoke(nameof(Wait), delayTime);
    }

    public void Wait()
    {
        Invoke(nameof(Att), waitTime);
    }

    public void Att()
    {
        for (int i = 0; i < spawnCount; i++) Invoke(nameof(Spawn), spawnRate * i);
        Invoke(nameof(Wait), attTime);
    }
    public void Spawn()
    {
        var a = Instantiate(arrow, transform.position + Vector3.up * Random.Range(-range,range), Quaternion.identity);
        //a.GetComponent<FlyingArrow>().direction = direction;
    }
}
