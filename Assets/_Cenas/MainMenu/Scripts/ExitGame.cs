using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitGameButton()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
