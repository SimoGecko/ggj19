using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smooth : MonoBehaviour
{

    public float streetDist = 1f;
    public float streetMargin = 2f;

    public bool showLines = true;

    Graph graph;

    // Start is called before the first frame update
    void Start()
    {
        graph = GetComponent<Graph>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnDrawGizmos() {
        if (!showLines) return;

        //call this shit here
        graph = GetComponent<Graph>();

        foreach(Edge e in graph.Edges) {
            //draw above and below
            Vector3 dir = (e.v.position-e.u.position).normalized;
            Vector3 tan = Vector3.Cross(dir, Vector3.up);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(e.u.position + tan * streetDist, e.v.position + tan * streetDist);
            Gizmos.DrawLine(e.u.position - tan * streetDist, e.v.position - tan * streetDist);

            Gizmos.color = Color.grey;
            Gizmos.DrawLine(e.u.position + tan * streetMargin, e.v.position + tan * streetMargin);
            Gizmos.DrawLine(e.u.position - tan * streetMargin, e.v.position - tan * streetMargin);
        }
    }
}
