using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockPortal : MonoBehaviour
{
    [SerializeField] public GameObject portal;

    private void OnTriggerEnter(Collider other)
    {
        portal.SetActive(true);
        Destroy(gameObject);
    }
}
