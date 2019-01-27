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
    public ScoreManager scoreManager;

    private Color startColor;
    public Color assignedColor;

    public GameObject priceBubbleCanvas;
    public Image priceBubbleImage;
    public TextMeshProUGUI priceBubbleText;

    private Renderer taxiRenderer;

    [Header("Settings")]
    public float blinkOutInterval;
    public float zOffset;


    private void Start()
    {
        priceBubbleCanvas.transform.parent = null;
        taxiRenderer = GetComponent<Renderer>();
        startColor = taxiRenderer.materials[0].color;
        audioManager = FindObjectOfType<AudioManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void Pickup()
    {
        isOccupied = true;
        adaptedPrice = maxPrice;
        taxiRenderer.materials[0].color = assignedColor;
        priceBubbleText.text = adaptedPrice.ToString() + "$";
        audioManager.Play("Pickup_01");
        StartCoroutine("CountDown");
        StartCoroutine("SpeechBubblePos");

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
                    audioManager.Play("AngryPerson_01");
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
        taxiRenderer.materials[0].color = startColor;
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
            scoreManager.CountCrash();
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

    IEnumerator SpeechBubblePos()
    {
        while(isOccupied)
        {
            priceBubbleCanvas.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zOffset);
            yield return null;
        }

        yield break;
    }

}
