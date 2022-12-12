using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPaused : MonoBehaviour
{
    public static bool _isPaused;

    bool GetPaused()
    {
        return _isPaused;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (_isPaused == true)
            {
                _isPaused = false;
            }
            else
            {
                _isPaused = true;
            }
        }
    }
}
