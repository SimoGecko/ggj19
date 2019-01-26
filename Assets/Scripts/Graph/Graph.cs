// (c) Simone Guggiari 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

////////// DESCRIPTION //////////

[System.Serializable]
public class Graph : MonoBehaviour{
    // --------------------- VARIABLES ---------------------

    // public
    public bool directed = false;
    public bool showGraph = true;


    // private
    public Vertex[] vsave;
    public Edge[] esave;


    List<Vertex> vertices = new List<Vertex>();
    Dictionary<Vertex, List<Edge>> edges = new Dictionary<Vertex, List<Edge>>();

    // references

    // --------------------- CUSTOM METHODS ----------------
    private void Start() {
        Load();
    }

    // commands
    public void AddVertex(Vector3 p) {
        Vertex newVertex = new GameObject("vertex").AddComponent<Vertex>();
        newVertex.id = NumVertices;
        newVertex.position = p;
        AddVertex(newVertex);
        newVertex.transform.parent = transform;
    }
    public void AddVertex(Vertex v) {
        vertices.Add(v);
        edges.Add(v, new List<Edge>());
    }

    public void AddEdge(Vertex u, Vertex v) {
        edges[u].Add(new Edge(u, v));
        if(!directed)
            edges[v].Add(new Edge(v, u));
    }
    public void AddEdge(Edge e) {
        edges[e.u].Add(e);
    }

    [ContextMenu("Save")]
    public void Save() {
        vsave = Vertices;
        esave = Edges;
    }
    [ContextMenu("Load")]
    public void Load() {
        vertices = vsave.ToList();
        edges = new Dictionary<Vertex, List<Edge>>();
        foreach (Vertex v in vertices) {
            edges.Add(v, new List<Edge>());
        }
        foreach(Edge e in esave) {
            AddEdge(e);
        }
    }


    // queries
    int NumVertices { get { return vertices.Count; } }
    int NumEdges { get { return Edges.Length; } }

    public Vertex[] Vertices { get { return vertices.ToArray(); } }
    public Edge[] Edges { get { return edges.Values.SelectMany(x => x).ToArray(); } }

    public Edge GetEdge(Vertex u, Vertex v) {
        return edges[u].Find(e => e.v == v);
    }

    public Edge[] OutgoingE(Vertex v) {
        return edges[v].ToArray();
    }
    public Vertex[] OutgoingV(Vertex u) {
        return edges[u].Select(x => x.v).ToArray();
    }

    public bool IsConnected(Vertex u, Vertex v) {
        return OutgoingV(v).Contains(u);
    }

    public Edge[] EdgeList(List<Vertex> vs) {
        List<Edge> res = new List<Edge>();
        for (int i = 0; i < vs.Count - 1; i++) {
            Debug.Assert(IsConnected(vs[i], vs[i + 1]), "path is not connected");
            res.Add(GetEdge(vs[i], vs[i + 1]));
        }
        return res.ToArray();
    }

    // other




    private void OnDrawGizmos() {
        if (showGraph) {
            Gizmos.color = Color.black;
            foreach (Vertex v in Vertices) {
                Gizmos.DrawWireSphere(v.position, .2f);
            }
            foreach (Edge e in Edges) {
                Gizmos.DrawLine(e.u.position, e.v.position);
            }
        }
    }

}
