using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour
{
    public float range;
    public float wait;
    private float countToShot = 0f;

    public GameObject ammo;
    public float damage;

    // Update is called once per frame
    void Update()
    {
        if (countToShot < wait)
            countToShot += Time.deltaTime;

        if(Input.GetMouseButton(0) && countToShot>=wait)
        {
            countToShot = 0;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray, out hitInfo, range))
            {
                Vector3 hitPoint = hitInfo.point;
                GameObject hitObject = hitInfo.collider.gameObject;

                Debug.Log("Hit object: " + hitObject.name);
                if(hitObject.tag == "Enemy")
                    hit(hitObject);
                if (ammo != null)
                {
                    Instantiate(ammo, hitPoint, Quaternion.identity);
                }
            }
        }

    }

    void hit(GameObject hitObject)
    {
        Health health = hitObject.GetComponent<Health>();

        if(health !=null)
        {
            health.takeADamage(damage);
        }
    }
}
