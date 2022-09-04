using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingWind : MonoBehaviour
{
    private myVector position, velocity, acceleration;

    [SerializeField] float mass = 1;
    [SerializeField] myVector wind;
    [SerializeField] myVector gravity;
    [Range(0, 1)] [SerializeField] float damping = 1;


    private void Start()
    {

        position.x = transform.position.x;
        position.y = transform.position.y;

    }



    private void FixedUpdate()
    {

        acceleration *= 0f;

        ApplyForce(wind);
        ApplyForce(gravity);

        Move();

    }



    private void Update()
    {

        position.Draw(Color.red);
        velocity.Draw(Color.cyan, position);
        acceleration.Draw(Color.white, position);

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
