using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphGlobal : MonoBehaviour {
    /*
    public float joinDist = .1f;

    public Vertex[] v;
    public Edge[] e;

    public Graph global;

    Dictionary<Vertex, Vertex> verticesDic = new Dictionary<Vertex, Vertex>(); // mapping from old one to the new one

    // Start is called before the first frame update
    void Start() {
        global = gameObject.AddComponent<Graph>();
        BuildGlobalGraph();
    }

    // Update is called once per frame
    void Update() {

    }

    void BuildGlobalGraph() {
        GraphPiece[] pieces = FindObjectsOfType<GraphPiece>();
        foreach (GraphPiece p in pieces) {

            foreach (Vertex t in p.vertices) {
                bool joined = false;
                for (int j = 0; j < global.Vertices.Length; j++) { // look for one already inserted close enough
                    if (Vector3.Distance(t.position, global.Vertices[j].position) < joinDist) {
                        //join them 
                        joined = true;
                        verticesDic.Add(t, global.Vertices[j]); // map the j to the right index (already existing)
                        break;
                    }
                }
                if (!joined) {
                    global.AddVertex(t);
                    verticesDic.Add(t, t);
                }
            }
        }
        //join them
        foreach (GraphPiece p in pieces) {
            Vertex[] vs = p.vertices;

            foreach (Edge e in p.edges) {
                e.u = verticesDic[e.u];
                e.v = verticesDic[e.v];
                global.AddEdge(e);
            }
        }
        //show it
        v = global.Vertices;
        e = global.Edges;

    }
    */
}
