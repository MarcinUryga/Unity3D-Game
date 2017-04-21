using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour
{
    public Transform hero;
    public Transform enemy;

    public float walkingSpeed;
    public float rotationSpeed;
    public float rangeOfVision;
    public float distanceFromThePlayer;


    private Health health;
    private Vector3 playerPosition;
    private float distance;
    private bool iSeeHero;
    // Use this for initialization
    void Start()
    {
        health = GetComponent<Health>();
        hero = GameObject.FindWithTag("Player").transform;
        enemy = transform;
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    void RotateEnemy()
    {
        Quaternion rotation = Quaternion.LookRotation(playerPosition - enemy.position);
        enemy.rotation = Quaternion.Slerp(enemy.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        iSeeHero = false;
        playerPosition = new Vector3(hero.position.x, enemy.position.y, hero.position.z);

        distance = Vector3.Distance(enemy.position, hero.position);

        if (distance <= rangeOfVision && !health.isDead())
        {
            iSeeHero = true;
            if(distance > distanceFromThePlayer)
                enemy.position = Vector3.MoveTowards(enemy.position, hero.position, walkingSpeed * Time.deltaTime);
        }

        if (iSeeHero)
            RotateEnemy();

        if(health.isDead())
            if (GetComponent<Rigidbody>())
                GetComponent<Rigidbody>().freezeRotation = false;
    }
}
