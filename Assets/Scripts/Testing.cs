using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public LineRenderer line;
    public Transform p0, p1, p2;

    private int index = 10;
    private Vector3[] pos = new Vector3[10];
    // Start is called before the first frame update
    void Start()
    {
        //line = GetComponent<LineRenderer>();
        line.positionCount = index;
        DrawQuadraticCurve();
    }

    // Update is called once per frame
    void Update()
    {
        DrawQuadraticCurve();
    }

    private Vector3 QuadraticCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        //B(t) = (1-t)2P0 + 2(1-t)tP1 + t2P2 , 0 < t < 1
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }

    private void DrawQuadraticCurve()
    {
        for (int i = 1; i < index + 1; i++) 
        {
            float t = i / (float)index;
            pos[i - 1] = QuadraticCurve(t, p0.position, p1.position, p2.position);
        }
        line.SetPositions(pos);
    }
    /*
    private Vector3 CubicCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        //B(t) = (1-t)3P0 + 3(1-t)2tP1 + 3(1-t)t2P2 + t3P3 , 0 < t < 1
        return new Vector3();
    }*/
}
