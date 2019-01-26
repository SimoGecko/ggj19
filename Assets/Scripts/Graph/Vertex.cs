using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vertex : MonoBehaviour
{
    public int id;

    public Vertex() { }

    public Vertex(int id, Vector3 position) {
        this.id = id;
        this.position = position;
    }
    
    public Vector3 position {
        get { return transform.position; }
        set { transform.position = value; }
    }
}
