using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationPull : MonoBehaviour
{
    private myVector position;
    private myVector acceleration;

    [SerializeField] float mass = 1;
    [SerializeField] float Massivemass = 1;
    [SerializeField] private myVector velocity;

    [SerializeField] Transform massiveMass;

    [Range(0, 1)] [SerializeField] float damping = 1;
    [Range(0, 1)] [SerializeField] float gravity = -9.8f;

    private void Start()
    {

        position.x = transform.position.x;
        position.y = transform.position.y;

    }
    private void FixedUpdate()
    {

        myVector r = new myVector();

        r.x = massiveMass.position.x - transform.position.x;
        r.y = massiveMass.position.y - transform.position.y;

        float rMagnitude = r.magnitude;
        myVector F = r.normalized * (1 / Massivemass * mass / rMagnitude * rMagnitude);

        float weightScalar = mass * gravity;
        myVector weight = new myVector(0, weightScalar);
        acceleration *= 0f;

        ApplyForce(F);
        Move();

        F.Draw(Color.blue, position);

    }
    private void Update()
    {

        velocity.Draw(Color.red, position);

    }
    public void Move()
    {

        velocity += acceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        transform.position = position;

    }
    void ApplyForce(myVector force)
    {

        acceleration += force * (1f / mass);

    }
}
