using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoles : MonoBehaviour
{
    [SerializeField] Transform target;

    private myVector position;
    private myVector displacement;

    [SerializeField] private myVector velocity; 
    [SerializeField] private myVector acceleration;

    private int currentAccelIndex = 0;
    myVector[] accelerations = { new myVector(0, -9.8f), new myVector(9.8f, 0f), new myVector(0, 9.8f), new myVector(-9.8f, 0f), };


    private void Start()
    {

        position.x = transform.position.x;
        position.y = transform.position.y;

    }
    private void FixedUpdate()
    {

        Move();

    }
    private void Update()
    {
        position.Draw(Color.red);
        displacement.Draw(Color.green, position);
        velocity.Draw(Color.blue, position);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            velocity *= 0;
            acceleration = accelerations[(++currentAccelIndex) % accelerations.Length];

        }

        acceleration.x = target.position.x - transform.position.x;
        acceleration.y = target.position.y - transform.position.y;
    }
    public void Move()
    {
        
        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        
        transform.position = position;

    }

}