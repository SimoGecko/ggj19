using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Taxi : MonoBehaviour
{
    public int clientID;
    public float maxPrice = 0;
    public float adaptedPrice = 0;

    public GameObject targetMarker;

    public float priceDiscount;
    public float timeStep;
    public float countdown;
    public bool isOccupied;
    public AudioManager audioManager;

    public GameObject priceBubbleCanvas;
    public Image priceBubbleImage;
    public TextMeshProUGUI priceBubbleText;

    private Renderer taxiRenderer;

    [Header("Settings")]
    public float blinkOutInterval;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        taxiRenderer = GetComponent<Renderer>();
    }

    public void Pickup()
    {
        isOccupied = true;
        adaptedPrice = maxPrice;
        priceBubbleText.text = adaptedPrice.ToString() + "$";
        StartCoroutine("CountDown");

    }

    IEnumerator CountDown()
    {

        countdown = timeStep;

         
        while (isOccupied)
        {
            countdown -= Time.deltaTime;

            if(countdown <= 0)
            {
                adaptedPrice -= priceDiscount;
                priceBubbleText.text = adaptedPrice.ToString() + "$";
                countdown = timeStep;


                if(adaptedPrice <= 0)
                {
                    print("CUSTOMER LEFT");
                    EmptyTaxi();
                }
            }

            yield return null;
        }


        yield break;
   
    }

    public void EmptyTaxi()
    {
        clientID = 0;
        Destroy(targetMarker);
        isOccupied = false;
        priceBubbleCanvas.SetActive(false);
    }

    public void Honk()
    {
        print("Honk");
        audioManager.Play("CarHorn_01");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Taxi") || other.gameObject.CompareTag("Obstacle"))
        {
            print("collided with " + other.tag);
            // FREEZE MOVEMENT HERE
            audioManager.Play("CarCrash_01");
            EmptyTaxi();
            StartCoroutine("BlinkOut");
        }
    }

    IEnumerator BlinkOut()
    {
        yield return new WaitForSeconds(blinkOutInterval);
        taxiRenderer.enabled = false;
        yield return new WaitForSeconds(blinkOutInterval);
        taxiRenderer.enabled = true;
        yield return new WaitForSeconds(blinkOutInterval);
        taxiRenderer.enabled = false;
        yield return new WaitForSeconds(blinkOutInterval);
        taxiRenderer.enabled = true;
        yield return new WaitForSeconds(blinkOutInterval);
        taxiRenderer.enabled = false;

        Destroy(transform.parent.gameObject);

        yield break;
    }

}
