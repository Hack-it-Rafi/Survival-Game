using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float movementSpeed = 3f;
    public float changeDirectionInterval = 2f; // Interval in seconds to change direction
    private float nextDirectionChangeTime = 0f;
    private Vector3 currentDirection;
    private Animator anim;
    private Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        ChooseRandomDirection();
    }

    void Update()
    {
        Move();
        if (Time.time >= nextDirectionChangeTime)
        {
            ChooseRandomDirection();
            nextDirectionChangeTime = Time.time + changeDirectionInterval;
        }
    }

    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentDirection), 0.15f);
        transform.Translate(currentDirection * movementSpeed * Time.deltaTime, Space.World);
        anim.SetInteger("Walk", 1);
    }

    void ChooseRandomDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomZ = Random.Range(-1f, 1f);
        currentDirection = new Vector3(randomX, 0f, randomZ).normalized;
    }
}
