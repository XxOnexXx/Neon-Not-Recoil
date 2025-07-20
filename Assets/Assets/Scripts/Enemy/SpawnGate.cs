using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    [SerializeField] GameObject robotPrefab;

    [SerializeField] float spawnCd = 5f;

    [SerializeField] Transform spawnPoint;
    GameManager gameManager;

    PlayerHealth player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerHealth>();
        gameManager = FindFirstObjectByType<GameManager>();
        StartCoroutine(SpawnEnemy());
        

    }


    IEnumerator SpawnEnemy()
    {
        
        while (player)
        {
            Instantiate(robotPrefab, spawnPoint.position, transform.rotation);
            yield return new WaitForSeconds(spawnCd);
        }
    }
}
