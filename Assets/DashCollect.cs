using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashCollect : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (player.CompareTag("Player"))
        {
            PlayerMovement playerDash = player.GetComponent<PlayerMovement>();
            playerDash.DashUnlock();
        }

        Destroy(gameObject);
    }
}
