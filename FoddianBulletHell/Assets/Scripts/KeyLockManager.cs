using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLockManager : MonoBehaviour
{
    public static KeyLockManager Instance;
    public bool firstKeyCollected { get; set; } = false;
    public bool secondKeyCollected { get; set; } = false;

    public SpriteRenderer firstLock;
    public SpriteRenderer secondLock;
    public GameObject firstLockBarrier;
    public GameObject secondLockBarrier;
    public void Start()
    {
        Instance = this;
    }
    private void Update()
    {
        firstLock.enabled = !firstKeyCollected;
        firstLockBarrier.SetActive(!firstKeyCollected);
        secondLock.enabled = !firstKeyCollected;
        secondLockBarrier.SetActive(!firstKeyCollected);
    }
}
