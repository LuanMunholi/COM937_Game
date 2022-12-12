using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour
{

    public GameObject Canvas;
    public GameObject Camera;
    bool Paused = false;

    void Start()
    {
        Canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Paused == true)
            {
                Debug.Log("Resume");
                Time.timeScale = 1.0f;
                Canvas.gameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Camera.GetComponent<AudioSource>().Play();
                Paused = false;
            }
            else
            {
                Debug.Log("Pause");
                Time.timeScale = 0.0f;
                Canvas.gameObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Camera.GetComponent<AudioSource>().Pause();
                Paused = true;
            }
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        Canvas.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Camera.GetComponent<AudioSource>().Play();
    }
}