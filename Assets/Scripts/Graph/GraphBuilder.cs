// (c) Simone Guggiari 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////// DESCRIPTION //////////

//[ExecuteAlways]
public class GraphBuilder : MonoBehaviour {
    // --------------------- VARIABLES ---------------------

    // public
    public bool startBuilding;
    public bool addVertices, addEdges;

    // private
    Vertex startingV;

    Graph graphtoBuild;
    public float roundRange = 1f;


    // references
	
	
	// --------------------- BASE METHODS ------------------
	void Start () {

	}

    void Update () {
        EditorUpdate();
    }

    // --------------------- CUSTOM METHODS ----------------


    // commands
    public void EditorUpdate() {

        if (startBuilding) {
            startBuilding = false;
            GameObject graphObject = new GameObject("graph to build");
            graphtoBuild = graphObject.AddComponent<Graph>();
            Debug.Log("start building");
        }

        //if (graphtoBuild == null) return;

        if (addVertices) {
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("add vertex");
                graphtoBuild.AddVertex(Utility.MousePosition());
            }
        }
        if (addEdges) {
            if (Input.GetMouseButtonDown(0)) {
                startingV = ClosestVertex();
            }
            if (Input.GetMouseButtonUp(0)) {
                Vertex endV = ClosestVertex();
                graphtoBuild.AddEdge(startingV, endV);
                Debug.Log("add edge");
            }
        }
    }

    [ContextMenu("round edges")]
    void RoundEdges() {
        Vertex[] vertices = FindObjectsOfType<Vertex>();
        foreach(Vertex v in vertices) {
            Vector3 p = v.position;
            p.x = Mathf.Round(p.x / roundRange) * roundRange;
            p.y = Mathf.Round(p.y / roundRange) * roundRange;
            p.z = Mathf.Round(p.z / roundRange) * roundRange;
            v.position = p;
        }
    }

    // queries
    Vertex ClosestVertex() {
        Vector3 mousePos = Utility.MousePosition();
        return Utility.GetMin(graphtoBuild.Vertices, v => Vector3.SqrMagnitude(mousePos - v.position));
    }


    // other
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if (addEdges && Input.GetMouseButton(0) && startingV != null)
            Gizmos.DrawLine(startingV.position, Utility.MousePosition());
    }


}