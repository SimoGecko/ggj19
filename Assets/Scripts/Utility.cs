// (c) Simone Guggiari 2018

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

////////// DESCRIPTION //////////

public static class Utility {
    
    // --------------------- CUSTOM METHODS ----------------


    // commands
    public static Vector3 MousePosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane p = new Plane(Vector3.up, 0);
        float enter;
        if(p.Raycast(ray, out enter)) {
            return ray.GetPoint(enter);
        }
        return Vector3.zero;
    }

    public static T GetMin<T>(T[] elems, System.Func<T, float> f) {
        T best = default(T);
        float dist = float.MaxValue;
        for (int i = 0; i < elems.Length; i++) {
            float d = f(elems[i]);
            if (d < dist) {
                dist = d;
                best = elems[i];
            }
        }
        return best;
    }
    /*
    public static void SerializeObject<T>(T serializableObject, string fileName) {
        if (serializableObject == null) { return; }

        XmlDocument xmlDocument = new XmlDocument();
        XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
        using (MemoryStream stream = new MemoryStream()) {
            serializer.Serialize(stream, serializableObject);
            stream.Position = 0;
            xmlDocument.Load(stream);
            xmlDocument.Save(fileName);
        }
    }

    public static T DeSerializeObject<T>(string fileName) {
        if (string.IsNullOrEmpty(fileName)) { return default(T); }
        T objectOut = default(T);

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(fileName);
        string xmlString = xmlDocument.OuterXml;

        using (StringReader read = new StringReader(xmlString)) {
            Type outType = typeof(T);

            XmlSerializer serializer = new XmlSerializer(outType);
            using (XmlReader reader = new XmlTextReader(read)) {
                objectOut = (T)serializer.Deserialize(reader);
            }
        }
        return objectOut;
    }
    */

    public static Vector2 RoundTo2(Vector3 pos, int digits = 2) {
        return new Vector2((float)Math.Round(pos.x, 2), (float)Math.Round(pos.z, 2));
    }

    public static Vector2 OnUnitCircle() {
        float phi = UnityEngine.Random.value * 2 * Mathf.PI;
        return new Vector2(Mathf.Cos(phi), Mathf.Sin(phi));
    }

    public static Vector3 To3(this Vector2 v) { return new Vector3(v.x, 0, v.y); }
    public static Vector2 To2(this Vector3 v) { return new Vector2(v.x, v.z); }

    // --------------------- CUSTOM METHODS ----------------

    //converts an object to a string in the form field1,field2,...
    public static string Serialize<T>(T obj) {
        string result = "";
        foreach (var fi in typeof(T).GetFields()) {
            result += fi.GetValue(obj).ToString() + ",";
        }
        return result;
    }

    //takes a string in the above format and creates an object of the correct type from it
    public static T Deserialize<T>(string s) where T : new() {
        s = RemoveSpaceAndTabs(s);
        string[] values = s.Split(',');
        T result = new T();
        int v = 0;
        foreach (var fi in typeof(T).GetFields()) {
            var val = System.Convert.ChangeType(values[v++], fi.FieldType);
            fi.SetValue(result, val);
        }
        return result;
    }

    public static string RemoveSpaceAndTabs(this string s) {
        return s.Replace(" ", "").Replace("\t", "");
    }


    // queries



    // other

}