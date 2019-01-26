using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiManager2 : MonoBehaviour
{
    // Adding feature so same destination can't be picked twice.

    [Header ("Generation")]
    public Transform[] origins;
    public int[] originsIndex;
    public int originsValue;
    public int originsOccupied;

    public Transform[] destinations;
    public int[] destinationsIndex;
    public int destinationsValue;
    public int destinationsOccupied;

    public Color[] colors;
    public int[] colorsIndex;
    public int colorsValue;
    public int colorsOccupied;

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
            StartCoroutine("SpawnClient");
            countdown = spawnDelay;
        }
    }

    void SpawnTaxi()
    { 
    
    }

    IEnumerator SpawnClient()
    {
        clientID++;


// GENERATING RANDOM VALUES BUT NEVER SAME TWICE IN A ROW.

        // ISSUE: Will have to reset once all have been used.

        if(originsOccupied>=originsIndex.Length)
        {
            for (int i = 0; i < originsIndex.Length; i++)
            {
                originsIndex[i] = 0;
            }

        }

        // If all int have been used it resets
        if (originsOccupied >= originsIndex.Length)
        {
            for (int i = 0; i < originsIndex.Length; i++)
            {
                originsIndex[i] = 0;
            }

            originsOccupied = 0;

        }


        if (destinationsOccupied >= destinationsIndex.Length)
        {
            for (int i = 0; i < destinationsIndex.Length; i++)
            {
                destinationsIndex[i] = 0;
            }

            destinationsOccupied = 0;

        }

        if (colorsOccupied >= colorsIndex.Length)
        {
            for (int i = 0; i < colorsIndex.Length; i++)
            {
                colorsIndex[i] = 0;
            }

            colorsOccupied = 0;

        }



        // 1 means already used. 0 means available.
        do
        {
            originsValue = Random.Range(0, originsIndex.Length);
        } while (originsIndex[originsValue] == 1);
        assignedOrigin = origins[originsValue];
        originsIndex[originsValue] = 1;
        originsOccupied++;

        do
        {
            destinationsValue = Random.Range(0, destinationsIndex.Length);
        } while (destinationsIndex[destinationsValue] == 1);
        assignedDestination = destinations[destinationsValue];
        destinationsIndex[destinationsValue] = 1;
        destinationsOccupied++;

        do
        {
            colorsValue = Random.Range(0, colorsIndex.Length);
        } while (colorsIndex[colorsValue] == 1);
        assignedColor = colors[colorsValue];
        colorsIndex[colorsValue] = 1;
        colorsOccupied++;





        Taxi generatedTaxi = Instantiate(taxiPrefab, taxiSpawnpoint.position, Quaternion.identity) as Taxi;
        // generatedTaxi.assignedDestination = assignedDestination;
        // generatedTaxi.assignedColor = assignedColor;

        GameObject generatedClient = Instantiate(client, assignedOrigin.position, Quaternion.identity);
        generatedClient.GetComponent<Renderer>().material.color = assignedColor;
        generatedClient.GetComponent<Client>().clientID = clientID;

        GameObject generatedDestination = Instantiate(marker, assignedDestination.position, assignedDestination.rotation);
        generatedDestination.GetComponent<Renderer>().material.color = assignedColor;
        generatedDestination.GetComponent<Destination>().clientID = clientID;

        yield break;

    }
}
