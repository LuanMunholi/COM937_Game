using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
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

    public int checkPointAtual = 0;

    public void setCheckpoint(int n)
    {
        checkPointAtual = n;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (checkPointAtual == 0)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint.transform.position;
                Physics.SyncTransforms();
            }
        }

        if (checkPointAtual == 1)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint1.transform.position;
                Physics.SyncTransforms();
            }
        }
        
        if (checkPointAtual == 2)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint2.transform.position;
                Physics.SyncTransforms();
            }
        }
        
        if (checkPointAtual == 3)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint3.transform.position;
                Physics.SyncTransforms();
            }
        }
        
        if (checkPointAtual == 4)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint4.transform.position;
                Physics.SyncTransforms();
            }
        }
        
        if (checkPointAtual == 5)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint5.transform.position;
                Physics.SyncTransforms();
            }
        }
        
        if (checkPointAtual == 6)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint6.transform.position;
                Physics.SyncTransforms();
            }
        }
        
        if (checkPointAtual == 7)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint7.transform.position;
                Physics.SyncTransforms();
            }
        }
        
        if (checkPointAtual == 8)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint8.transform.position;
                Physics.SyncTransforms();
            }
        }
        
        if (checkPointAtual == 9)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint9.transform.position;
                Physics.SyncTransforms();
            }
        }
        
        if (checkPointAtual == 10)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint10.transform.position;
                Physics.SyncTransforms();
            }
        }
        
        if (checkPointAtual == 11)
        {
            if (player.CompareTag("Player"))
            {
                player.transform.position = respawnPoint11.transform.position;
                Physics.SyncTransforms();
            }
        }
    }
}
