using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollect : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] public Transform camera;
    [SerializeField] public AudioSource sfx;

    public float distInt;
    public bool interacted = false;
    public int layer_mask;

    void Start()
    {
        layer_mask = LayerMask.GetMask("powerUp");
    }

    void Update()
    {
        RaycastHit hit;
        interacted = Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hit, distInt, layer_mask);

        if (Input.GetKeyDown(KeyCode.F) && interacted == true)
        {
            if (hit.collider.CompareTag("powerUpDash"))
            {
                PlayerMovement playerDash = player.GetComponent<PlayerMovement>();
                playerDash.DashUnlock();
                sfx.Play();
                Destroy(gameObject); 
            }

            if (hit.collider.CompareTag("powerUpWall"))
            {   
                PlayerMovement playerDash = player.GetComponent<PlayerMovement>();
                playerDash.WallRideUnlock();
                sfx.Play();
                Destroy(gameObject);
            }
        }

    }
}
