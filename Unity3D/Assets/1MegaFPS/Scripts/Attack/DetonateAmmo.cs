using UnityEngine;
using System.Collections;

public class DetonateAmmo : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float rangeOfExplosion;
    public float damage;

    void OnTriggerEnter()
    {
        Detonate();
    }

    void Detonate()
    {
        Vector3 pointOfDetonate = transform.position;

        if (explosionPrefab != null)
            Instantiate(explosionPrefab, pointOfDetonate, Quaternion.identity);

        Destroy(gameObject);

        Collider[] colliders = Physics.OverlapSphere(pointOfDetonate, rangeOfExplosion);

        foreach(Collider c in colliders)
        {
            Health h = c.GetComponent<Health>();
            if(h!=null)
            {
                float distance = Vector3.Distance(pointOfDetonate, c.transform.position);
                float newDamage = 1f - (distance / rangeOfExplosion);
                h.takeADamage(damage * newDamage);
            }
        }
    }
}
