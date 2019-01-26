﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPiece : MonoBehaviour
{

    public string xJunction = "1,2, 1,4, 1,6, 1,0, 3,4, 3,6, 3,0, 3,2, 5,6, 5,0, 5,2, 5,4, 7,0, 7,2, 7,4, 7,6"; // X junction
    public string iJunction = "1,2, 1,0, 3,0, 3,2";

    public string junction;


    public Transform[] vertices;
    public Segment[] segments;
    public EdgeSegment[] edges;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("generate edges")]
    void GenerateEdges() {
        //find vertices

        //find segments


        //generate edges
        List<EdgeSegment> res = new List<EdgeSegment>();
        string[] pieces = junction.RemoveSpaceAndTabs().Split(',');
        Debug.Log("pc=" + pieces.Length);
        Debug.Log("sl=" + segments.Length);
        Debug.Assert(segments.Length == pieces.Length / 2, "segment size mismatch");

        for (int i = 0; i < pieces.Length; i += 2) {
            int fr = int.Parse(pieces[i]);
            int to = int.Parse(pieces[i + 1]);
            res.Add(new EdgeSegment(fr, to, segments[i / 2]));
        }
        edges = res.ToArray();
    }


    private void OnDrawGizmos() {
        Gizmos.color = Color.black;
        if (vertices != null) {
            foreach(Transform t in vertices) {
                Gizmos.DrawSphere(t.position, .02f);
            }
        }
        Gizmos.color = Color.grey;
        foreach (EdgeSegment e in edges) {
            if (e != null) {
                //Gizmos.DrawLine(vertices[e.from].position, vertices[e.to].position);
            }
        }
    }

    
}

[System.Serializable]
public class EdgeSegment {
    public int from, to;
    public Segment seg;

    public EdgeSegment(int from, int to, Segment seg) {
        this.from = from;
        this.to = to;
        this.seg = seg;
    }
}
