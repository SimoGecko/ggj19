using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiManager : MonoBehaviour
{
    [Header ("Generation")]
    public Transform[] origins;
    public int[] originsIndex;

    public Transform[] destinations;
    public int[] destinationsIndex;

    public Color[] colors;
    public int[] colorsIndex;

    public Transform assignedOrigin;
    public Transform assignedDestination;
    public Color assignedColor;
    public int clientID = 0;

    [Header("Taxi")]
    public Taxi taxiPrefab;
    public Transform taxiSpawnpoint;

    [Header("Other Prefabs")]
    public GameObject client;
    public GameObject marker;


    [Header ("Settings")]
    public float spawnDelay;
    public float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown>0)
        {

            countdown -= Time.deltaTime; 

        } else {

            //Insert spawn function here
            PickRandom();
            countdown = spawnDelay;
        }
    }

    void PickRandom()
    {
        clientID++;

        assignedOrigin = origins[Random.Range(0, origins.Length)];
        assignedDestination = destinations[Random.Range(0, destinations.Length)];
        assignedColor = colors[Random.Range(0, colors.Length)];

        Taxi generatedTaxi = Instantiate(taxiPrefab, taxiSpawnpoint.position, Quaternion.identity) as Taxi;
        // generatedTaxi.assignedDestination = assignedDestination;
        // generatedTaxi.assignedColor = assignedColor;

        GameObject generatedClient = Instantiate(client, assignedOrigin.position, Quaternion.identity);
        generatedClient.GetComponent<Renderer>().material.color = assignedColor;
        generatedClient.GetComponent<Client>().clientID = clientID;

        GameObject generatedDestination = Instantiate(marker, assignedDestination.position, assignedDestination.rotation);
        generatedDestination.GetComponent<Renderer>().material.color = assignedColor;
        generatedDestination.GetComponent<Destination>().clientID = clientID;

    }
}
