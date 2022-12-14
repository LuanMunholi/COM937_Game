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
        if (Input.GetKeyDown(KeyCode.Escape)) {
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
            Debug.Log("Pause");
            canvas.gameObject.SetActive (true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        } else {
            Debug.Log("Resume");
            canvas.gameObject.SetActive (false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}