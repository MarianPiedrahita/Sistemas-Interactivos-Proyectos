using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixDraw : MonoBehaviour
{
    //Informacion de matriz
    [SerializeField] Vector3 position;
    [SerializeField] Vector3 rotation;
    [SerializeField] Vector3 scale;

    //dibujo
    [SerializeField] Transform shapeOrigin;
    [SerializeField] float boxSize = 0.30f;
    [SerializeField] int boxNumber = 15;
    [SerializeField] bool XtoY = true;
    [SerializeField] bool ZtoX = true;
    [SerializeField] bool YtoZ = true;
    
    Matrix4x4 matrix;
    Vector3 shapeOriginStartinPosition;


    private void Start()
    {
        shapeOriginStartinPosition = shapeOrigin.position;
    }

    private void Update()
    {

        matrix = Matrix4x4.TRS(position, Quaternion.Euler(rotation), scale);
        UpdateObject();
        BaseDraw();
        PlaneDraw();

    }

    private void UpdateObject()
    {

        if (shapeOrigin == null) return;
        shapeOrigin.position = shapeOriginStartinPosition;
        shapeOrigin.position = matrix.MultiplyPoint3x4(shapeOrigin.position);

    }

    private void BaseDraw()
    {

        Vector3 pos = matrix.GetColumn(3);
        Debug.DrawRay(pos, matrix.GetColumn(0), Color.white);
        Debug.DrawRay(pos, matrix.GetColumn(1), Color.blue);
        Debug.DrawRay(pos, matrix.GetColumn(2), Color.green);

    }

    private void PlaneDraw()
    {

        Vector3 pos = matrix.GetColumn(3);
        Vector3 xAxis = matrix.GetColumn(0);
        Vector3 yAxis = matrix.GetColumn(1);
        Vector3 zAxis = matrix.GetColumn(2);
        if (XtoY) GridDraw(pos, xAxis, yAxis, scale.x, scale.y);
        if (ZtoX) GridDraw(pos, zAxis, xAxis, scale.z, scale.x);
        if (YtoZ) GridDraw(pos, yAxis, zAxis, scale.y, scale.z);

    }

    private void GridDraw(Vector3 pos, Vector3 xAxis, Vector3 yAxis, float scaleX, float scaleY)
    {

        for (int i = 1; i <= boxNumber; ++i)
        {

            Debug.DrawRay(pos + xAxis * boxSize * i, yAxis.normalized * boxSize * boxNumber * Mathf.Abs(scaleY));
            Debug.DrawRay(pos + yAxis * boxSize * i, xAxis.normalized * boxSize * boxNumber * Mathf.Abs(scaleX));

        }

    }
}
