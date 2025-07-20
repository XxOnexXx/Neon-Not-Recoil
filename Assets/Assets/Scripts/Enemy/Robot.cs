using StarterAssets;
using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    NavMeshAgent navMeshAgent;

    FirstPersonController player;

    EnemyHealth enemyHealth;

    const string PLAYER_TAG = "Player";

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (!player) return;
        navMeshAgent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            enemyHealth.alahuAkbhar();
        }
    }
}
