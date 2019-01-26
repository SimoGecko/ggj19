using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public int clientID;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TaxiFull"))
        {
            if (other.GetComponent<Taxi>().clientID == clientID)
            {
                print(other.name + "delivered");
                Destroy(gameObject);
            }
        }
    }
}
