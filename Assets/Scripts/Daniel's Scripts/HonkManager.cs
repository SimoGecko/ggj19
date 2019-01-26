using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HonkManager : MonoBehaviour
{
    public bool isActive;
    public Taxi taxi;

    private void Start()
    {
        Invoke("ActivateTrigger", 1f);
    }

    void ActivateTrigger()
    {
        isActive = true;
    }

    void OnTriggerEnter(Collider other)
    {
        print("big trigger detected");
        if(other.CompareTag("ProximityChecker") && isActive == true)
        {
            print(other.name + "in Proximity");
            taxi.Honk();
        }
          
    }
}
