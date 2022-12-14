//Rev 1.09

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float playerHeight = 2f;

    [SerializeField] Transform orientation;

    [SerializeField] public AudioSource pulo;
    [SerializeField] public AudioSource dash;

    [Header("Booleans")]
    [SerializeField] bool doublejump_bool = false;
    [SerializeField] bool sprint_bool = false;
    [SerializeField] bool dash_bool = false;
    [SerializeField] bool hook_bool = false;

    [Header("Wall identifier")]
    [SerializeField] LayerMask Wall;

    [Header("Movement")]
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float airMultiplier = 0.4f;
    [SerializeField] float gravity_acceleration = 6f;
    [SerializeField] float gravity = 10f;
    float movementMultiplier = 10f;


    [Header("Sprinting")]
    [SerializeField] float walkSpeed = 4f;
    [SerializeField] float sprintSpeed = 6f;
    [SerializeField] float acceleration = 10f;

    [Header("Jumping")]
    public float jumpForce = 5f;
    private bool jumpStatus = false;
    private Vector3 normalVector = Vector3.up;

    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode sprintKey = KeyCode.LeftShift;
    [SerializeField] KeyCode dashKey = KeyCode.E;
    [SerializeField] KeyCode hookButtom = KeyCode.R;

    [Header("Drag")]
    [SerializeField] float groundDrag = 6f;
    [SerializeField] float airDrag = 2f;

    float horizontalMovement;
    float verticalMovement;

    [Header("Ground Detection")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float groundDistance = 0.2f;
    public bool isGrounded { get; private set; }

    [Header("Dash")]
    [SerializeField] float dashSpeed = 500f;
    [SerializeField] float dashTime = 1f;
    [SerializeField] float dashDelay = 1f;
    private float startTime;
    private float dashCooldown;

    [Header("Hook")]
    [SerializeField] Camera cam;
    [SerializeField] GameObject ganchoObj;
    [SerializeField] GameObject paiGancho;
    [SerializeField] float hookSpeedMult = 500f;
    [SerializeField] float hookDistance = 10f;

    public Vector3 posicaoHitGancho;
    public Estado estado;
    Vector3 velocidadeMomentanea;
    Rigidbody rb;
    Vector3 moveDirection;
    Vector3 slopeMoveDirection;
    RaycastHit slopeHit;
    RaycastHit hit;

    bool estado_normal = true;
    public enum Estado
    {
        Normal,
        GanchoPuxando,
        GanchoIndo,
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight / 2 + 0.5f))
        {
            if (slopeHit.normal != Vector3.up)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        estado = Estado.Normal;
        rb.freezeRotation = true;
        pulo.Stop();
        dash.Stop();
    }


    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        MyInput();
        ControlDrag();
        ControlSpeed();
        ConfirmWall();

        if(hook_bool)
        {
            AtiraGancho();
        }
        
        if(TouchGround() || ConfirmWall())
        {
            jumpStatus = false;
        }

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            pulo.Play();
            GroundJump();
        }

        if(Input.GetKeyDown(jumpKey) && !isGrounded && !ConfirmWall() && !jumpStatus && doublejump_bool)
        {
            pulo.Play();
            AirJump();
        }

        dashCooldown -= Time.deltaTime;
        if(Input.GetKeyDown(dashKey) && dashCooldown <= 0 && dash_bool)
        {
            dash.Play();
            Dash();
        }

        switch(estado)
        {
            default:
            case Estado.Normal:
                estado_normal = true;
                paiGancho.SetActive(false);
                ganchoObj.transform.parent = paiGancho.transform;
                ganchoObj.transform.localPosition = Vector3.zero;
                break;

            case Estado.GanchoIndo:
                estado_normal = false;
                ganchoObj.transform.parent = null;
                paiGancho.SetActive(true);
                GanchoMovimentando();
                break;

            case Estado.GanchoPuxando:
                MovimentoPersonagemGancho();
                break;

        }
        

        slopeMoveDirection = Vector3.ProjectOnPlane(moveDirection, slopeHit.normal);
    }

    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }

    void GroundJump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void AirJump()
    {
        jumpStatus = true;
        rb.AddForce(Vector2.up * jumpForce * 50f);
        rb.AddForce(normalVector * jumpForce * 20f);

        Vector3 vel = rb.velocity;
        if (rb.velocity.y < 0.5f)
            rb.velocity = new Vector3(vel.x, 0, vel.z);
        else if (rb.velocity.y > 0)
            rb.velocity = new Vector3(vel.x, vel.y / 2, vel.z);

    }

    void ControlSpeed()
    {
        if (Input.GetKey(sprintKey) && isGrounded && sprint_bool)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, sprintSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, acceleration * Time.deltaTime);
        }
    }

    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = airDrag;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
        if(!ConfirmWall() && estado_normal)
        {
            rb.AddForce(Physics.gravity * gravity_acceleration, ForceMode.Acceleration);
        }
    }

    void MovePlayer()
    {
        if (isGrounded && !OnSlope())
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if (isGrounded && OnSlope())
        {
            rb.AddForce(slopeMoveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        }
        else if (!isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier * airMultiplier, ForceMode.Acceleration);
        }
    }
    
    private void Dash()
    {
        OnStartDash();

        while(startTime > 0)
        {
            rb.AddForce(moveDirection * dashSpeed * Time.deltaTime, ForceMode.VelocityChange);
            startTime -= Time.deltaTime;    
        }
        OnEndDash();
        
    }

    private void OnStartDash()
    {
        startTime = dashTime;
        rb.useGravity = false;
        rb.velocity = Vector3.zero; 
    }

    private void OnEndDash()
    { 
        dashCooldown = dashDelay;
        rb.useGravity = true;
        rb.velocity = Vector3.zero; 
    }

    bool ConfirmWall()
    {
        return Physics.CheckSphere(transform.position, 0.6f, Wall);
    }

    public bool TouchGround()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void MovimentoPersonagemGancho()
    {
        
        float velocidadeMin = 10f;
        float velocidadeMax = 40f;
        Vector3 direcao = (posicaoHitGancho - transform.position).normalized;

        float puxaVel = Mathf.Clamp(Vector3.Distance(transform.position, posicaoHitGancho),
            velocidadeMin, velocidadeMax);

       
        rb.useGravity = false;
        if(Vector3.Distance(transform.position, posicaoHitGancho) < hookDistance)
        {
            estado = Estado.Normal;
            paiGancho.SetActive(false);
            rb.useGravity = true;
        }
        else
        {
            
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

    public void DashUnlock()
    {
        dash_bool = true;
    }
    
    public void WallRideUnlock()
    {
        doublejump_bool = true;
    }

}