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


    // private
    public bool directed = false;

    List<Vertex> vertices = new List<Vertex>();
    Dictionary<Vertex, List<Edge>> edges = new Dictionary<Vertex, List<Edge>>();

    // references
	
    // --------------------- CUSTOM METHODS ----------------


    // commands
    public void AddVertex(Vector3 p) {
        AddVertex(new Vertex(p, NumVertices));
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


    // queries
    int NumVertices { get { return vertices.Count; } }
    int NumEdges { get { return Edges.Length; } }

    public Vertex[] Vertices { get { return vertices.ToArray(); } }
    public Edge[] Edges { get { return edges.Values.SelectMany(x => x).ToArray(); } }

    // other
    /*
    public void SaveToFile(string savePath) {
        string result = "";
        result += string.Format("{0},{1}\n", NumVertices, NumEdges);
        foreach (Vertex v in vertices) {
            result += Utility.Serialize(v) + "\n";
        }
        foreach (Edge e in edges) {
            result += Utility.Serialize(e) + "\n";
        }
        System.IO.File.WriteAllText(savePath, result);
    }

    public void LoadFromFile(string savePath) {
        vertices.Clear();
        edges.Clear();

        string[] lines = System.IO.File.ReadAllLines(savePath);
        int n = int.Parse(lines[0].Split(',')[0]);
        int m = int.Parse(lines[0].Split(',')[1]);

        for (int i = 1; i < n+1; i++) {
            AddVertex(Utility.Deserialize<Vertex>(lines[i]));
        }
        for (int i = n+1; i < n+m+1; i++) {
            AddEdge(Utility.Deserialize<Edge>(lines[i]));
        }
    }*/

    public Edge GetEdge(Vertex u, Vertex v) {
        return edges[u].Find(e => e.v == v);
    }

    public Edge[] Outgoing(Vertex v) {
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
            res.Add(GetEdge(vs[i], vs[i + 1]));
        }
        return res.ToArray();
    }


    private void OnDrawGizmos() {
        if (this != null) {
            Gizmos.color = Color.black;
            foreach (Vertex v in Vertices) {
                Gizmos.DrawWireSphere(v.position, .1f);
            }
            foreach (Edge e in Edges) {
                Gizmos.DrawLine(e.u.position, e.v.position);
            }
        }
    }

}
