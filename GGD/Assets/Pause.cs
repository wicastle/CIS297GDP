using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool isPaused = false;

    public GameObject pauseMenuUi;

    private void Start()
    {
        isPaused = false;
        pauseMenuUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pressed esc");
            if(isPaused)
            {
                resume();
                Debug.Log("resume");
            }
            else
            {
                pause();
                Debug.Log("pause");
            }
        }

    }

    public void resume()
    {
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isPaused = false;
    }

    void pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadQuit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

}
