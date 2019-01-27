using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destination : MonoBehaviour
{
    public int clientID;
    public float moneyEarned;
    public GameObject scoreManager;
    public AudioManager audioManager;
    public Image speechBubbleImage;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        scoreManager = GameObject.FindWithTag("ScoreManager");
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Taxi"))
        {
            if (other.GetComponent<Taxi>().clientID == clientID)
            {
                print(other.name + "delivered");
                moneyEarned = other.GetComponent<Taxi>().adaptedPrice;
                other.GetComponent<Taxi>().EmptyTaxi();
                AddScore();
            }
        }
    }

    void AddScore()
    {
        audioManager.Play("Cash_01");
        scoreManager.GetComponent<ScoreManager>().scoreValue += moneyEarned;
        scoreManager.GetComponent<ScoreManager>().UpdateScore();
    }
}
