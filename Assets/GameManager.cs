using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isPaused;

    public GameObject startMenu;
    public GameObject restartMenu;
    public GameObject controlsMenu;

    public TaxiManager2 taxiManager;
    public AudioManager audioManager;

    public TextMeshProUGUI gameOverScore;

    private void Start()
    {
        startMenu.SetActive(true);
        audioManager.Play("TrafficAmbience_01");
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        taxiManager.enabled = true;
        audioManager.Play("ThemeMusic_01");
    }

    /* private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    } */

    public void OpenControls()
    {
        controlsMenu.SetActive(true);
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
            Time.timeScale = 0.000000000001f;
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

    public void CloseGame()
    {
        Application.Quit();
    }

}
