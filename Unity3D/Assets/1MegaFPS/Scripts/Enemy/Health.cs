using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public float health;

    public void takeADamage(float damage)
    {
        health -= damage;
    }

    public bool isDead()
    {
        if (health > 0)
            return false;
        else return true;
    }
}
