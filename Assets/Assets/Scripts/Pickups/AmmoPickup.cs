using UnityEngine;

public class AmmoPickup : BasePickUp
{

    [SerializeField] int ammoAmount = 50;
    public Vector3 Rotation = new Vector3(0, 50, 0);

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.AddSubAmmo(ammoAmount);

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
