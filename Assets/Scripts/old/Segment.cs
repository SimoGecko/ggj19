using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Segment : MonoBehaviour {

    /*

    public Color from, to;

    //to build
    public float radius = .25f;
    public float startAngle = 0;
    public float endAngle = 90;
    public int numSegmentsPerCircle = 16;

    public Vector3[] points; // local space
    

    Vector3 Wpoint(int i) { // world point
        return transform.TransformPoint(points[i]);
    }
    public Vector3[] Wpoints() {
        return points.Select(v => transform.TransformPoint(v)).ToArray();
    }

    public float Length() {
        float result = 0;
        Vector3[] mpw = Wpoints();
        for (int i = 0; i < mpw.Length-1; i++) {
            result += Vector3.Distance(mpw[i], mpw[i + 1]);
        }
        return result;
    }

    [ContextMenu("Generate Circle")]
    void CreateCircleSegment() {
        List<Vector3> res = new List<Vector3>();
        float segAngle = 360f / numSegmentsPerCircle;
        for (float a = startAngle; a <= endAngle; a += segAngle) {
            res.Add(new Vector3(Mathf.Cos(a * Mathf.Deg2Rad), 0, Mathf.Sin(a * Mathf.Deg2Rad)) * radius);
        }
        points = res.ToArray();
    }

    private void OnDrawGizmos() {
        if (points != null) {
            for (int i = 0; i < points.Length - 1; i++) {
                Gizmos.color = Color.Lerp(from, to, ((float)i) / (points.Length - 2));
                Gizmos.DrawLine(Wpoint(i), Wpoint(i + 1));
            }
        }
    }

    */

}
