using UnityEngine;
using System.Collections;

public class AmmoDestroyer : MonoBehaviour
{
    public float countToDestroyAmmo;

    void DestroyAmmo()
    {
        if ((countToDestroyAmmo -= Time.deltaTime) <= 0)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        DestroyAmmo();
    }
}
