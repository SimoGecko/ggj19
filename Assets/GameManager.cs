using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPaused;
    public AudioManager audioManager;

    public GameObject startMenu;
    public GameObject restartMenu;

    public TaxiManager2 taxiManager;

    private void Start()
    {
        startMenu.SetActive(true);
        audioManager.Play("TrafficAmbience_01");
        audioManager.Play("ThemeMusic_01");
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        taxiManager.enabled = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if(isPaused == true)
        {
            print("CONTINUE");
            isPaused = false;
            Time.timeScale = 1.0f;
        } else {
            print("PAUSE");
            isPaused = true;
            Time.timeScale = 0f;
        }
    }

    void SpeedUp()
    {

    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        taxiManager.enabled = false;
        restartMenu.SetActive(true);
    }
}
