using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Edge
{
    public Vertex u, v; // directed u,v
    //public Segment s;

    //constructors
    public Edge() { }

    public Edge(Vertex u, Vertex v) {
        this.u = u;
        this.v = v;
    }

    public Edge(Vertex u, Vertex v, Segment s) {
        this.u = u;
        this.v = v;
        //this.s = s;
    }
}
