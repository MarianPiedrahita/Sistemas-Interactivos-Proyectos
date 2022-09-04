using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    [System.Serializable] public struct myVector 
{
    public float x;
    public float y;

    public float magnitude => Mathf.Sqrt(x * x + y * y);


    public myVector normalized
    {
        get
        {
            float distance = magnitude;

            if (distance < 0.0001f)
            {
                return new myVector(0, 0);
            }
            return new myVector(x / distance, y / distance);
        }
    }

    public myVector(float x, float y)
    {

        this.x = x;
        this.y = y;

    }

    public override string ToString()
    {
        return $"[{x},{y}]";
    }

    public static implicit operator Vector3(myVector origin)
    {

        return new Vector3(origin.x, origin.y, 0);

    }


    public myVector Lerp(myVector b, float c)
    {

        return (this + (b - this) * c);

    }

    public void Draw(Color color)
    {

        Debug.DrawLine(Vector3.zero, new Vector3(x, y, 0), color, 0);

    }

    public void Draw(Color color, myVector origen)
    {

        Debug.DrawLine(new Vector3(origen.x, origen.y, 0), new Vector3(x + origen.x, y + origen.y, 0), color);

    }

    public void Normalize()
    {

        float magnitudeCache = magnitude;
        if (magnitudeCache < 0.001)
        {
            x = 0;
            y = 0;
        }
        else
        {
            x = x / magnitudeCache;
            y = y / magnitudeCache;
        }

    }

    public myVector Suma(myVector other)
    {

        return new myVector(x + other.x, y + other.y);

    }

    public myVector Subs(myVector other)
    {

        return new myVector(x - other.x, y - other.y);

    }
    public myVector Scale(float other)
    {

        return new myVector(x * other, y * other);

    }

    public static myVector operator +(myVector a, myVector b)
    {

        return a.Suma(b);

    }

    public static myVector operator -(myVector a, myVector b)
    {

        return a.Subs(b);

    }

    public static myVector operator *(myVector a, float b)
    {

        return a.Scale(b);

    }
    public static myVector operator *(float b, myVector a)
    {

        return a.Scale(b);

    }

}

public struct MystructVector 
                             
{

    private float myX;
    private float myY;


}