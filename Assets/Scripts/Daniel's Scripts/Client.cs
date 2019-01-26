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
    public float maxPrice;

    void Start()
    {
        GetComponent<Renderer>().material.color = assignedColor;
        priceBubbleImage.color = assignedColor;
        maxPrice = Random.Range(5,10);
        priceBubbleText.text = maxPrice + "$";
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Taxi"))
        {
            if (other.GetComponent<Taxi>().isOccupied == false)
            {
                print(other.name + "picked up" + gameObject.name);
                other.GetComponent<Taxi>().clientID = clientID;
                other.GetComponent<Taxi>().maxPrice = maxPrice;
                other.GetComponent<Taxi>().targetMarker = targetMarker;

                other.GetComponent<Taxi>().priceBubbleCanvas.SetActive(true);
                other.GetComponent<Taxi>().priceBubbleImage.color = priceBubbleImage.color;
                other.GetComponent<Taxi>().Pickup();
                Destroy(gameObject);
            }
        }
    }

}
