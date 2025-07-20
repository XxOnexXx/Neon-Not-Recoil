using System.Diagnostics;
using Unity.Collections;
using UnityEngine;

public class WeaponPickUp : BasePickUp
{

    [SerializeField] WeaponSo weaponSo;

  
    public Vector3 Rotation = new Vector3(0, 50, 0);

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(weaponSo);

    }

    void Update()
    {
        PickupRoation(7);
    }

public void PickupRoation(float rotationSpeed)
    {
        transform.Rotate(Rotation * rotationSpeed * Time.deltaTime);
    }
}
