using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CubicCurve : MonoBehaviour
{
    public LineRenderer line;
    public Transform p0, p1, p2, p3;

    private int index = 10;
    private Vector3[] pos = new Vector3[10];
    // Start is called before the first frame update
    void Start()
    {       
        line.positionCount = index;
        DrawCubicCurve();
    }

    // Update is called once per frame
    void Update()
    {
        DrawCubicCurve();
    }

    private void DrawCubicCurve()
    {
        for (int i = 1; i < index + 1; i++)
        {
            float t = i / (float)index;
            pos[i - 1] = Cubic_Curve(t, p0.position, p1.position, p2.position, p3.position);
        }
        line.SetPositions(pos);
    }

    
    
    private Vector3 Cubic_Curve(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        //B(t) = (1 - t)3P0 + 3(1 - t)2tP1 + 3(1 - t)t2P2 + t3P3
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;
        Vector3 p = uuu * p0;
        p += 3 * uu * t * p1;
        p += 3 * u * tt * p2;
        p += ttt * p3;
        return p;
    }
}


