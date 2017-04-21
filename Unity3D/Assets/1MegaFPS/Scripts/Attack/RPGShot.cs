using UnityEngine;
using System.Collections;

public class RPGShot : MonoBehaviour
{
    public float wait;
    private float countToShot = 0f;

    public GameObject ammo;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1) && (countToShot-=Time.deltaTime) <=0 )
        {
            Instantiate(ammo, Camera.main.transform.position + Camera.main.transform.forward, Camera.main.transform.rotation);
            countToShot = wait;
        }
    }
}
