using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taxi : MonoBehaviour
{
    public int clientID;

    public void Pickup()
    {
        transform.gameObject.tag = "TaxiFull";
    }
}
