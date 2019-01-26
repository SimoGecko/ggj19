using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPaused;

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
}
