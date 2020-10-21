using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveVelocity : MonoBehaviour
{
    // Script to set movement speed
    [SerializeField] float speed;
    Vector3 velocityVector;
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 velocity)
    {
        velocityVector = velocity;
    }
    public void SetSpeed(float s)
    {
        speed = s;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = velocityVector * speed;
    }
}
