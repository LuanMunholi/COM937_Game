using UnityEngine;
using UnityEngine.AI;

public class HunterAI : MonoBehaviour {

    public AudioSource explosionVfx;
    public ParticleSystem explosionSfx;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    //Route
    public Vector3 walkPoint;
    //States
    public float sightRange;
    public bool playerInSightRange;

    [SerializeField] private Transform respawnPoint;

    private void Awake() {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        explosionSfx.Stop();
    }

    private void Update() {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (playerInSightRange) {
            ChasePlayer();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (player.CompareTag("Player"))
        {
            explosionSfx.Play();
            explosionVfx.Play();
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }
    }
    
    private void ChasePlayer() {
        agent.SetDestination(player.position);
    }
}