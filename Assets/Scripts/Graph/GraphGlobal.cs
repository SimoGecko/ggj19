using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphGlobal : MonoBehaviour
{
    public float joinDist = .1f;

    //List<Transform> allVertices = new List<Transform>();
    //List<EdgeSegment> allEdges = new List<EdgeSegment>();
    public Transform[] v;
    public EdgeSegment[] e;


    List<Transform> vertices = new List<Transform>();
    List<EdgeSegment> edges = new List<EdgeSegment>();

    Dictionary<Transform, int> verticesDic = new Dictionary<Transform, int>();

    // Start is called before the first frame update
    void Start()
    {
        BuildGlobalGraph();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildGlobalGraph() {
        GraphPiece[] pieces = FindObjectsOfType<GraphPiece>();
        foreach (GraphPiece p in pieces) {

            foreach(Transform t in p.vertices) {
                bool joined = false;
                for (int j = 0; j < vertices.Count; j++) { // look for one already inserted close enough
                    if (Vector3.Distance(t.position, vertices[j].position) < joinDist) {
                        //join them 
                        joined = true;
                        verticesDic.Add(t, j); // map the j to the right index (already existing)
                        break;
                    }
                }
                if (!joined) {
                    vertices.Add(t);
                    verticesDic.Add(t, vertices.Count-1);
                }
            }
        }
        //join them
        foreach (GraphPiece p in pieces) {
            Transform[] vs = p.vertices;

            foreach(EdgeSegment e in p.edges) {
                e.from = verticesDic[vs[e.from]];
                e.to = verticesDic[vs[e.to]];
                edges.Add(e);
            }
        }
        //show it
        v = vertices.ToArray();
        e = edges.ToArray();

    }
}
