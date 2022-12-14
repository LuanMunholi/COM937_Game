using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpAudio : MonoBehaviour
{
    [SerializeField] public AudioSource grama, pedra, madeira, item;
    [SerializeField] public Transform origem;
    [SerializeField] public GameObject player;

    public bool interacted = false;
    private PlayerMovement noChao;

    void Start()
    {
        grama.Stop();
        pedra.Stop();
        madeira.Stop();
        item.Stop();
        noChao = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        RaycastHit hit;
        interacted = Physics.Raycast(origem.position, Vector3.down, out hit, Mathf.Infinity);

        if(Input.GetKeyDown("w"))
        {
            if (hit.collider.CompareTag("chaoPedra") && !pedra.isPlaying && interacted == true)
            {
                pedra.Play();
            }
            else if (hit.collider.CompareTag("chaoMadeira") && !madeira.isPlaying && interacted == true)
            {
                madeira.Play();
            }
            else if(!grama.isPlaying)
            {
                grama.Play();
            }
        }

        if(Input.GetKeyDown("s"))
        {
            if (hit.collider.CompareTag("chaoPedra") && !pedra.isPlaying && interacted == true)
            {
                pedra.Play();
            }
            else if (hit.collider.CompareTag("chaoMadeira") && !madeira.isPlaying && interacted == true)
            {
                madeira.Play();
            }
            else if(!grama.isPlaying)
            {
                grama.Play();
            }
        }

        if(Input.GetKeyDown("a"))
        {
            if (hit.collider.CompareTag("chaoPedra") && !pedra.isPlaying && interacted == true)
            {
                pedra.Play();
            }
            else if (hit.collider.CompareTag("chaoMadeira") && !madeira.isPlaying && interacted == true)
            {
                madeira.Play();
            }
            else if(!grama.isPlaying)
            {
                grama.Play();
            }
        }

        if(Input.GetKeyDown("d"))
        {
            if (hit.collider.CompareTag("chaoPedra") && !pedra.isPlaying && interacted == true)
            {
                pedra.Play();
            }
            else if (hit.collider.CompareTag("chaoMadeira") && !madeira.isPlaying && interacted == true)
            {
                madeira.Play();
            }
            else if(!grama.isPlaying)
            {
                grama.Play();
            }
        }

        if(Input.GetKeyUp("w"))
        {
            grama.Stop();
            pedra.Stop();
            madeira.Stop();
        }

        if(Input.GetKeyUp("s"))
        {
            grama.Stop();
            pedra.Stop();
            madeira.Stop();
        }

        if(Input.GetKeyUp("a"))
        {
            grama.Stop();
            pedra.Stop();
            madeira.Stop();
        }

        if(Input.GetKeyUp("d"))
        {
            grama.Stop();
            pedra.Stop();
            madeira.Stop();
        }
    }
}