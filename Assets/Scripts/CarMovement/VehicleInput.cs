// (c) Simone Guggiari 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

////////// DESCRIPTION //////////

public class VehicleInput : MonoBehaviour {
    // --------------------- VARIABLES ---------------------

    // public
    public float distToConnect = 1f;


    // private
    Graph graphToFollow;
    VehicleMovement vehicle;
    List<Vertex> vertices = new List<Vertex>();
    //List<Vector3> points = new List<Vector3>();

    bool dragging;

    // references


    // --------------------- BASE METHODS ------------------
    void Start () {
        vehicle = FindObjectOfType<VehicleMovement>();
	}
	
	void Update () {
        if(graphToFollow==null)
            graphToFollow = FindObjectOfType<Graph>();
        if (!dragging && Input.GetMouseButtonDown(0))
            StartDragging();
        if (dragging) {
            ContinueDragging();
            if (Input.GetMouseButtonUp(0)) {
                EndDragging();
            }
        }
	}

    // --------------------- CUSTOM METHODS ----------------


    // commands
    void StartDragging() {
        dragging = true;
        vertices.Clear();
    }
    void ContinueDragging() {
        Vertex closest = Closest();
        bool closeEnough = Vector3.Distance(closest.position, Utility.MousePosition()) < distToConnect;
        bool notDuplicate = !vertices.Contains(closest);
        bool connected = vertices.Count==0 || graphToFollow.IsConnected(vertices.Last(), closest);
        bool first = vertices.Count == 0;
        if (closeEnough && notDuplicate && (connected || first)) vertices.Add(closest);
    }
    void EndDragging() {
        dragging = false;
        vehicle.GetPath(vertices.Select(x => x.position).ToList());
    }



    // queries
    Vertex Closest() {
        Vector3 mousePos = Utility.MousePosition();
        return Utility.GetMin(graphToFollow.Vertices, v => Vector3.SqrMagnitude(mousePos - v.position));
    }


    // other

}