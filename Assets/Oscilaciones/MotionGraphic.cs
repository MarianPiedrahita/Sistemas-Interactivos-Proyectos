using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionGraphic : MonoBehaviour
{

    // informacion de la linea
    [SerializeField] int circlesNumber;
    [SerializeField] float gapBetweenCircles;
    [SerializeField] float amplitudeLine;
    [SerializeField] private GameObject circle;

    private List<GameObject> newCircles = new List<GameObject>();


    private void Start()
    {
        for (int i = 0; i < circlesNumber; i++)
        {

            var newCircle = Instantiate(circle, transform);
            newCircles.Add(newCircle);

        }
    }


    private void Update()
    {
        for (int i = 0; i < circlesNumber; i++)
        {

            var newCirlce = newCircles[i];
            float x = i * gapBetweenCircles;
            float y = amplitudeLine * Mathf.Sin(i + Time.time);
            newCirlce.transform.localPosition = new Vector3(x, y);

        }
    }
}
