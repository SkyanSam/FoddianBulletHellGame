using UnityEngine;
public class RotateDegPerSec : MonoBehaviour
{
    public float offsetRotation;
    public float rotation;
    public float second;
    float timer = 0;
    //BulletSpawner bulletSpawner;
    private void Start()
    {
        //bulletSpawner = GetComponent<BulletSpawner>();
    }
    void Update() {
        if (timer == 0) timer = second;
        transform.rotation = Quaternion.Euler(0, 0, (rotation * (timer / second)) + offsetRotation);
        
        /*if (bulletSpawner != null)
        {
            bulletSpawner.offsetRotation = (rotation * timer) + offsetRotation;
        }*/

        timer -= Time.deltaTime;
    }
}
