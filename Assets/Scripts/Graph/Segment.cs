using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public Color from, to;

    public float radius = .25f;
    public float startAngle = 0;
    public float endAngle = 90;
    public int numSegmentsPerCircle = 16;

    public Vector3[] midPoints; // local space
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 mpWorld(int i) {
        return transform.TransformPoint( midPoints[i]);
    }

    [ContextMenu("Generate Circle")]
    void CreateCircleSegment() {
        List<Vector3> res = new List<Vector3>();
        float segAngle = 360f / numSegmentsPerCircle;
        for (float a = startAngle; a <= endAngle; a+=segAngle) {
            res.Add(new Vector3(Mathf.Cos(a * Mathf.Deg2Rad), 0, Mathf.Sin(a * Mathf.Deg2Rad)) * radius);
        }
        midPoints = res.ToArray();
    }

    private void OnDrawGizmos() {
        if (midPoints != null) {
            for (int i = 0; i < midPoints.Length-1; i++) {
                Gizmos.color = Color.Lerp(from, to, ((float)i) / (midPoints.Length-2));
                Gizmos.DrawLine(mpWorld(i), mpWorld(i+1));
            }
        }
    }
}
