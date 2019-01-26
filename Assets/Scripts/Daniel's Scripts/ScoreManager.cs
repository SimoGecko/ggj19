using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public float scoreValue;
    public string scoreText;
    public Text scoreHolder;

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
}
