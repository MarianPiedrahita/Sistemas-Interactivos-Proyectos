using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class testVector : MonoBehaviour
{
    [SerializeField] myVector myFirstVector;

    [SerializeField] myVector mySecondVector; 

    [SerializeField, Range(0, 1)] float escalar;

    void Start()
    {

        escalar = 0f;

    }
    void Update()
    {

        myFirstVector.Draw(Color.blue);
        mySecondVector.Draw(Color.red);


        myVector lerp = myFirstVector.Lerp(mySecondVector, escalar);
        lerp.Draw(Color.white);


        myVector diferencia = myFirstVector - lerp;
        diferencia.Draw(Color.green, lerp);

    }
}