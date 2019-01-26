using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public int clientID;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TaxiEmpty"))
        {
            print(other.name + "picked up");
            other.GetComponent<Taxi>().clientID = clientID;
            other.GetComponent<Taxi>().Pickup();
            Destroy(gameObject);
        }
    }

}
