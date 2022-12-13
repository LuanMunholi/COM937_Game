using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointUm : MonoBehaviour
{
    [SerializeField] public deathZone deathzone;

    void OnTriggerEnter(Collider other)
    {
        deathzone.setCheckpoint(1);
    }
}
