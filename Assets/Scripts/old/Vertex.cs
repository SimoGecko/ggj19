using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vertex : MonoBehaviour
{
    public int id { get; private set; }

    //public Vertex() { }

    public Vertex(Vector3 position, int id) {
        this.id = id;
        this.position = position;
    }
    
    public Vector3 position {
        get { return transform.position;/* new Vector3(x, y, z);*/ }
        set { transform.position = value;/* x = value.x; y = value.y; z = value.z;*/ }
    }
}
