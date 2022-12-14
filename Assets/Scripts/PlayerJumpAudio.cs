using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAudio : MonoBehaviour
{
    public GameObject jump;

    // Start is called before the first frame update
    void Start()
    {
        jump.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jumping();
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            StopJumping();
        }

    }

    void Jumping()
    {
        jump.SetActive(true);
    }

    void StopJumping()
    {
        jump.SetActive(false);
    }
}