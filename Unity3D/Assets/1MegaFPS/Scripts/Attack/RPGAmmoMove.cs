using UnityEngine;
using System.Collections;

public class RPGAmmoMove : MonoBehaviour
{
    public float Speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.forward * Speed * Time.deltaTime, Space.World);
    }
}
