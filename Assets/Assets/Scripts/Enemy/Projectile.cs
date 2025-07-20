using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float projectileSpeed = 2f;
    
    [SerializeField] int damage = 2;
    void Start()
    {
         rb.linearVelocity = transform.forward * projectileSpeed;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Innit(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage);

        Destroy(this.gameObject);
    }
    
    
}
