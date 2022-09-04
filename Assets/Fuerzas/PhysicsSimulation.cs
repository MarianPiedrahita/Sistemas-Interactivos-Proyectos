using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsSimulation : MonoBehaviour
{

    private myVector position;
    private myVector velocity;
    private myVector acceleration;

    [SerializeField] float mass = 1;
    [SerializeField] myVector wind;
    [Range(0, 1)] [SerializeField] float frictionCof;

    [SerializeField] bool fluidFriction = false;
    [Range(0, 1)] [SerializeField] float damping = 1;
    [Range(0, 1)] [SerializeField] float gravity = -9.8f;

    private void Start()
    {
        position.x = transform.position.x;
        position.y = transform.position.y;
    }


    private void FixedUpdate()
    {
        float weightScale = mass * gravity;
        myVector weight = new myVector(0, weightScale);
        myVector friction = velocity.normalized * frictionCof * -weightScale * -1;
        acceleration *= 0f;

        ApplyForce(wind);
        ApplyForce(weight);
        ApplyForce(friction);
        if (fluidFriction && position.y <= 0f)
        {

            float velocityMagnitude = velocity.magnitude;
            float frontalArea = transform.localScale.x;
            myVector fluidFriction = velocity.normalized * frontalArea * velocityMagnitude * velocityMagnitude * -0.5f;
            ApplyForce(fluidFriction);
            fluidFriction.Draw(Color.blue, position);

        }

        friction.Draw(Color.green, position);
        Move();
    }


    private void Update()
    {

        velocity.Draw(Color.red, position);

    }


    public void Move()
    {

        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;


        if (Mathf.Abs(position.x) >= 5)
        {
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
            velocity *= damping;
        }
        if (Mathf.Abs(position.y) >= 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
            velocity *= damping;
        }

        transform.position = position;

    }


    void ApplyForce(myVector force)
    {

        acceleration += force * (1f / mass);

    }
}