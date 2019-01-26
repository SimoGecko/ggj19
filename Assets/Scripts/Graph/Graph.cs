// (c) Simone Guggiari 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////// DESCRIPTION //////////

[System.Serializable]
public class Graph : MonoBehaviour{
    // --------------------- VARIABLES ---------------------

    // public


    // private
    List<Vertex> vertices = new List<Vertex>();
    List<Edge> edges = new List<Edge>();

    // references
	
	
	// --------------------- BASE METHODS ------------------
	void Start () {
        
	}
	
	void Update () {
        
	}

    // --------------------- CUSTOM METHODS ----------------


    // commands
    public void AddVertex(Vector3 p) {
        AddVertex(new Vertex(p, NumVertices));
    }

    
    public void AddVertex(Vertex v) {
        vertices.Add(v);
    }

    public void AddEdge(Vertex u, Vertex v) {
        AddEdge(u.id, v.id);
    }

    public void AddEdge(int u, int v) {
        edges.Add(new Edge(u, v));
        edges.Add(new Edge(v, u));
    }
    public void AddEdge(Edge e) {
        edges.Add(e);
    }


    // queries
    int NumVertices { get { return vertices.Count; } }
    int NumEdges { get { return edges.Count; } }

    public Vertex[] Vertices { get { return vertices.ToArray(); } }
    public Edge[] Edges { get { return edges.ToArray(); } }

    // other
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
    }

    private void OnDrawGizmos() {
        if (this != null) {
            Gizmos.color = Color.black;
            foreach (Vertex v in Vertices) {
                Gizmos.DrawWireSphere(v.position, .1f);
            }
            foreach (Edge e in Edges) {
                Gizmos.DrawLine(Vertices[e.u].position, Vertices[e.v].position);
            }
        }
    }

}

[System.Serializable]
public class Vertex {
    public Vertex() { }

    public int id;
    public float x, y, z;

    public Vertex(Vector3 position, int id) {
        this.id = id;
        this.position = position;
    }
    public Vector3 position {
        get { return new Vector3(x, y, z); }
        set { x = value.x; y = value.y; z = value.z; }
    }
}



[System.Serializable]
public class Edge {
    public Edge() { }

    public int u, v;

    public Edge(int u, int v) {
        this.u = u;
        this.v = v;
    }
}