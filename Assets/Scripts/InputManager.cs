// (c) Simone Guggiari 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

////////// DESCRIPTION //////////

public class InputManager : MonoBehaviour {
    // --------------------- VARIABLES ---------------------

    // public
    public float distToConnect = 1f;


    // private
    Graph graphToFollow;
    Car car;
    List<Vertex> vertices = new List<Vertex>();
    //List<Vector3> points = new List<Vector3>();

    bool dragging;

    // references


    // --------------------- BASE METHODS ------------------
    void Start () {
        car = FindObjectOfType<Car>();
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
        bool connected = true;
        bool first = vertices.Count == 0;
        if (closeEnough && notDuplicate && (connected || first)) vertices.Add(closest);
    }
    void EndDragging() {
        dragging = false;
        car.GetPath(vertices.Select(x => x.position).ToList());
    }



    // queries
    Vertex Closest() {
        Vector3 mousePos = Utility.MousePosition();
        return Utility.GetMin(graphToFollow.Vertices, v => Vector3.SqrMagnitude(mousePos - v.position));
    }


    // other

}