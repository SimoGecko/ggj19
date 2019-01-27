using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float scoreValue;
    public string scoreText;
    public Text scoreHolder;

    public GameManager gameManager;

    public int totalCrashes;
    public int maxCrashes = 3;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    public void UpdateScore()
    {
        print("Score updated");
        scoreHolder.text = scoreText + scoreValue + "$";
    }


    public void CountCrash()
    {
        totalCrashes++;
        if(totalCrashes>=maxCrashes)
        {
            gameManager.GameOver();
        }
    }
}
