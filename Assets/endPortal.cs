using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endPortal : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (player.CompareTag("Player"))
        {
            SceneManager.LoadScene("MainMenu");
            SceneManager.UnloadScene("Greyboxing");
        }
    }
}
