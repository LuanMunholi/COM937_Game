using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTres : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] public deathZone deathzone;

    void OnTriggerEnter(Collider other)
    {
        if (player.CompareTag("Player"))
            deathzone.setCheckpoint(3);
    }
}
