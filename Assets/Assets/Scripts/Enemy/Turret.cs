using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform turretHead;
    [SerializeField] Transform porjectileSpawnpoint;
    [SerializeField] Transform playerTarget;
    [SerializeField] GameObject projecrilePrefab;
    [SerializeField] float firerate = 2f;
    [SerializeField] int damage = 2;

    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = FindFirstObjectByType<PlayerHealth>();
        StartCoroutine(Ak47());
        
    }
    void Update()
    {
        turretHead.LookAt(playerTarget);
        
    }

    IEnumerator Ak47()
    {
        while (playerHealth)
        {
            yield return new WaitForSeconds(firerate);
            Projectile projectile = Instantiate(projecrilePrefab, porjectileSpawnpoint.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.transform.LookAt(playerTarget);
            projectile.Innit(damage);
        }
    }
}
