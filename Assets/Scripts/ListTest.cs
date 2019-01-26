using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTest : MonoBehaviour
{
    List<string> attributeNamesList = new List<string>();
    List<int> numberList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        print("Length at start" + attributeNamesList.Count);

        attributeNamesList.Add("Health");
        attributeNamesList.Add("Mana");
        attributeNamesList.Add("Attack");

        print("Length at start " + attributeNamesList.Count);

    }

    // Update is called once per frame
    void Update()
    {
        foreach(string data in attributeNamesList)
        {
            Debug.Log(data);
        }
    }
}
