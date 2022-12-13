using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint1;
    [SerializeField] private Transform respawnPoint2;
    [SerializeField] private Transform respawnPoint3;
    [SerializeField] private Transform respawnPoint4;
    [SerializeField] private Transform respawnPoint5;
    [SerializeField] private Transform respawnPoint6;
    [SerializeField] private Transform respawnPoint7;
    [SerializeField] private Transform respawnPoint8;
    [SerializeField] private Transform respawnPoint9;
    [SerializeField] private Transform respawnPoint10;
    [SerializeField] private Transform respawnPoint11;
    [SerializeField] private Transform respawnPoint12;

    public int checkPointAtual;

    void setCheckpoint(int n)
    {
        checkPointAtual = n;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player.CompareTag("Player"))
        {
            player.transform.position = checkPointAtual.transform.position;
            Physics.SyncTransforms();
        }
    }
}
