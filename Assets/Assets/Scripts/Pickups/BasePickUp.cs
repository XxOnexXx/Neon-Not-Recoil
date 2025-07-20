using Unity.VisualScripting;
using UnityEngine;

public abstract class BasePickUp : MonoBehaviour
{
    
    const string PLAYER_TAG = "Player";
    
    

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag(PLAYER_TAG))
        {
            ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
            OnPickup(activeWeapon);
            Destroy(this.gameObject);
            

        }

    }

    protected abstract void OnPickup(ActiveWeapon activeWeapon);
}
