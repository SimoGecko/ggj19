﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPiece : MonoBehaviour
{
    /*
    public string xJunction = "1,2, 1,4, 1,6, 1,0, 3,4, 3,6, 3,0, 3,2, 5,6, 5,0, 5,2, 5,4, 7,0, 7,2, 7,4, 7,6"; // X junction
    public string iJunction = "1,2, 1,0, 3,0, 3,2";

    public string junction;


    public Vertex[] vertices;
    public Edge[] edges;
    public Segment[] segments;
    
    [ContextMenu("generate edges")]
    void GenerateEdges() {
        //generate edges
        string[] pieces = junction.RemoveSpaceAndTabs().Split(',');
        Debug.Assert(segments.Length == pieces.Length / 2, "segment size mismatch");

        List<Edge> res = new List<Edge>();
        for (int i = 0; i < pieces.Length; i += 2) {
            int fr = int.Parse(pieces[i]);
            int to = int.Parse(pieces[i + 1]);
            res.Add(new Edge(vertices[fr], vertices[to], segments[i / 2]));
        }
        edges = res.ToArray();
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        if (vertices != null) {
            foreach(Vertex v in vertices) {
                if(v!=null)
                    Gizmos.DrawSphere(v.position, .02f);
            }
        }
        Gizmos.color = Color.grey;
        if (edges != null) {
            foreach (Edge e in edges) {
                if (e != null) {
                    //Gizmos.DrawLine(vertices[e.from].position, vertices[e.to].position);
                }
            }
        }
    }
    */
}

/*
[System.Serializable]
public class EdgeSegment {
    public int from, to;
    public Segment seg;

    public EdgeSegment(int from, int to, Segment seg) {
        this.from = from;
        this.to = to;
        this.seg = seg;
    }
}*/
