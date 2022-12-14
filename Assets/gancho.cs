using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gancho : MonoBehaviour
{
    [Header("Gancho")]
    [SerializeField] Camera cam;
    [SerializeField] KeyCode hookButtom = KeyCode.R;
    [SerializeField] GameObject ganchoObj;
    [SerializeField] GameObject paiGancho;
    [SerializeField] float hookSpeedMult = 100f;
    [SerializeField] float hookDistance = 100f;

    public Vector3 posicaoHitGancho;
    public Estado estado;
    Vector3 velocidadeMomentanea;

    Rigidbody rb;


    public enum Estado
    {
        Normal,
        GanchoPuxando,
        GanchoIndo,
    }

    RaycastHit hit;

    void Start()
    {
        estado = Estado.Normal;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        switch(estado)
        {
            default:
            case Estado.Normal:
                paiGancho.SetActive(false);
                ganchoObj.transform.parent = paiGancho.transform;
                ganchoObj.transform.localPosition = Vector3.zero;
                break;

            case Estado.GanchoIndo:
                ganchoObj.transform.parent = null;
                paiGancho.SetActive(true);
                GanchoMovimentando();
                break;

            case Estado.GanchoPuxando:
                MovimentoPersonagemGancho();
                break;

        }
        AtiraGancho();
    }

    void MovimentoPersonagemGancho()
    {
        
        float velocidadeMin = 10f;
        float velocidadeMax = 40f;
        Vector3 direcao = (posicaoHitGancho - transform.position).normalized;

        float puxaVel = Mathf.Clamp(Vector3.Distance(transform.position, posicaoHitGancho),
            velocidadeMin, velocidadeMax);

       

        if(Vector3.Distance(transform.position, posicaoHitGancho) < hookDistance)
        {
            estado = Estado.Normal;
            paiGancho.SetActive(false);
            rb.useGravity = true;
        }
        else
        {

            rb.useGravity = false;
            rb.AddForce(direcao * puxaVel * Time.deltaTime * hookSpeedMult, ForceMode.Force);
            
        }

        
    }

    void GanchoMovimentando()
    {
        ganchoObj.transform.LookAt(posicaoHitGancho);
        ganchoObj.transform.position = Vector3.MoveTowards(ganchoObj.transform.position, 
            posicaoHitGancho, 50 * Time.deltaTime);

        if(ganchoObj.transform.position == posicaoHitGancho)
        {
            estado = Estado.GanchoPuxando;
        }
    }
    void AtiraGancho()
    {
        if(Input.GetKeyDown(hookButtom))
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
            {
                posicaoHitGancho = hit.point;
                estado = Estado.GanchoIndo;
            }
        }
    }
}
