using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Client : MonoBehaviour
{
    public Color assignedColor;

    public int clientID;
    public Image priceBubbleImage;
    public TextMeshProUGUI priceBubbleText;
    public GameObject targetMarker;
    private Taxi taxi;
    public float maxPrice;

    void Start()
    {
        transform.GetChild(0).GetComponent<Renderer>().materials[1].color = assignedColor;
        priceBubbleImage.color = assignedColor;
        maxPrice = Random.Range(5,10);
        priceBubbleText.text = maxPrice + "$";
    }


    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.name);
        if (other.CompareTag("Taxi"))
        {
            print("with Taxi");
            if (other.GetComponent<Taxi>().isOccupied == false)
            {
                taxi = other.GetComponent<Taxi>();
                print(other.name + "picked up" + gameObject.name);
                taxi.clientID = clientID;
                taxi.maxPrice = maxPrice;
                taxi.targetMarker = targetMarker;

                taxi.priceBubbleCanvas.SetActive(true);
                taxi.priceBubbleImage.color = assignedColor;
                taxi.assignedColor = assignedColor;
                taxi.Pickup();

                /* other.GetComponent<Taxi>().clientID = clientID;
                other.GetComponent<Taxi>().maxPrice = maxPrice;
                other.GetComponent<Taxi>().targetMarker = targetMarker;

                other.GetComponent<Taxi>().priceBubbleCanvas.SetActive(true);
                other.GetComponent<Taxi>().priceBubbleImage.color = priceBubbleImage.color;
                other.GetComponent<Taxi>().Pickup(); */
                Destroy(gameObject);
            }
        }
    }

}
