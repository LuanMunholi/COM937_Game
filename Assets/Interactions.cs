using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField] public GameObject powerUp1, powerUp2, powerUp3;
    public Transform camera;
    public float distInt;
    public bool interacted = false;

    void Update()
    {
        RaycastHit hit;
        interacted = Physics.Raycast(camera.position, camera.TransformDirection(Vector3.forward), out hit, distInt);

        if (Input.GetKeyDown(KeyCode.F) && interacted == true)
        {
            if (hit.transform.GetComponent<Animator>() != null)
            {
                if (hit.collider.CompareTag("chest1"))
                {
                    hit.transform.GetComponent<Animator>().SetTrigger("chest1");   
                    powerUp1.SetActive(true);
                }

                if (hit.collider.CompareTag("chest2"))
                {
                    hit.transform.GetComponent<Animator>().SetTrigger("chest2");
                    powerUp2.SetActive(true);
                }
            }
        }

    }
}
