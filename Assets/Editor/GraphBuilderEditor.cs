using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GraphBuilder))]
public class GraphBuilderEditor : Editor
{
    public override void OnInspectorGUI() {
        //base.OnInspectorGUI();

        GraphBuilder gb = target as GraphBuilder;
        gb.EditorUpdate();
    }

}
