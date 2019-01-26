// (c) Simone Guggiari 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

////////// DESCRIPTION //////////

public class InputManager : MonoBehaviour {
    // --------------------- VARIABLES ---------------------

    // public
    /*
    public float distToConnect = 1f;


    // private
    Graph graphToFollow;
    Car car;
    List<Vertex> vertexList = new List<Vertex>();
    //List<Vector3> points = new List<Vector3>();

    bool dragging;
    LineRenderer lr;

    // references


    // --------------------- BASE METHODS ------------------
    void Start () {
        car = FindObjectOfType<Car>();
        //graphToFollow = GetComponent<GraphGlobal>().global;
        graphToFollow = GetComponent<GraphSample>().sampleGraph;
        lr = GetComponent<LineRenderer>();
        //vertexList = GetComponent<GraphGlobal>().v.ToList();
	}
	
	void Update () {
        
        if (!dragging && Input.GetMouseButtonDown(0)) {
            StartDragging();
        }
        if (dragging) {
            ContinueDragging();
            if (Input.GetMouseButtonUp(0)) {
                EndDragging();
            }
        }

        SetLine();
	}

    // --------------------- CUSTOM METHODS ----------------


    // commands
    void StartDragging() {
        dragging = true;
        vertexList.Clear();
    }
    void ContinueDragging() {
        Vertex closest = Closest();
        bool closeEnough = Vector3.Distance(closest.position, Utility.MousePosition()) < distToConnect;
        bool notDuplicate = !vertexList.Contains(closest);
        bool connected = vertexList.Count == 0 || graphToFollow.IsConnected(vertexList[vertexList.Count - 1], closest); // TODO
        if (closeEnough && notDuplicate && connected ) vertexList.Add(closest);
    }
    void EndDragging() {
        dragging = false;
        car.GetPath(vertexList.Select(x => x.position).ToList());
    }

    void SetLine() {
        
        for (int i = 0; i < vertexList.Count-1; i++) {

        }
        Vector3[] pointlist = PointList().ToArray();
        lr.positionCount = pointlist.Length;
        //lr.SetPositions(vertexList.Select(v => v.position).ToArray());
        lr.SetPositions(pointlist);
    }

    List<Vector3> PointList() {

        Edge[] edges = graphToFollow.EdgeList(vertexList);
        if (edges.Length > 0) {
            List<Vector3> res = new List<Vector3>();
            foreach (Edge e in edges) {
                Debug.Assert(e != null, "e null");
                Debug.Assert(e.u != null, "e.u null");
                res.Add(e.u.position);
                if (e.s != null) {
                    List<Vector3> segm = e.s.points.ToList();
                    segm.RemoveAt(0);
                    segm.RemoveAt(segm.Count - 1);
                    res.AddRange(segm);
                }
            }
            res.Add(edges[edges.Length - 1].v.position);
            return res;
        }
        return new List<Vector3>();
    }



    // queries
    Vertex Closest() {
        Vector3 mousePos = Utility.MousePosition();
        return Utility.GetMin(graphToFollow.Vertices, v => Vector3.SqrMagnitude(mousePos - v.position));
    }


    // other
    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        for (int i = 0; i < vertexList.Count-1; i++) {
            Gizmos.DrawLine(vertexList[i].position, vertexList[i + 1].position);
        }
   }*/
    

}