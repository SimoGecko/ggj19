// (c) Simone Guggiari 2018

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////// DESCRIPTION //////////

public class GraphBuilder : MonoBehaviour {
    // --------------------- VARIABLES ---------------------

    // public
    public bool addVertices, addEdges;
    public bool saveLoad;
    public bool autoLoad = true;
    public string savePath = "Assets/Text/graph.txt";

    // private
    Vertex startingV;
    Graph graphtoBuild;



    // references
	
	
	// --------------------- BASE METHODS ------------------
	void Start () {
        GameObject graphObject = new GameObject("graphObject");
        graphtoBuild = graphObject.AddComponent<Graph>();

        if (autoLoad) Load();
	}
	
	void Update () {
        if (addVertices) {
            if (Input.GetMouseButtonDown(0)) {
                graphtoBuild.AddVertex(Utility.MousePosition());
            }
        }
        if (addEdges) {
            if (Input.GetMouseButtonDown(0)) {
                startingV = Closest();
            }
            if (Input.GetMouseButtonUp(0)) {
                Vertex endV = Closest();
                graphtoBuild.AddEdge(startingV, endV);
            }
        }

        if (saveLoad) {
            if (Input.GetKeyDown(KeyCode.S)) Save();
            if (Input.GetKeyDown(KeyCode.L)) Load();
        }
	}

    // --------------------- CUSTOM METHODS ----------------


    // commands
    void Save() {
        //graphtoBuild.SaveToFile(savePath);//Utility.SerializeObject(graphtoBuild, savePath);
    }

    void Load() {
        //graphtoBuild.LoadFromFile(savePath);
    }


    // queries
    Vertex Closest() {
        Vector3 mousePos = Utility.MousePosition();
        return Utility.GetMin(graphtoBuild.Vertices, v => Vector3.SqrMagnitude(mousePos - v.position));
    }


    // other
    

}