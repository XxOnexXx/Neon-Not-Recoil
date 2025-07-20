using Cinemachine;
using Cinemachine.Utility;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    RaycastHit hit;
    EnemyHealth enemyHealth;
    
    [SerializeField] ParticleSystem muzzuleFlash;
    CinemachineImpulseSource impulseSource;
    [SerializeField] LayerMask layerMask;

    void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    public bool ShootHandle(WeaponSo weaponSo)
    {



        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, layerMask, QueryTriggerInteraction.Ignore))
            muzzuleFlash.Play();
            impulseSource.GenerateImpulse();

        {
            Instantiate(weaponSo.HitVFXPrefab, hit.point, Quaternion.identity);
            enemyHealth = hit.collider.GetComponentInParent<EnemyHealth>();
            enemyHealth?.TakeDamage(weaponSo.Damage);


        }

        return true;
    }
}
