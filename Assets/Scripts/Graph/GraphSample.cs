using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphSample : MonoBehaviour
{

    public Vertex[] vertices;
    public Edge[] edges;

    public Graph sampleGraph;

    private void Awake() {
        CreateGraph();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateGraph() {
        sampleGraph = new Graph();
        foreach(Vertex v in vertices) {
            sampleGraph.AddVertex(v);
        }
        foreach(Edge e in edges) {
            sampleGraph.AddEdge(e);
        }
    }

}
