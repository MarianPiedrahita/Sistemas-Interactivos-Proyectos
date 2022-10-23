using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmonicMovement : MonoBehaviour
{
    [SerializeField][Range(0, 10)] float period;
    [SerializeField][Range(0, 10)] float amplitude;

    void Update()
    {

        float TimeFactor = Time.time / period;
        float x = amplitude * Mathf.Sin(2 * Mathf.PI * TimeFactor);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
