using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    public Transform canvas;

    // Use this for initialization
    void Start () {
        canvas.gameObject.SetActive (false);
    }
    
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Escape)) {
            Pause();
        }
    }

    public void ManualResume(){
        Pause();
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause(){
        if (canvas.gameObject.activeInHierarchy == false) {
            canvas.gameObject.SetActive (true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        } else {
            canvas.gameObject.SetActive (false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}