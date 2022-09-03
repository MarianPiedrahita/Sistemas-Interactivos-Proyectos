using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour
{
    [SerializeField] private myVector acceleration;
    private myVector position;
    private myVector velocity;
    private myVector displacement;

    private myVector[] accelerations = new myVector[4] { new myVector(0f, -9.8f), new myVector(9.8f, 0f), new myVector(0f, 9.8f), new myVector(-9.8f, 0f), };

    private int currentAccelIndex = 0;


    void Start()
    {

        position = new myVector(transform.position.x, transform.position.y);

    }

    private void FixedUpdate()
    {

        Move();

    }

    void Update()
    {

        position.Draw(Color.green);
        acceleration.Draw(Color.blue);
        displacement.Draw(Color.clear);
        velocity.Draw(Color.red);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            ChangeDirection();

        }

    }

    public void Move()
    {

        velocity = velocity + acceleration * Time.fixedDeltaTime;
        displacement = velocity * Time.fixedDeltaTime;
        position += displacement;

        if (position.x < -5 || position.x > 5)
        {

            position.x = Mathf.Sign(position.x) * 5;
            velocity.x = -velocity.x;

        }

        if (position.y < -5 || position.y > 5)
        {

            position.y = Mathf.Sign(position.y) * 5;
            velocity.y = -velocity.y;

        }

        transform.position = position;

    }

    public void ChangeDirection()
    {
        velocity *= 0;
        acceleration = accelerations[(currentAccelIndex++) % accelerations.Length];
    }
}