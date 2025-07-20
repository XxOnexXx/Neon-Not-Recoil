using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSo", menuName = "Scriptable Objects/WeaponSo")]
public class WeaponSo : ScriptableObject
{

    public GameObject WeaponPrefab;
    public GameObject HitVFXPrefab;
    public int Damage = 2;
    public float fireRate = 0.5f;

    public bool IsAutomatic = false;
    public bool CanZoom = false;

    public float ZoomAmount = 10f;

    public float zoomSens = 0.3f;

    public int Magzine_Size = 12;

    public int Stored_Mag = 15;
}
