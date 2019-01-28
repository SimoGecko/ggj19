using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform exitPoint;
    public Transform taxiToMove;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Taxi"))
        {
            print("TAXI LEFT MAP");
            taxiToMove = other.transform.parent;
            // other.transform.position = new Vector3(exitPoint.position.x, transform.position.y, exitPoint.position.z);
            //taxiToMove.position = new Vector3(exitPoint.position.x, transform.position.y, exitPoint.position.z);
            taxiToMove.GetComponent<VehicleMovement>().SetNewPosition(exitPoint.position);
        }
    }
}
