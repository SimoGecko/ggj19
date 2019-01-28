using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public float scoreValue;
    public string scoreText;
    public TextMeshProUGUI scoreHolder;

    public GameObject[] lifes;

    public GameManager gameManager;

    public int totalCrashes;
    public int maxCrashes = 3;

    // Start is called before the first frame update
    void Start()
    {
        totalCrashes = 0;
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
        if(totalCrashes < lifes.Length)
        {
            lifes[totalCrashes].SetActive(false);
        }

        totalCrashes++;
        if(totalCrashes>=maxCrashes)
        {
            gameManager.gameOverScore.text = "You earned: " + scoreValue + "$";
            gameManager.GameOver();
        }
    }
}
