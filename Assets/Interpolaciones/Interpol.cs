using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpol : MonoBehaviour
{ 
    [SerializeField] Transform destiny;
    [SerializeField] float time;
    [SerializeField, Range(0, 1)] float tParameter = 0;
    [SerializeField] Color startColor;
    [SerializeField] Color endColor;
    [SerializeField] private AnimationCurve curve;

    float timePassed;
    Vector3 startPosition;
    Vector3 endPosition;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        tParameter = timePassed / time;
        transform.position = Vector3.LerpUnclamped(startPosition, endPosition, curve.Evaluate(tParameter));
        spriteRenderer.color = Color.LerpUnclamped(startColor, endColor, curve.Evaluate(tParameter));
        timePassed += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {

            StartInterpolation();

        }
    }


    private void StartInterpolation()
    {

        tParameter = 0;
        timePassed = 0;
        startPosition = transform.position;
        endPosition = destiny.position;

    }


    private float EaseInElastic(float x)
    {

        float c5 = (2f * Mathf.PI) / 4.5f;
        return x == 0f
          ? 0f
          : x == 1f
          ? 1f
          : x < 0.5
          ? -(Mathf.Pow(2f, 20f * x - 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f
          : (Mathf.Pow(2f, -20f * x + 10f) * Mathf.Sin((20f * x - 11.125f) * c5)) / 2f + 1f;

    }
}
